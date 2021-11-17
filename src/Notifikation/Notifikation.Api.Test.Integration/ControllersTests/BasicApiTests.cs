using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System;
using Xunit;

namespace Notifikation.Test.Integration
{
    public class BasicApiTests : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        protected readonly WebApplicationFactory<Api.Startup> _factory;

        public BasicApiTests(WebApplicationFactory<Api.Startup> factory)
        {
            _factory = factory;
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment(Environments.Staging);
            });
        }

      


        protected virtual void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment(Environments.Staging);
            //builder.
            this.ConfigureWebHost(builder);
        }
     }
}
