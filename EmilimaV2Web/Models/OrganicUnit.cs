using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmilimaV2Web.Models;

[Table("organic_unit", Schema = "emilima")]
public partial class OrganicUnit
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(80)]
    public string Name { get; set; } = null!;

    [InverseProperty("OrganicUnit")]
    public virtual ICollection<DocumentRequest> DocumentRequests { get; } = new List<DocumentRequest>();

    [InverseProperty("OrganicUnit")]
    public virtual ICollection<DocumentalSerie> DocumentalSeries { get; } = new List<DocumentalSerie>();

    [InverseProperty("OrganicUnit")]
    public virtual ICollection<UserPosition> UserPositions { get; } = new List<UserPosition>();
}
