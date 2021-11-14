using eDocument.Infrastructure.Extensions;

namespace Notifikation.Infrastructure.Exceptions
{
    public class NoExistsNotifikatInfrastructureException: InfrastructureException
    {
        public NoExistsNotifikatInfrastructureException(string message)
            :base($"Servis Notifikation : {message}")
        {

        }
    }
}
