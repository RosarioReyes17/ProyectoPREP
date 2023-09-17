using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class VwMunicipio
{
    public string IdProvincia { get; set; } = null!;

    public string IdMunicipio { get; set; } = null!;

    public string? Municipio { get; set; }

    public string? IdMunicipioJce { get; set; }
}
