using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URLTrackerOnSearchEngines
{
    public interface ISearchEngineResult
    {
        int GetSearchResultFromSearchEngine(string searchEngine, string keyword);
        int FindURLPosition(string html, Uri searchuri);
    }
}
