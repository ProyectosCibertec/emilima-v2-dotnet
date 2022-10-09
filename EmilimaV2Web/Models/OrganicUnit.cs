using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmilimaV2Web.Models
{
    [Table("organic_unit", Schema = "emilima")]
    public partial class OrganicUnit
    {
        public OrganicUnit()
        {
            DocumentRequests = new HashSet<DocumentRequest>();
            DocumentalSeries = new HashSet<DocumentalSerie>();
            UserPositions = new HashSet<UserPosition>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(80)]
        public string Name { get; set; } = null!;

        [InverseProperty("OrganicUnit")]
        public virtual ICollection<DocumentRequest> DocumentRequests { get; set; }
        [InverseProperty("OrganicUnit")]
        public virtual ICollection<DocumentalSerie> DocumentalSeries { get; set; }
        [InverseProperty("OrganicUnit")]
        public virtual ICollection<UserPosition> UserPositions { get; set; }
    }
}
