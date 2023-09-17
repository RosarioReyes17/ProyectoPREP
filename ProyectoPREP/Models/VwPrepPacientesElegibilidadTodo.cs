using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class VwPrepPacientesElegibilidadTodo
{
    public int PacienteId { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? Documento { get; set; }

    public string? Nacionalidad { get; set; }

    public int? Edad { get; set; }

    public decimal? Peso { get; set; }

    public decimal? TallaPies { get; set; }

    public decimal? TallaPulgadas { get; set; }

    public string Sexo { get; set; } = null!;

    public DateTime FechaIngresoSai { get; set; }

    public string? Descendiente { get; set; }

    public string? NacionalidadMadre { get; set; }

    public string? EnRiesgo { get; set; }

    public string? ProvinciaResidencia { get; set; }

    public string? MunicipioResidencia { get; set; }

    public string? Ars { get; set; }

    public string? Regimen { get; set; }

    public string? Usuario { get; set; }

    public int? IdCentro { get; set; }

    public string? Centro { get; set; }

    public string? IdRegion { get; set; }

    public string? Srs { get; set; }

    public string? Provincia { get; set; }

    public string? SeronegativoVih { get; set; }

    public DateTime? FechaPruebaVih { get; set; }

    public DateTime? FechaEntregaVih { get; set; }

    public string? ResultadoPruebaVih { get; set; }

    public string? RiesgoInfeccionVih { get; set; }

    public string? AclaramientoCreatinina { get; set; }

    public string? ResultadoCreatinina { get; set; }

    public string? CreatininaValor { get; set; }

    public DateTime? FechaResultadoCreatinina { get; set; }

    public string? MotivoRechazo { get; set; }

    public DateTime? FechaElegibilidad { get; set; }

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

    public DateTime? FechaReintegro { get; set; }
}
