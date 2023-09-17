using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class VwPrepPacientesTratamientosUltimo
{
    public int Id { get; set; }

    public DateTime? FechaInicio { get; set; }

    public bool? PrepArvTdfFtc { get; set; }

    public bool? PrepArvTdf3tc { get; set; }

    public bool? PrepArvTafFtc { get; set; }

    public DateTime? PrepSuspendida { get; set; }

    public string? MotivosInterrupcionPrep { get; set; }

    public string? EstadoVihAlInterrumpir { get; set; }

    public int ElegibilidadPrepId { get; set; }

    public DateTime? FechaSeguimiento { get; set; }

    public string? MesesPrescripcion { get; set; }

    public string? Observaciones { get; set; }
}
