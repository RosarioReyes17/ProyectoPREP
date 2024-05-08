using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<UsuarioRole> UsuarioRoles { get; set; } = new List<UsuarioRole>();

    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();
}
