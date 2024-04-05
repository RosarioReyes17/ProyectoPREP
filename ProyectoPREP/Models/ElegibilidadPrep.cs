using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class ElegibilidadPrep
{
    public int Id { get; set; }

    public string? SeronegativoVih { get; set; }

    public DateTime? FechaPruebaVih { get; set; }

    public DateTime FechaEntregaVih { get; set; }

    public string? ResultadoPruebaVih { get; set; }

    public string? RiesgoInfeccionVih { get; set; }

    public string? AclaramientoCreatinina { get; set; }

    public string? ResultadoCreatinina { get; set; }

    public string? CreatininaValor { get; set; }

    public DateTime? FechaResultadoCreatinina { get; set; }

    public int? Estatus { get; set; }

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

    public string? Hemograma { get; set; }

    public string? Urea { get; set; }

    public virtual FormularioPrep FormularioPrep { get; set; } = null!;

    public virtual ICollection<It> Its { get; set; } = new List<It>();

    public virtual ICollection<Seguimiento> Seguimientos { get; set; } = new List<Seguimiento>();

    public virtual ICollection<TratamientoPrep> TratamientoPreps { get; set; } = new List<TratamientoPrep>();
}
