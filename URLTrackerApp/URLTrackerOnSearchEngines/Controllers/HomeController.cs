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
using System.Data;

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

        
        //Calculate and pass the value of Searched URL's Position/Rank and number of occurances in SearchResults View
        [HttpPost]
        public IActionResult SearchPositionGenerator(SearchDetails searchDetails)
        {
            string searchEngine = searchDetails.SelectedItem;
            string keyword = searchDetails.SearchKeyword;
            //caching to limit call to search engine one call per hour per search
            var results = _cache.GetOrCreate("CacheRank", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromHours(1);
                return _searchEngineResult.GetSearchResultFromSearchEngine(searchEngine, keyword);
            });
            searchDetails.NumberOfAppearances = results.Item2;
            searchDetails.Rank = results.Item1;
            return View("SearchResults",searchDetails);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
