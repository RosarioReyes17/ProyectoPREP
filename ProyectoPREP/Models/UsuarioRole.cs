using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class UsuarioRole
{
    public int IdUsuario { get; set; }

    public int RolesId { get; set; }

    public int? IdCentro { get; set; }

    public virtual Role Roles { get; set; } = null!;
}
