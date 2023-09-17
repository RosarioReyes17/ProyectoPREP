using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class VwEstablecimiento
{
    public int IdCentro { get; set; }

    public string? Centro { get; set; }

    public string? IdRegion { get; set; }

    public string? Srs { get; set; }

    public string? Provincia { get; set; }
}
