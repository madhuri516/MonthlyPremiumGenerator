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

        [Required(ErrorMessage = "Keyword is required!")]
        [Display(Name = "Search Keyword: ")]
        public string SearchKeyword { get; set; }
        public string SelectedItem { get; set; }
        public List<SelectListItem> SearchEngine { get; set; }
        [Display(Name = "URL Appearance Rank/Position is: ")]
        public int Rank { get; set; }
    }
}
