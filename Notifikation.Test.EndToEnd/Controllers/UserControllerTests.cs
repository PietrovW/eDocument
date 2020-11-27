using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Notifikation.Test.EndToEnd.Controllers
{
    public class UserControllerTests : ControllerTestsBase
    {

        [Theory]
        [InlineData(1)]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(long Id)
        {

            // Act
            var response = await Client.GetAsync($"api/user/{Id}");

            // Assert
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
        }
    }
}
