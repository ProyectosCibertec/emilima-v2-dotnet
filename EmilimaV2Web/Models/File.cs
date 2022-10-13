using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmilimaV2Web.Models
{
    [Table("file", Schema = "emilima")]
    public partial class File
    {
        public File()
        {
            Documents = new HashSet<Document>();
            User1s = new HashSet<User1>();
        }

        [Key]
        [Column("id")]
        [StringLength(48)]
        [Display(Name = "Id")]
        public string Id { get; set; } = null!;
        [Column("filename")]
        [Display(Name = "Archivo")]
        public string Filename { get; set; } = null!;

        [InverseProperty("File")]
        public virtual ICollection<Document> Documents { get; set; }
        [InverseProperty("Photo")]
        public virtual ICollection<User1> User1s { get; set; }
    }
}
