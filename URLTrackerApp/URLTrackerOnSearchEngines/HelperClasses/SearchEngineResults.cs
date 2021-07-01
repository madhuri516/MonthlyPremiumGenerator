using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;


namespace URLTrackerOnSearchEngines
{
    public class SearchEngineResults: ISearchEngineResult
    {
        private readonly ILogger<SearchEngineResults> _logger;
        URLStringExtractForSerachEngine uRLStringExtractForSeachEngine = new URLStringExtractForSerachEngine();

        public SearchEngineResults(ILogger<SearchEngineResults> logger)
        {
            _logger = logger;
        }

        /// <summary> ///Calculates the position/rank as search result for specific search URL e.g. "www.sympli.com.au" from a provided search engine and keyword/// </summary> 
        public int GetSearchResultFromSearchEngine(string searchEngine, string keyword)
        {
            if (String.IsNullOrEmpty(searchEngine))
            {
                _logger.LogWarning("Search Engine provided is either null or empty");
                return 0;
            }
            else if (String.IsNullOrEmpty(keyword))
            {
                _logger.LogWarning("Keyword provided is either null or empty");
                return 0;
            }
            else
            {
                Uri searchURI = new Uri("https://www.sympli.com.au");
                string search = string.Format(uRLStringExtractForSeachEngine.GetURLString(searchEngine), WebUtility.UrlEncode(keyword));
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(search);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
                    {
                        string html = reader.ReadToEnd();
                        return FindURLPosition(html, searchURI);
                    }
                }
            }
        }

        

        /// <summary> /// Examins the search result and retrieves the position. /// </summary> 
        public int FindURLPosition(string html, Uri searchuri) 
        { 
            string lookup = @"(https:\/\/\w+\.\w+\.\w+\.\w+\/)";
            MatchCollection matches = Regex.Matches(html,lookup); 
            for (int i = 0;i<matches.Count;i++) 
            { 
                string match = matches[i].Groups[0].Value;
                if (match.Contains(searchuri.Host)) 
                    return i + 1;
            }
            return 0;
        }
    }
}
