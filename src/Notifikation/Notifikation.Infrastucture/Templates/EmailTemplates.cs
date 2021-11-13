using System;
using System.IO;
using System.Reflection;

namespace Notifikation.Infrastructure.Templates
{
    public static class EmailTemplates
    {
        static string testEmailTemplate;
        static string plainTextTestEmailTemplate;
        public static string GetTestEmail(string recepientName, DateTime testDate)
        {
            if (testEmailTemplate == null)
                testEmailTemplate = ReadPhysicalFile("TestEmail.template");

            string emailMessage = testEmailTemplate
                .Replace("{user}", recepientName)
                .Replace("{testDate}", testDate.ToString());

            return emailMessage;
        }

        public static string GetPlainTextTestEmail(DateTime date)
        {
            if (plainTextTestEmailTemplate == null)
                plainTextTestEmailTemplate = ReadPhysicalFile("PlainTextTestEmail.template");

            string emailMessage = plainTextTestEmailTemplate
                .Replace("{date}", date.ToString());

            return emailMessage;
        }


        private static string ReadPhysicalFile(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
