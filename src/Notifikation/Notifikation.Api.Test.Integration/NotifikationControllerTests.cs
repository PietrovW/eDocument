using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace Notifikation.Test.Integration
{
    public class NotifikationControllerTests : BasicApiTests
    {
        public NotifikationControllerTests(WebApplicationFactory<Api.Startup> factory) : base(factory)
        {
        }

        [Theory]
        [InlineData("/Notifikation")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = this._factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Xunit.Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
