using System;
using Xunit;
using URLTrackerOnSearchEngines;
using Microsoft.Extensions.Logging;

namespace URLTrackerOnSearchEngines.Tests
{
    public class SearchEngineResultTests
    {
        private readonly ILogger<SearchEngineResults> logger;

        [Fact]
        public void CanFindURLPosition()
        {
            //Arrange
             SearchEngineResults searchEngineResults = new SearchEngineResults(logger);
            string html = $"https://www.sympli.com.au/&amp;sa=U&amp;ved=2ahUKEwilvYmv9L_xAhUPGrkGHbNfBdQQFjAMegQIKBAB&amp;usg=AOvVaw0eE4oAWHcpkmPl7mkdr5fT";
            Uri searchURL = new Uri("https://www.sympli.com.au");
            int expectedURLPosition = 2;

            //Act
            int actualURLPosition = searchEngineResults.FindURLPosition(html, searchURL);

            //Assert
            Assert.Equal(expectedURLPosition, actualURLPosition);
        }

        [Fact]
        public void ReturnZeroIfMatchingURLNotFound()
        {
            //Arrange
            SearchEngineResults searchEngineResults = new SearchEngineResults(logger);
            string html = $"https://www.pexa.com.au/&amp;sa=U&amp;ved=2ahUKEwilvYmv9L_xAhUPGrkGHbNfBdQQFjANegQIFhAB&amp;usg=AOvVaw3bRZ4vzFiahH9crAnVAmHr";
            Uri searchURL = new Uri("https://www.sympli.com.au");
            int expectedURLPosition = 0;

            //Act
            int actualURLPosition = searchEngineResults.FindURLPosition(html, searchURL);

            //Assert
            Assert.Equal(expectedURLPosition, actualURLPosition);
        }

        [Fact]
        public void GetSearchURLRankIfSearchEngineAndKeywordProvided()
        {
            //Arrange
            SearchEngineResults searchEngineResults = new SearchEngineResults(logger);
            string searchEngine = "Google";
            string keyword = "e-settlements";
            int expectedURLPosition = 2;

            //Act
            int actualURLPosition = searchEngineResults.GetSearchResultFromSearchEngine(searchEngine, keyword);

            //Assert
            Assert.Equal(expectedURLPosition, actualURLPosition);
        }

        [Fact]
        public void ReturnZeroIfSearchEngineIsNull()
        {
            //Arrange
            SearchEngineResults searchEngineResults = new SearchEngineResults(logger);
            string searchEngine = null;
            string keyword = "e-settlements";
            int expectedURLPosition = 0;

            //Act
            int actualURLPosition = searchEngineResults.GetSearchResultFromSearchEngine(searchEngine, keyword);

            //Assert
            Assert.Equal(expectedURLPosition, actualURLPosition);
        }

        [Fact]
        public void ReturnZeroIfSearchEngineIsEmpty()
        {
            //Arrange
            SearchEngineResults searchEngineResults = new SearchEngineResults(logger);
            string searchEngine = "";
            string keyword = "e-settlements";
            int expectedURLPosition = 0;

            //Act
            int actualURLPosition = searchEngineResults.GetSearchResultFromSearchEngine(searchEngine, keyword);

            //Assert
            Assert.Equal(expectedURLPosition, actualURLPosition);
        }

        [Fact]
        public void ReturnZeroIfKeywordIsNull()
        {
            //Arrange
            SearchEngineResults searchEngineResults = new SearchEngineResults(logger);
            string searchEngine = "Google";
            string keyword = null;
            int expectedURLPosition = 0;

            //Act
            int actualURLPosition = searchEngineResults.GetSearchResultFromSearchEngine(searchEngine, keyword);

            //Assert
            Assert.Equal(expectedURLPosition, actualURLPosition);
        }

        [Fact]
        public void ReturnZeroIfKeywordIsEmpty()
        {
            //Arrange
            SearchEngineResults searchEngineResults = new SearchEngineResults(logger);
            string searchEngine = "Google";
            string keyword = "";
            int expectedURLPosition = 0;

            //Act
            int actualURLPosition = searchEngineResults.GetSearchResultFromSearchEngine(searchEngine, keyword);

            //Assert
            Assert.Equal(expectedURLPosition, actualURLPosition);
        }

    }
}
