using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.Threading.Tasks;

namespace Notifikation.Test.EndToEnd.ControllersTest
{
    public abstract class BaseControllerTests
    {
        protected readonly TestServer Server;
        protected readonly HttpClient Client;

        protected BaseControllerTests()
        {
           var webHost  =  new WebHostBuilder()
                          .UseEnvironment("Test")
                          .UseStartup<Api.Startup>();
            Server = new TestServer(webHost);
            Client = Server.CreateClient();
        }
    }
}
