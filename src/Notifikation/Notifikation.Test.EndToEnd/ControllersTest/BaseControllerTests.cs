using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using Microsoft.Extensions.Hosting;

namespace Notifikation.Test.EndToEnd.ControllersTest
{
    public abstract class BaseControllerTests
    {
        protected readonly TestServer Server;
        protected readonly HttpClient Client;

        protected BaseControllerTests()
        {
           var webHost  =  new WebHostBuilder()
                          .UseEnvironment(Environments.Staging)
                          .UseStartup<Api.Startup>();
            Server = new TestServer(webHost);
            Client = Server.CreateClient();
        }
    }
}
