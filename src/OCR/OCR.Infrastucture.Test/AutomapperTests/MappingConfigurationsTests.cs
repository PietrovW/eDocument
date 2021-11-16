using AutoMapper;
using NUnit.Framework;
using OCR.Infrastructure.Profiles;

namespace OCR.Infrastucture.Test.AutomapperTests
{
    public class MappingConfigurationsTests
    {
        [Test]
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
