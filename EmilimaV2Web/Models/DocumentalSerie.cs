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
    public string Code { get; set; } = null!;

    [Column("name")]
    [StringLength(200)]
    public string Name { get; set; } = null!;

    [Column("hierarchical_dependency_id")]
    public int HierarchicalDependencyId { get; set; }

    [Column("organic_unit_id")]
    public int OrganicUnitId { get; set; }

    [Column("definition")]
    public string Definition { get; set; } = null!;

    [Column("service_frequency")]
    [StringLength(45)]
    public string ServiceFrequency { get; set; } = null!;

    [Column("normative_scope")]
    public string NormativeScope { get; set; } = null!;

    [Column("is_public")]
    [MaxLength(1)]
    public byte[]? IsPublic { get; set; }

    [Column("phisical_features")]
    [StringLength(45)]
    public string? PhisicalFeatures { get; set; }

    [Column("documental_serie_value")]
    [StringLength(1)]
    public string DocumentalSerieValue { get; set; } = null!;

    [Column("years_in_management_archive")]
    public int YearsInManagementArchive { get; set; }

    [Column("years_in_central_archive")]
    public int YearsInCentralArchive { get; set; }

    [Column("elaboration_date")]
    [Precision(0)]
    public DateTime ElaborationDate { get; set; }

    [InverseProperty("DocumentSerie")]
    public virtual ICollection<Document> Documents { get; } = new List<Document>();

    [ForeignKey("HierarchicalDependencyId")]
    [InverseProperty("DocumentalSeries")]
    public virtual HierarchicalDependency HierarchicalDependency { get; set; } = null!;

    [ForeignKey("OrganicUnitId")]
    [InverseProperty("DocumentalSeries")]
    public virtual OrganicUnit OrganicUnit { get; set; } = null!;
}
