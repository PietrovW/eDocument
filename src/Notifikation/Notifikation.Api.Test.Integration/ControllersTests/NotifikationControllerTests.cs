using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System.Net;
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
        [InlineData("/api/Notifikation")]
        public async Task Get_EndpointsReturnSuccessAndCorrectStatusCodeMethodNotAllowed(string url)
        {
           // Arrange
            var client = this._factory.CreateClient();
            
            // Act
            var response = await client.GetAsync(url);
            
            // Assert
            Xunit.Assert.Equal(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        }
    }
}
