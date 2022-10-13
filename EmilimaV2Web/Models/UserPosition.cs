﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmilimaV2Web.Models
{
    [Table("user_position", Schema = "emilima")]
    [Index("HierarchicalDependencyId", Name = "fk_user_position_hierarchical_dependency_idx")]
    [Index("OrganicUnitId", Name = "fk_user_position_organic_unit_idx")]
    [Index("Name", Name = "user_position$name_UNIQUE", IsUnique = true)]
    public partial class UserPosition
    {
        public UserPosition()
        {
            User1s = new HashSet<User1>();
        }

        [Key]
        [Column("id")]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(200)]
        [Display(Name = "Nombre")]
        public string Name { get; set; } = null!;
        [Column("organic_unit_id")]
        [Display(Name = "Unidad Orgánica")]
        public int OrganicUnitId { get; set; }
        [Column("hierarchical_dependency_id")]
        [Display(Name = "Dependencia Jerárquica")]
        public int HierarchicalDependencyId { get; set; }

        [ForeignKey("HierarchicalDependencyId")]
        [InverseProperty("UserPositions")]
        public virtual HierarchicalDependency HierarchicalDependency { get; set; } = null!;
        [ForeignKey("OrganicUnitId")]
        [InverseProperty("UserPositions")]
        public virtual OrganicUnit OrganicUnit { get; set; } = null!;
        [InverseProperty("Position")]
        public virtual ICollection<User1> User1s { get; set; }
    }
}
