using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class VwNacionalidad
{
    public string IdNacionalidad { get; set; } = null!;

    public string Nacionalidad { get; set; } = null!;

    public int FilaId { get; set; }
}
