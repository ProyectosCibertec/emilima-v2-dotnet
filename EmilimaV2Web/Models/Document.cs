using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmilimaV2Web.Models;

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
    public int SerialNumber { get; set; }

    [Column("name")]
    [StringLength(45)]
    public string Name { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [Column("upload_date")]
    [Precision(0)]
    public DateTime? UploadDate { get; set; }

    [Column("creation_date")]
    [Precision(0)]
    public DateTime? CreationDate { get; set; }

    [Column("file_id")]
    [StringLength(48)]
    public string FileId { get; set; } = null!;

    [Column("document_type_id")]
    public int DocumentTypeId { get; set; }

    [Column("document_serie_id")]
    [StringLength(6)]
    public string DocumentSerieId { get; set; } = null!;

    [Column("document_request_id")]
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
