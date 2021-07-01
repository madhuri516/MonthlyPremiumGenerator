using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URLTrackerOnSearchEngines
{
    public class URLStringExtractForSerachEngine
    {
        /// <summary> /// Retrieves the url string based on search engine type/// </summary> 
        public string GetURLString(string searchEngine)
        {
            string urlstring = "";
            switch (searchEngine)
            {
                case "Google":
                    urlstring = "https://www.google.com/search?num=39&q={0}&btnG=Search";
                    break;
                //To Do. Bing urlstring doesn't work yet as it requires access key to access API information
                case "Bing":
                    urlstring = "https://api.cognitive.microsoft.com/bing/v7.0/search?q={0}";
                    break;
            }
            return urlstring;
        }
    }
}
