using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Cedula { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? PasswordConfirm { get; set; }

    public string PasswordExpira { get; set; } = null!;

    public DateTime? PasswordExpiraFecha { get; set; }

    public string? Token { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string NombreApellidos { get; set; } = null!;

    public string IdGenero { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? TelefonoTrabajo { get; set; }

    public string? TelefonoTrabajoExt { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public int IdRol { get; set; }

    public string Activo { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public string? UsuarioRegistro { get; set; }

    public DateTime? FechaUltimoAcceso { get; set; }

    public TimeSpan? FechaUltimoAccesoHora { get; set; }
}
