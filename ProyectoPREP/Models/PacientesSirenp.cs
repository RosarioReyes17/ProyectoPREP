using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class PacientesSirenp
{
    public int IdPaciente { get; set; }

    public string? CedPas { get; set; }

    public DateTime? PruebaFecha { get; set; }

    public string? ResultadoFinal { get; set; }
}
