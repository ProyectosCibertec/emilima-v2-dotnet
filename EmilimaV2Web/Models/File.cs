using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmilimaV2Web.Models;

[Table("file", Schema = "emilima")]
public partial class File
{
    [Key]
    [Column("id")]
    [StringLength(48)]
    public string Id { get; set; } = null!;

    [Column("filename")]
    public string Filename { get; set; } = null!;

    [InverseProperty("File")]
    public virtual ICollection<Document> Documents { get; } = new List<Document>();

    [InverseProperty("Photo")]
    public virtual ICollection<User1> User1s { get; } = new List<User1>();
}
