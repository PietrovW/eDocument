using eDocument.Infrastructure.Extensions;

namespace Notifikation.Infrastructure.Exceptions
{
    public class NoExistsUserInfrastructureException : InfrastructureException
    {
        public NoExistsUserInfrastructureException(string message)
            :base($"Servis Notifikation : {message}")
        {

        }
    }
}
