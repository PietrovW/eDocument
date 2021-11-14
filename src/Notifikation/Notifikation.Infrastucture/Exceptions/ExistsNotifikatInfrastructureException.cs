using eDocument.Infrastructure.Extensions;

namespace Notifikation.Infrastructure.Exceptions
{
    public class ExistsNotifikatInfrastructureException: InfrastructureException
    {
        public ExistsNotifikatInfrastructureException(string message)
            :base($"Servis Notifikation : {message}")
        {

        }
    }
}
