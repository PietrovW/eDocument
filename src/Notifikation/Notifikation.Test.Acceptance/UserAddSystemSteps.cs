using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Notifikation.Test.Acceptance
{
    [Binding]
    public class UserAddSystemSteps
    {
        protected TestServer Server;
        protected HttpClient Client;


        [When(@"I navigation to user controler")]
        public void WhenINavigationToUserControler()
        {
            var webHost = new WebHostBuilder()
                          .UseEnvironment(Environments.Staging)
                          .UseStartup<Api.Startup>();
            Server = new TestServer(webHost);
            Client = Server.CreateClient();
        }
        
        [When(@"add a usersystem name '(.*)' and addres Email '(.*)'")]
        public async Task WhenAddAUsersystemNameAndAddresEmail(string name, string email)
        {
            // Arrange
            var command = new CreateUserTest
            {
                Name = name,
                Email = email,
            };

            string stringPayload = JsonConvert.SerializeObject(command);
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            // Act
            var response = await Client.PostAsync($"api/user", httpContent);

            // Assert
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
        }
    }
}
