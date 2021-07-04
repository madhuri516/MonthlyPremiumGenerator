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
        public (string,int) GetSearchResultFromSearchEngine(string searchEngine, string keyword)
        {
            List<int> searchURLPositions = new List<int>();
            StringBuilder builder = new StringBuilder();
            string result;
            Uri searchURI = new Uri("https://www.sympli.com.au");
            string search = string.Format(uRLStringExtractForSeachEngine.GetURLString(searchEngine), WebUtility.UrlEncode(keyword));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(search);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
                {
                    string html = reader.ReadToEnd();
                    searchURLPositions = FindURLPosition(html, searchURI);
                    if (searchURLPositions.Count == 0)
                        return ("0", 0);
                    else
                    {
                        foreach (int position in searchURLPositions)
                        {
                            builder.Append(position).Append(",");
                        }
                        result = builder.ToString().TrimEnd(',');
                        return (result, searchURLPositions.Count);
                    }
                }
            }

        }

        /// <summary> /// Examins the search result and retrieves the position of URL appearance. /// </summary> 
        public List<int> FindURLPosition(string html, Uri searchuri)
        {
            List<int> result = new List<int>();
            string lookup = @"(https:\/\/\w+\.\w+\.\w+\.\w+\/)";
            MatchCollection matches = Regex.Matches(html,lookup); 
            for (int i = 0;i<matches.Count;i++) 
            { 
                string match = matches[i].Groups[0].Value;
                if (match.Contains(searchuri.Host))
                {
                    int positionOfURLappearance = i + 1;
                    if (positionOfURLappearance <= 100)
                    {
                        result.Add(positionOfURLappearance);
                        
                    }
                }
            }
            return result;
        }
    }
}
