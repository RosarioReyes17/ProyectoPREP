using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class Seccione
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Orden { get; set; }

    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();
}
