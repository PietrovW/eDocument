using AutoMapper;
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

              //  configuration.AddMaps(typeof(AssemblyInfo).GetTypeInfo().Assembly);
            });

            // Assert
            config.AssertConfigurationIsValid();
        }
    }
}
