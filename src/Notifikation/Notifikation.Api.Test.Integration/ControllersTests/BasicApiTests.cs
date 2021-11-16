using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Notifikation.Test.Integration
{
    public class BasicApiTests : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        protected readonly WebApplicationFactory<Api.Startup> _factory;

        public BasicApiTests(WebApplicationFactory<Api.Startup> factory)
        {
            _factory = factory;
        }
    }
}
