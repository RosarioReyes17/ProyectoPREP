using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class VwPrepPacientesElegibilidadUltimo
{
    public int Id { get; set; }

    public string? SeronegativoVih { get; set; }

    public DateTime? FechaPruebaVih { get; set; }

    public DateTime? FechaEntregaVih { get; set; }

    public string? ResultadoPruebaVih { get; set; }

    public string? RiesgoInfeccionVih { get; set; }

    public string? AclaramientoCreatinina { get; set; }

    public string? ResultadoCreatinina { get; set; }

    public string? CreatininaValor { get; set; }

    public DateTime? FechaResultadoCreatinina { get; set; }

    public string? Estatus { get; set; }

    public string? MotivoRechazo { get; set; }

    public DateTime? FechaElegibilidad { get; set; }

    public int FormularioPrepId { get; set; }

    public string? SignosSintomas { get; set; }

    public bool? FiebreDesconocida { get; set; }

    public bool? DiarreaProlongada { get; set; }

    public bool? ErupcionesPiel { get; set; }

    public bool? InfeccionesRecurrentes { get; set; }

    public bool? HepatoEsplenomegalia { get; set; }

    public bool? Linfadenopatias { get; set; }

    public string? CargaViralPcr { get; set; }

    public string? ResultadoCargaViralPcr { get; set; }

    public DateTime? FechaPruebaPcr { get; set; }

    public DateTime? FechaVisitaPcr { get; set; }

    public string Usuario { get; set; } = null!;

    public DateTime? FechaReintegro { get; set; }
}
