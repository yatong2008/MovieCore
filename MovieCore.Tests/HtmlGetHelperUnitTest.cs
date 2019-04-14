using System;
using System.Collections.Generic;
using MovieCore.Helpers;
using Xunit;

namespace MovieCore.Tests
{
    public class HtmlGetHelperUnitTest
    {
        private readonly List<KeyValuePair<string, string>> _header = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("x-access-token", "sjd1HfkjU83ksdsm3802k"),
        };


        [Theory]
        [InlineData("cinemaworld")]
        [InlineData("filmworld")]
        public async void HtmlGetHelper_Should_GetMovieData(string databaseName)
        {
            string WebsiteDomain = "http://webjetapitest.azurewebsites.net";
            string url = $"{WebsiteDomain}/api/{databaseName}/movies";


            var filmResult = await HtmlGetHelper.GetResult(url, _header);

            Assert.NotNull(filmResult);
        }

        [Fact]
        public async void HtmlGetHelperWithInvalidDatabaseName_Should_ReturnNull()
        {
            string WebsiteDomain = "http://webjetapitest.azurewebsites.net";
            string databaseName = "invalidMovieDatabase";
            string url = $"{WebsiteDomain}/api/{databaseName}/movies";

            var filmResult = await HtmlGetHelper.GetResult(url, _header);

            Assert.Null(filmResult);
        }
    }
}
