using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.Threading.Tasks;

namespace Notifikation.Test.EndToEnd.Controllers
{
    public abstract class ControllerTestsBase
    {
        protected readonly TestServer Server;
        protected readonly HttpClient Client;

        protected ControllerTestsBase()
        {
           var webHost  =  new WebHostBuilder()
                          .UseEnvironment("Test")
                          .UseStartup<Api.Startup>();
            Server = new TestServer(webHost);
            Client = Server.CreateClient();
        }
    }
}
