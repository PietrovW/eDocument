using eDocument.ApplicationCore.Enums;
using eDocument.ApplicationCore.Models.Base;
using System;

namespace DocumentTracking.ApplicationCore.Entities
{
    public class Metadane : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public TypeFileEnum FileFormat { get; set; }

        public DateTime DateCreated { get;set; }

        public long Size { get; set; }
    }
}
