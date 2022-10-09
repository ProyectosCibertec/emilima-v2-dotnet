using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmilimaV2Web.Models
{
    [Keyless]
    [Table("User")]
    public partial class User
    {
        [StringLength(45)]
        public string Username { get; set; } = null!;
        [StringLength(45)]
        public string Password { get; set; } = null!;
        [StringLength(10)]
        public string Email { get; set; } = null!;
        public int RoleId { get; set; }
        [StringLength(45)]
        public string PhotoId { get; set; } = null!;
        public int PositionId { get; set; }
    }
}
