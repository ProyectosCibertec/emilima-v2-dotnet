using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmilimaV2Web.Models
{
    [Table("document", Schema = "emilima")]
    [Index("Name", Name = "document$name_UNIQUE", IsUnique = true)]
    [Index("DocumentRequestId", Name = "fk_documentation_document_request_idx")]
    [Index("DocumentSerieId", Name = "fk_documentation_documental_serie_idx")]
    [Index("DocumentTypeId", Name = "fk_documentation_documentation_type_idx")]
    [Index("FileId", Name = "fk_documentation_file1_idx")]
    public partial class Document
    {
        [Key]
        [Column("serial_number")]
        [Display(Name = "Número Serial")]
        public int SerialNumber { get; set; }
        [Column("name")]
        [StringLength(45)]
        [Display(Name = "Nombre")]
        public string Name { get; set; } = null!;
        [Column("description")]
        [Display(Name = "Descripción")]
        public string? Description { get; set; }
        [Column("upload_date")]
        [Precision(0)]
        [Display(Name = "Subida")]
        public DateTime? UploadDate { get; set; }
        [Column("creation_date")]
        [Precision(0)]
        [Display(Name = "Creación")]
        public DateTime? CreationDate { get; set; }
        [Column("file_id")]
        [StringLength(48)]
        [Display(Name = "Archivo")]
        public string FileId { get; set; } = null!;
        [Column("document_type_id")]
        [Display(Name = "Tipo")]
        public int DocumentTypeId { get; set; }
        [Column("document_serie_id")]
        [StringLength(6)]
        [Display(Name = "Serie")]
        public string DocumentSerieId { get; set; } = null!;
        [Column("document_request_id")]
        [Display(Name = "Solicitud")]
        public int? DocumentRequestId { get; set; }

        [ForeignKey("DocumentRequestId")]
        [InverseProperty("Documents")]
        public virtual DocumentRequest? DocumentRequest { get; set; }
        [ForeignKey("DocumentSerieId")]
        [InverseProperty("Documents")]
        public virtual DocumentalSerie DocumentSerie { get; set; } = null!;
        [ForeignKey("DocumentTypeId")]
        [InverseProperty("Documents")]
        public virtual DocumentType DocumentType { get; set; } = null!;
        [ForeignKey("FileId")]
        [InverseProperty("Documents")]
        public virtual File File { get; set; } = null!;
    }
}
