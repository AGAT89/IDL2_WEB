using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IDL2_WEB;

[Table("persona")]
public partial class Persona
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nombre")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [Column("apellido_paterno")]
    [StringLength(30)]
    [Unicode(false)]
    public string? ApellidoPaterno { get; set; }

    [Column("apellido_materno")]
    [StringLength(30)]
    [Unicode(false)]
    public string? ApellidoMaterno { get; set; }

    [Column("fecha_nacimiento")]
    public DateOnly? FechaNacimiento { get; set; }
}
