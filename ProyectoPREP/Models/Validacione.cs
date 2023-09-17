using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class Validacione
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public bool Estatus { get; set; }
}
