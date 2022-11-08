using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmilimaV2Web.Models;

[Table("documental_serie", Schema = "emilima")]
[Index("Name", Name = "documental_serie$name_UNIQUE", IsUnique = true)]
[Index("HierarchicalDependencyId", Name = "fk_documental_serie_hierarchical_dependency_idx")]
[Index("OrganicUnitId", Name = "fk_documental_serie_organic_unit_idx")]
public partial class DocumentalSerie
{
    [Key]
    [Column("code")]
    [StringLength(6)]
    [Display(Name = "Código")]
    public string Code { get; set; } = null!;

    [Column("name")]
    [StringLength(200)]
    [Display(Name = "Nombre")]
    public string Name { get; set; } = null!;

    [Column("hierarchical_dependency_id")]
    [Display(Name = "Dependencia Jerárquica")]
    public int HierarchicalDependencyId { get; set; }

    [Column("organic_unit_id")]
    [Display(Name = "Unidad Orgánica")]
    public int OrganicUnitId { get; set; }

    [Column("definition")]
    [Display(Name = "Definición")]
    public string Definition { get; set; } = null!;

    [Column("service_frequency")]
    [StringLength(45)]
    [Display(Name = "Frecuencia")]
    public string ServiceFrequency { get; set; } = null!;

    [Column("normative_scope")]
    [Display(Name = "Alcance Normativo")]
    public string NormativeScope { get; set; } = null!;

    [Column("is_public")]
    [MaxLength(1)]
    [Display(Name = "Público")]
    public byte[]? IsPublic { get; set; }

    [Column("phisical_features")]
    [StringLength(45)]
    [Display(Name = "Características")]
    public string? PhisicalFeatures { get; set; }

    [Column("documental_serie_value")]
    [StringLength(1)]
    [Display(Name = "Serie")]
    public string DocumentalSerieValue { get; set; } = null!;

    [Column("years_in_management_archive")]
    [Display(Name = "Años AG")]
    public int YearsInManagementArchive { get; set; }

    [Column("years_in_central_archive")]
    [Display(Name = "Años AC")]
    public int YearsInCentralArchive { get; set; }

    [Column("elaboration_date")]
    [Precision(0)]
    [Display(Name = "Elaboración")]
    public DateTime ElaborationDate { get; set; }

    [InverseProperty("DocumentSerie")]
    [Display(Name = "Documentos")]
    public virtual ICollection<Document> Documents { get; } = new List<Document>();

    [ForeignKey("HierarchicalDependencyId")]
    [InverseProperty("DocumentalSeries")]
    [Display(Name = "Dependencia Jerárquica")]
    public virtual HierarchicalDependency HierarchicalDependency { get; set; } = null!;

    [ForeignKey("OrganicUnitId")]
    [InverseProperty("DocumentalSeries")]
    [Display(Name = "Unidad Orgánica")]
    public virtual OrganicUnit OrganicUnit { get; set; } = null!;
}
