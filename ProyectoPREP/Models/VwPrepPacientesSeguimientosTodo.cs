using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class VwPrepPacientesSeguimientosTodo
{
    public int Id { get; set; }

    public int ElegibilidadPrepId { get; set; }

    public string? SignosVitalesTa { get; set; }

    public string? SignosVitalesFc { get; set; }

    public string? SignosVitalesFr { get; set; }

    public int? Peso { get; set; }

    public decimal? TallaPulgadas { get; set; }

    public decimal? TallaPies { get; set; }

    public string? ResultadoPruebaVih { get; set; }

    public string? ConsultaSignosInfeccion { get; set; }

    public string? ResultadoCreatinina { get; set; }

    public string? NuevaItsdiagnosticada { get; set; }

    public string? AdherenciaCantidadComprimidos { get; set; }

    public string? AsesoramientoAdherencia { get; set; }

    public string? AsesoramientoRiesgos { get; set; }

    public string? EntregaCondones { get; set; }

    public string? Embarazada { get; set; }

    public bool? PrepArvTdfFtc { get; set; }

    public bool? PrepArvTdf3tc { get; set; }

    public bool? PrepArvTafFtc { get; set; }

    public string? MesesPrescripcion { get; set; }

    public DateTime? FechaSeguimiento { get; set; }

    public DateTime? FechaProximoSeguimiento { get; set; }

    public string? Observaciones { get; set; }

    public string? EfectosSecundarios { get; set; }

    public DateTime? FechaPruebaVih { get; set; }

    public string? Lactante { get; set; }

    public string? Sifilis { get; set; }

    public DateTime? SifilisFecha { get; set; }

    public string? HbsAg { get; set; }

    public DateTime? HbsAgFecha { get; set; }

    public string? HepatitisC { get; set; }

    public DateTime? HepatitisCFecha { get; set; }

    public string? ItsDiagnosticoPresuntivo { get; set; }

    public bool? SecrecionUretral { get; set; }

    public bool? SecrecionVaginal { get; set; }

    public bool? UlceraGenital { get; set; }

    public bool? VerrugasGenitales { get; set; }

    public bool? FiebreDesconocida { get; set; }

    public bool? DiarreaProlongada { get; set; }

    public bool? ErupcionesPiel { get; set; }

    public bool? InfeccionesRecurrentes { get; set; }

    public bool? HepatoEsplenomegalia { get; set; }

    public bool? Linfadenopatias { get; set; }

    public int SeguimimientoPruebaId { get; set; }

    public string? Hemograma { get; set; }

    public string? Urea { get; set; }

    public string Usuario { get; set; } = null!;

    public DateTime? FechaRegistroSeguimiento { get; set; }
}
