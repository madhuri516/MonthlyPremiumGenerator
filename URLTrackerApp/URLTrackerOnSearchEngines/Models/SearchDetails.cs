using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace URLTrackerOnSearchEngines.Models
{
    public class SearchDetails
    {
        //public SearchEngines searchengines = new SearchEngines();

        [Required(ErrorMessage = "Keyword is required")]
        [Display(Name = "Search Keyword: ")]
        public string SearchKeyword { get; set; }

        //public const string SearchURL = "www.sympli.com.au";
        public string SelectedItem { get; set; }
        public List<SelectListItem> SearchEngine { get; set; }
        [Display(Name = "URL Appearance Rank: ")]
        public int Rank { get; set; }
    }
}
