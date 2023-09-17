using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class VwProvincia
{
    public string IdProvincia { get; set; } = null!;

    public string? Provincia { get; set; }

    public string? IdRegion { get; set; }

    public string? IdProvinciaJce { get; set; }
}
