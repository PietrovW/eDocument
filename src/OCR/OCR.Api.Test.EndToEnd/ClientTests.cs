using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System.Net.Http;

namespace OCR.Api.Test.EndToEnd.ControllersTest
{
    public class ClientTests
    {
        protected readonly TestServer Server;
        protected readonly HttpClient Client;

        public ClientTests()
        {
            var webHost = new WebHostBuilder()
                           .UseEnvironment(Environments.Staging)
                           .UseStartup<Api.Startup>();
            Server = new TestServer(webHost);
            Client = Server.CreateClient();
        }
    }
}
