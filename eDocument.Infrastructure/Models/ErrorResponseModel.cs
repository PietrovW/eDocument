namespace eDocument.Infrastructure.Models
{
    public class ErrorResponseModel
    {
        public string[] Messages { get; set; }
        public object DeveloperMessage { get; set; }
    }
}
