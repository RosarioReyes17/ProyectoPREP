using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class VwPrepGestionUsuario
{
    public int IdUsuario { get; set; }

    public string NombreApellidos { get; set; } = null!;

    public string Usuario { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string PasswordExpira { get; set; } = null!;

    public DateTime? PasswordExpiraFecha { get; set; }

    public string Activo { get; set; } = null!;

    public string? IdDeptoDepend { get; set; }

    public string? Identificador { get; set; }

    public string? NombreCentro { get; set; }

    public string? Provincia { get; set; }

    public string? Srs { get; set; }

    public int? RolesId { get; set; }

    public string? Roles { get; set; }
}
