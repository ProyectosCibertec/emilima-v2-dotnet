using System;
using System.Collections.Generic;

namespace EmilimaV2Web.Models
{
    public partial class Document
    {
        public int SerialNumber { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? UploadDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public string FileId { get; set; } = null!;
        public int DocumentTypeId { get; set; }
        public string DocumentSerieId { get; set; } = null!;
        public int? DocumentRequestId { get; set; }

        public virtual DocumentRequest? DocumentRequest { get; set; }
        public virtual DocumentalSerie DocumentSerie { get; set; } = null!;
        public virtual DocumentType DocumentType { get; set; } = null!;
        public virtual File File { get; set; } = null!;
    }
}
