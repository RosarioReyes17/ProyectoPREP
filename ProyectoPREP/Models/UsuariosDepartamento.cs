using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class UsuariosDepartamento
{
    public int IdUsuario { get; set; }

    public string? IdDeptoDepend { get; set; }

    public string? DeptoDepend { get; set; }

    public string? Identificador { get; set; }

    public int Secuencia { get; set; }

    public string? IdRegion { get; set; }

    public string? Region { get; set; }

    public string Suspendido { get; set; } = null!;

    public string? DeptoDependSid { get; set; }

    public string? NameEess { get; set; }

    public string? Municipio { get; set; }

    public string? Provincia { get; set; }
}
