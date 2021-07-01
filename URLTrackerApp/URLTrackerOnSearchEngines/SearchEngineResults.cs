using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;


namespace URLTrackerOnSearchEngines
{
    public class SearchEngineResults: ISearchEngineResult
    {
        
        public int GetSearchResultFromSearchEngine(string searchEngine, string keyword)
        {
            Uri searchURL = new Uri("https://www.sympli.com.au");
            string search = string.Format(GetURLString(searchEngine), WebUtility.UrlEncode(keyword));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(search); 
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(),Encoding.ASCII))
                {
                    string html = reader.ReadToEnd(); return FindURLPosition(html, searchURL);
                }
            }
        }

        /// <summary> /// Retrieves the url string based on search engine type/// </summary> 
        private string GetURLString(string searchEngine)
        {
            string urlstring = "";
            switch (searchEngine)
            {
                case "Google":
                    urlstring = "http://www.google.com/search?num=39&q={0}&btnG=Search";
                    break;
                case "Bing":
                    urlstring = "http://www.bing.com/search?num=39&q={0}&btnG=Search";
                    break;
            }
            return urlstring;
        }

        /// <summary> /// Examins the search result and retrieves the position. /// </summary> 
        private static int FindURLPosition(string html, Uri urlstring) 
        { 
            string lookup = @"(https:\/\/\w+\.\w+\.\w+\.\w+\/)";
            MatchCollection matches = Regex.Matches(html,lookup); 
            for (int i = 0;i<matches.Count;i++) 
            { 
                string match = matches[i].Groups[0].Value;
                if (match.Contains(urlstring.Host)) 
                    return i + 1;
            }
            return 0;
        }
    }
}
