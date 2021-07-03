using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using URLTrackerOnSearchEngines.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;

namespace URLTrackerOnSearchEngines.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _cache;
        private readonly ISearchEngineResult _searchEngineResult;


        public HomeController(ISearchEngineResult searchEngineResult, ILogger<HomeController> logger, IMemoryCache memorycache)
        {
            _logger = logger;
            _searchEngineResult = searchEngineResult;
            _cache = memorycache;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Get the values of Search Engine dropdown and set it on page load
        [HttpGet]
        public IActionResult SearchPositionGenerator()
        {
            SearchEngines searchEngines = new SearchEngines();
            SearchDetails searchDetails = new SearchDetails {
                SearchEngine = searchEngines.SearchEngine.ConvertAll(a =>
                {
                    return new SelectListItem()
                    {
                        Text = a.ToString(),
                        Value = a.ToString(),
                        Selected = false
                    };
                })};
            return View(searchDetails);
        }

        //Calculate and post the value of Searched URL Position/Rank
        [HttpPost]
        public IActionResult SearchPositionGenerator(SearchDetails searchDetails)
        {
            string searchEngine = searchDetails.SelectedItem;
            string keyword = searchDetails.SearchKeyword;
            int rank = _cache.GetOrCreate("CacheRank", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromHours(1);
                return _searchEngineResult.GetSearchResultFromSearchEngine(searchEngine, keyword);
            });
            
            searchDetails.Rank = rank;
            return View(searchDetails);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
