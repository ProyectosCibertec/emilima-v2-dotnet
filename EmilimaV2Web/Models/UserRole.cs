using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmilimaV2Web.Models
{
    [Table("user_role", Schema = "emilima")]
    [Index("Name", Name = "user_role$name_UNIQUE", IsUnique = true)]
    public partial class UserRole
    {
        public UserRole()
        {
            User1s = new HashSet<User1>();
        }

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
        public string? Description { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<User1> User1s { get; set; }
    }
}
