namespace Notifikation.Domain.Models
{
    public class NotifikationModel : BaseModel
    {
        public UserModel User { get; set; }
        public string Message { get; set; }
    }
}
