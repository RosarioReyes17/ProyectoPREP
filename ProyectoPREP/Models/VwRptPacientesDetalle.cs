using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class VwRptPacientesDetalle
{
    public string? Srs { get; set; }

    public string? Provincia { get; set; }

    public string? NombreCentro { get; set; }

    public int Id { get; set; }

    public string Sexo { get; set; } = null!;

    public string Nacionalidad { get; set; } = null!;

    public DateTime? FechaNacimiento { get; set; }

    public string? ProvinciaResidencia { get; set; }

    public string? MunicipioResidencia { get; set; }

    public string? TieneDocumentos { get; set; }

    public string? TipoDocumento { get; set; }

    public string? Documento { get; set; }

    public string? Ars { get; set; }

    public DateTime FechaIngresoSai { get; set; }

    public DateTime? FechaSeguimiento { get; set; }

    public string Transf { get; set; } = null!;

    public string Estatus { get; set; } = null!;

    public string Tarv { get; set; } = null!;

    public string? MesesPrescripcion { get; set; }

    public string? ResultadoPruebaVih { get; set; }

    public DateTime? FechaPruebaVih { get; set; }

    public string? ResultadoCreatinina { get; set; }

    public string FechaCreatinina { get; set; } = null!;

    public string? Sifilis { get; set; }

    public DateTime? SifilisFecha { get; set; }

    public string? HbsAg { get; set; }

    public DateTime? HbsAgFecha { get; set; }

    public string? HepatitisC { get; set; }

    public DateTime? HepatitisCFecha { get; set; }

    public string? Urea { get; set; }

    public string FechaUrea { get; set; } = null!;

    public string? Hemograma { get; set; }

    public string FechaHemograma { get; set; } = null!;

    public bool? SecrecionUretral { get; set; }

    public bool? SecrecionVaginal { get; set; }

    public bool? UlceraGenital { get; set; }

    public bool? VerrugasGenitales { get; set; }

    public bool? Linfadenopatias { get; set; }

    public bool? FiebreDesconocida { get; set; }

    public bool? DiarreaProlongada { get; set; }

    public bool? ErupcionesPiel { get; set; }

    public bool? InfeccionesRecurrentes { get; set; }

    public bool? HepatoEsplenomegalia { get; set; }

    public string? TienesRelacionesCon { get; set; }

    public string? DrogasIlicitas { get; set; }

    public string? SexoPorBienes { get; set; }

    public string? SexoPorBienesPareja { get; set; }

    public string? SexoSinProteccion { get; set; }

    public string? CantParejasSexuales { get; set; }

    public string? SexoConVihpositivo { get; set; }

    public string? IdRegion { get; set; }

    public int IdDeptoDepend { get; set; }
}
