using eDocument.Infrastructure.Entity;

namespace OCR.Infrastructure.Entitys
{
    public class DocumentEntity : BaseEntity
    {
        public string Content { get; set; }

        public string Name { get; set; }
    }
}
