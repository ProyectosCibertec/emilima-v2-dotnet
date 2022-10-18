using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmilimaV2Web.Models;

[Table("usuario", Schema = "emilima")]
public partial class Usuario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
}
