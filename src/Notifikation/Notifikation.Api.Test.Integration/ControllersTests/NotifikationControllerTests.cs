using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Notifikation.Infrastructure.Command;
using Notifikation.Infrastructure.DTO;
using System.Net;
using System.Net.Http;
using System.Text;
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

        [Theory]
        [InlineData("/api/Notifikation")]
        public async Task Post_EndpointsReturnSuccessAndCorrectStatusCodeMethodNotAllowed(string url)
        {
            // Arrange
            var client = this._factory.CreateClient();

            // Act
            var model = new CreateNotifikationCommand() { Notifikation = new NotifikatItemDTO() { Message = string.Empty } };
            var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, stringContent);

            // Assert
            Xunit.Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
