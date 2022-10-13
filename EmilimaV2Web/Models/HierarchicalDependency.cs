using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmilimaV2Web.Models
{
    [Table("hierarchical_dependency", Schema = "emilima")]
    [Index("Name", Name = "hierarchical_dependency$name_UNIQUE", IsUnique = true)]
    public partial class HierarchicalDependency
    {
        public HierarchicalDependency()
        {
            DocumentalSeries = new HashSet<DocumentalSerie>();
            UserPositions = new HashSet<UserPosition>();
        }

        [Key]
        [Column("id")]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(200)]
        [Display(Name = "Nombre")]
        public string Name { get; set; } = null!;

        [InverseProperty("HierarchicalDependency")]
        public virtual ICollection<DocumentalSerie> DocumentalSeries { get; set; }
        [InverseProperty("HierarchicalDependency")]
        public virtual ICollection<UserPosition> UserPositions { get; set; }
    }
}
