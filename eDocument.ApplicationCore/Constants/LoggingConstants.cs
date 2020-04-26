using Microsoft.Extensions.Logging;

namespace eDocument.ApplicationCore.Constants
{
    public static class LoggingConstants
    {
        public static readonly EventId INIT_DATABASE = new EventId(101, "Error whilst creating and seeding database");
        public static readonly EventId SEND_EMAIL = new EventId(201, "Error whilst sending email");
    }

}
