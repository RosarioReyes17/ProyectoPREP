using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class PacientesSai
{
    public int IdPaciente { get; set; }

    public string? FappsKey { get; set; }

    public string NoExpediente { get; set; } = null!;

    public string? NoIdSiai { get; set; }

    public DateTime? FechaLlenado { get; set; }

    public DateTime? FechaUltimaVisitaSai { get; set; }

    public int? CmProcedencia { get; set; }

    public int Sai { get; set; }

    public DateTime FechaIngreso { get; set; }

    public bool TieneCedula { get; set; }

    public string? Cedula { get; set; }

    public bool? TienePasaporte { get; set; }

    public string? Pasaporte { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Sexo { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string? Direccion { get; set; }

    public string? TelefonoRes { get; set; }

    public string? TelefonoCel { get; set; }

    public bool? Estatus { get; set; }

    public string Nacionalidad { get; set; } = null!;

    public string Provincia { get; set; } = null!;

    public string Municipio { get; set; } = null!;

    public string? Ars { get; set; }

    public bool TieneArs { get; set; }

    public bool AfiliadoSdss { get; set; }

    public string? Regimen { get; set; }

    public decimal? LabResultadoCd4 { get; set; }

    public DateTime? LabFechaResultadoCd4 { get; set; }

    public decimal? LabResultadoCargaViral { get; set; }

    public DateTime? LabFechaResultadoCargaVira { get; set; }

    public DateTime? InicioPrimerArvFecha { get; set; }

    public DateTime? InicioArvActual { get; set; }

    public int? CriterioElegibilidadIniciarArv { get; set; }

    public string? RegistradoPor { get; set; }

    public DateTime? RegistradoFecha { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? ModificadoFecha { get; set; }

    public int? PruebaSolicitada { get; set; }

    public int? DiagnosticoTb { get; set; }

    public DateTime? FechaInicioTxTb { get; set; }

    public int? EstatusTratamientoTb { get; set; }

    public DateTime? FechaFinalizaTxTb { get; set; }

    public int? TerapiaIsoniacidaTpi { get; set; }

    public DateTime? FechaInicioTpi { get; set; }

    public DateTime? FechaFinalizaTpi { get; set; }

    public int? TerapiaTrimetropinTmpSmx { get; set; }

    public DateTime? FechaInicioTmpSmx { get; set; }

    public DateTime? FechaFinalizaTmpSmx { get; set; }

    public int? TerapiaAzitromicina { get; set; }

    public DateTime? FechaInicioAzitromicina { get; set; }

    public DateTime? FechaFinalizaAzitromicina { get; set; }

    public int? UlceraGenital { get; set; }

    public int? SecrecionUretral { get; set; }

    public int? Sifilis { get; set; }

    public int? HepatitisB { get; set; }

    public int? HepatitisC { get; set; }

    public DateTime? FechaProximaCita { get; set; }

    public string? BioHand { get; set; }

    public string? BioHandFinger { get; set; }
}
