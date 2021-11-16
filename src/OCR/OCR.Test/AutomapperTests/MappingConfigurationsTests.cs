using AutoMapper;

namespace OCR.Test.AutomapperTests
{
    public class MappingConfigurationsTests
    {
        [Fact]
        public void WhenProfilesAreConfigured_ItShouldNotThrowException()
        {
            // Arrange
            var config = new MapperConfiguration(configuration =>
            {
                configuration.AddMaps(typeof(OCRProfile).Assembly);
            });

            // Assert
            config.AssertConfigurationIsValid();
        }
    }
}
