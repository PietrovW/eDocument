namespace Notifikation.Domain.Models
{
    public class Notifikation : BaseModel
    {
        public User User { get; set; }
        public string Message { get; set; }
    }
}
