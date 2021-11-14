using System;

namespace eDocument.Infrastructure.Extensions
{
    public class InfrastructureException : Exception
    {
        private InfrastructureException()
        { }
        public InfrastructureException(string message)
            : base(message)
        { }

        public InfrastructureException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
