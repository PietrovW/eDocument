namespace OCR.Infrastructure.Entitys
{
    using eDocument.Infrastructure.Entity;
    public class DocumentEntity : BaseEntity
    {
        public string Content { get; set; }

        public string FileName { get; set; }

        public long UserId { get; set; }

        public byte[] Bytes { get; set; }
    }
}
