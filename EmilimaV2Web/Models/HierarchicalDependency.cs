using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmilimaV2Web.Models;

[Table("hierarchical_dependency", Schema = "emilima")]
[Index("Name", Name = "hierarchical_dependency$name_UNIQUE", IsUnique = true)]
public partial class HierarchicalDependency
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(200)]
    public string Name { get; set; } = null!;

    [InverseProperty("HierarchicalDependency")]
    public virtual ICollection<DocumentalSerie> DocumentalSeries { get; } = new List<DocumentalSerie>();

    [InverseProperty("HierarchicalDependency")]
    public virtual ICollection<UserPosition> UserPositions { get; } = new List<UserPosition>();
}
