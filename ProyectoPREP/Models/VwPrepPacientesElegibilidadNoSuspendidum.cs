using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class VwPrepPacientesElegibilidadNoSuspendidum
{
    public int Id { get; set; }

    public int? EstatusId { get; set; }

    public string? Estatus { get; set; }

    public int FormularioPrepId { get; set; }
}
