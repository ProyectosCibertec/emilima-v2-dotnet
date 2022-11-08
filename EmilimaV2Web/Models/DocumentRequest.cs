using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmilimaV2Web.Models;

[Table("document_request", Schema = "emilima")]
[Index("OrganicUnitId", Name = "fk_request_organic_unit_idx")]
[Index("StateId", Name = "fk_request_request_state_idx")]
[Index("UserId", Name = "user_id_idx")]
public partial class DocumentRequest
{
    [Key]
    [Column("id")]
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(45)]
    [Display(Name = "Nombre")]
    public string Name { get; set; } = null!;

    [Column("description")]
    [Display(Name = "Descripción")]
    public string Description { get; set; } = null!;

    [Column("creation_date")]
    [Precision(0)]
    [Display(Name = "Creación")]
    public DateTime? CreationDate { get; set; }

    [Column("state_id")]
    [Display(Name = "Estado")]
    public int StateId { get; set; }

    [Column("user_id")]
    [StringLength(45)]
    [Display(Name = "Usuario")]
    public string UserId { get; set; } = null!;

    [Column("organic_unit_id")]
    [Display(Name = "Unidad Orgánica")]
    public int OrganicUnitId { get; set; }

    [InverseProperty("DocumentRequest")]
    [Display(Name = "Documentos")]
    public virtual ICollection<Document> Documents { get; } = new List<Document>();

    [ForeignKey("OrganicUnitId")]
    [InverseProperty("DocumentRequests")]
    [Display(Name = "Unidad Orgánica")]
    public virtual OrganicUnit OrganicUnit { get; set; } = null!;

    [ForeignKey("StateId")]
    [InverseProperty("DocumentRequests")]
    [Display(Name = "Estado")]
    public virtual RequestState State { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("DocumentRequests")]
    [Display(Name = "Usuario")]
    public virtual User User { get; set; } = null!;
}
