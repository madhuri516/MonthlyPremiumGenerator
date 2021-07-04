using System;
using Xunit;
using URLTrackerOnSearchEngines;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace URLTrackerOnSearchEngines.Tests
{
    public class SearchEngineResultTests
    {
        private readonly ILogger<SearchEngineResults> logger;

        [Fact]
        public void ReturnCOrrectURLPosition_FindURLPosition()
        {
            //Arrange
             SearchEngineResults searchEngineResults = new SearchEngineResults(logger);
            string html = $"https://www.sympli.com.au/&amp;sa=U&amp;ved=2ahUKEwilvYmv9L_xAhUPGrkGHbNfBdQQFjAMegQIKBAB&amp;usg=AOvVaw0eE4oAWHcpkmPl7mkdr5fT";
            Uri searchURL = new Uri("https://www.sympli.com.au");
            List<int> expectedURLPosition = new List<int>{ 1 };

            //Act
            List<int> actualURLPosition = searchEngineResults.FindURLPosition(html, searchURL);

            //Assert
            Assert.Equal(expectedURLPosition, actualURLPosition);
        }

        [Fact]
        public void ReturnEmptyListOfURLPositionIfMatchingURLNotFound_FindURLPosition()
        {
            //Arrange
            SearchEngineResults searchEngineResults = new SearchEngineResults(logger);
            string html = $"https://www.pexa.com.au/&amp;sa=U&amp;ved=2ahUKEwilvYmv9L_xAhUPGrkGHbNfBdQQFjANegQIFhAB&amp;usg=AOvVaw3bRZ4vzFiahH9crAnVAmHr";
            Uri searchURL = new Uri("https://www.sympli.com.au");
            List<int> expectedURLPosition = new List<int>();

            //Act
            List<int> actualURLPosition = searchEngineResults.FindURLPosition(html, searchURL);

            //Assert
            Assert.Equal(expectedURLPosition, actualURLPosition);
        }

        [Fact]
        public void GetSearchURLRankAndCountIfMatchingURLisFound_GetSearchResultFromSearchEngine()
        {
            //Arrange
            SearchEngineResults searchEngineResults = new SearchEngineResults(logger);
            string searchEngine = "Google";
            string keyword = "e-settlements";
            (string,int) expectedURLPositionAndCount = ("2",1);

            //Act
            (string,int) actualURLPositionAndCount = searchEngineResults.GetSearchResultFromSearchEngine(searchEngine, keyword);

            //Assert
            Assert.Equal(expectedURLPositionAndCount, actualURLPositionAndCount);
        }

    }
}
