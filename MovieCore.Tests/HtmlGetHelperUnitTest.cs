using MovieCore.Helpers;
using Xunit;

namespace MovieCore.Tests
{
    public class HtmlGetHelperUnitTest
    {
        [Theory]
        [InlineData("cinemaworld")]
        [InlineData("filmworld")]
        public void HtmlGetHelper_Should_GetMovieData(string databaseName)
        {
            string WebsiteDomain = "http://webjetapitest.azurewebsites.net";
            string url = $"{WebsiteDomain}/api/{databaseName}/movies";

            var filmResult = HtmlGetHelper.GetResult(url);

            Assert.NotNull(filmResult);
        }

        [Fact]
        public void HtmlGetHelperWithInvalidDatabaseName_Should_ReturnNull()
        {
            string WebsiteDomain = "http://webjetapitest.azurewebsites.net";
            string databaseName = "invalidMovieDatabase";
            string url = $"{WebsiteDomain}/api/{databaseName}/movies";

            var filmResult = HtmlGetHelper.GetResult(url);

            Assert.Null(filmResult.Result);
        }
    }
}
