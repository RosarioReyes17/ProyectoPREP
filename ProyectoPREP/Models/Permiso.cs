using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class Permiso
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Url { get; set; } = null!;

    public int SeccionId { get; set; }

    public string? Tipo { get; set; }

    public bool? Estatus { get; set; }

    public virtual Seccione Seccion { get; set; } = null!;

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
