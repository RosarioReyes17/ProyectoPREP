using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class VwRptPacientesTotale
{
    public string? Srs { get; set; }

    public string? Provincia { get; set; }

    public string? Municipio { get; set; }

    public string? ServicioSai { get; set; }

    public int? Pacientes { get; set; }

    public int PacientesTarv { get; set; }

    public int? PacientesSinDocumento { get; set; }

    public int? PacientesDominicanos { get; set; }

    public int? PacientesOtrasNacionalidades { get; set; }

    public int? PacientesMasculinos { get; set; }

    public int? PacientesFemeninos { get; set; }

    public int PacientesEmbarazadas { get; set; }

    public int? PacientesAsegurados { get; set; }

    public string? IdRegion { get; set; }
}
