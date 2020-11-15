﻿namespace eDocument.Infrastructure.Options
{
    public class SmtpConfigOptions
    {
        public const string SmtpConfig = "SmtpConfig";
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; }

        public string Name { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
