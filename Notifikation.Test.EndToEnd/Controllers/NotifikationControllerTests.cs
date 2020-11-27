using System.Net;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Notifikation.Test.EndToEnd.Controllers
{
    public class NotifikationControllerTests : ControllerTestsBase
    {
        [Theory]
        [InlineData(1)]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(long Id)
        {

            // Act
            var response = await Client.GetAsync($"Notifikation/{Id}");

            // Assert

            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
        }
    }
}
