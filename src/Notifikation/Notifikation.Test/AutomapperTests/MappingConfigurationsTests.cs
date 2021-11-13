using AutoMapper;
using Notifikation.Api.Profiles;
using Xunit;

namespace Notifikation.Test.AutomapperTests
{
    public class MappingConfigurationsTests
    {
        [Fact]
        public void WhenProfilesAreConfigured_ItShouldNotThrowException()
        {
            // Arrange
            var config = new MapperConfiguration(configuration =>
            {
              configuration.AddMaps(typeof(MappingProfile).Assembly);
            });

            // Assert
            config.AssertConfigurationIsValid();
        }
    }
}
