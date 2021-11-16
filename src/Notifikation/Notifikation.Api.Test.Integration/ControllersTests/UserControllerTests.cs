using Microsoft.AspNetCore.Mvc.Testing;
using Notifikation.Test.Integration;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Notifikation.Api.Test.Integration
{
    public class UserControllerTests : BasicApiTests
    {
        public UserControllerTests(WebApplicationFactory<Api.Startup> factory):base(factory)
        {
        }

        [Theory]
        [InlineData("/api/User")]
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
