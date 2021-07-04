using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URLTrackerOnSearchEngines
{
    public interface ISearchEngineResult
    {
        (string,int) GetSearchResultFromSearchEngine(string searchEngine, string keyword);
        List<int> FindURLPosition(string html, Uri searchuri);
    }
}
