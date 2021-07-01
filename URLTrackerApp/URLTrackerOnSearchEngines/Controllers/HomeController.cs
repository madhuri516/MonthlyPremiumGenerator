using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using URLTrackerOnSearchEngines.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace URLTrackerOnSearchEngines.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISearchEngineResult _searchEngineResult;

        public HomeController(ISearchEngineResult searchEngineResult, ILogger<HomeController> logger)
        {
            _logger = logger;
            _searchEngineResult = searchEngineResult;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchResultGenerator()
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

        [HttpPost]
        public IActionResult SearchResultGenerator(SearchDetails searchDetails)
        {
            string searchEngine = searchDetails.SelectedItem;
            string keyword = searchDetails.SearchKeyword;
            int rank = _searchEngineResult.GetSearchResultFromSearchEngine(searchEngine,  keyword);
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
