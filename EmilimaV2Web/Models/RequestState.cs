using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmilimaV2Web.Models
{
    [Table("request_state", Schema = "emilima")]
    [Index("Name", Name = "request_state$name_UNIQUE", IsUnique = true)]
    public partial class RequestState
    {
        public RequestState()
        {
            DocumentRequests = new HashSet<DocumentRequest>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(45)]
        public string Name { get; set; } = null!;

        [InverseProperty("State")]
        public virtual ICollection<DocumentRequest> DocumentRequests { get; set; }
    }
}
