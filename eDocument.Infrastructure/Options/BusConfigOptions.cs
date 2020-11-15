namespace eDocument.Infrastructure.Options
{
    public class BusConfigOptions
    {
        public static string BusConfig = "BusConfig";
        public string UserName { get; set; }
        public string Password { get; set; }
        public string VirtualHost { get; set; }
        public string HostName { get; set; }

    }
}
