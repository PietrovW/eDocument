namespace Notifikation.Infrastructure.Models
{
    public class ErrorResponseModel
    {
        public bool IsError { get; set; }
        public string[] Messages { get; set; }
        public object DeveloperMessage { get; set; }
    }
}
