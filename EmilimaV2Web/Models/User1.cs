using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmilimaV2Web.Models
{
    [Table("user", Schema = "emilima")]
    [Index("PositionId", Name = "fk_user_user_position_idx")]
    [Index("PhotoId", Name = "photo_idx")]
    [Index("RoleId", Name = "role_idx")]
    public partial class User1
    {
        public User1()
        {
            DocumentRequests = new HashSet<DocumentRequest>();
        }

        [Key]
        [Column("username")]
        [StringLength(45)]
        [Display(Name = "Nombre de Usuario")]
        public string Username { get; set; } = null!;
        [Column("password")]
        [StringLength(45)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; } = null!;
        [Column("email")]
        [StringLength(100)]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;
        [Column("role_id")]
        [Display(Name = "Rol")]
        public int RoleId { get; set; }
        [Column("photo_id")]
        [StringLength(48)]
        [Display(Name = "Foto")]
        public string PhotoId { get; set; } = null!;
        [Column("position_id")]
        [Display(Name = "Posición")]
        public int PositionId { get; set; }

        [ForeignKey("PhotoId")]
        [InverseProperty("User1s")]
        public virtual File Photo { get; set; } = null!;
        [ForeignKey("PositionId")]
        [InverseProperty("User1s")]
        public virtual UserPosition Position { get; set; } = null!;
        [ForeignKey("RoleId")]
        [InverseProperty("User1s")]
        public virtual UserRole Role { get; set; } = null!;
        [InverseProperty("User")]
        public virtual ICollection<DocumentRequest> DocumentRequests { get; set; }
    }
}
