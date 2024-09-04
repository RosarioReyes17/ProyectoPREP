using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class TblPrepDemanda
{
    public int IdPaciente { get; set; }

    public DateTime FechaIngresoSai { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string? TieneDocumentos { get; set; }

    public string? Documento { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public int? Nacionalidad { get; set; }

    public string? Descendiente { get; set; }

    public int? NacionalidadMadre { get; set; }

    public string? Direccion { get; set; }

    public string? Sector { get; set; }

    public int? ProvinciaResidencia { get; set; }

    public int? MunicipioResidencia { get; set; }

    public int? Edad { get; set; }

    public decimal? Peso { get; set; }

    public string? Telefono { get; set; }

    public string Genero { get; set; } = null!;

    public string Sexo { get; set; } = null!;

    public string? Ars { get; set; }

    public string? NombreArs { get; set; }

    public string? Regimen { get; set; }

    public string? ContactoConfianza { get; set; }

    public string? NombreContacto { get; set; }

    public string? TelefonoContacto { get; set; }

    public int? Parentesco { get; set; }

    public string? TienesRelacionesCon { get; set; }

    public string? DrogasIlicitas { get; set; }

    public string? SexoPorBienes { get; set; }

    public string? SexoPorBienesPareja { get; set; }

    public string? SexoSinProteccion { get; set; }

    public string? CantParejasSexuales { get; set; }

    public string? SexoConVihpositivo { get; set; }

    public string? SeronegativoVih { get; set; }

    public DateTime? FechaPruebaVih { get; set; }

    public DateTime? FechaEntregaVih { get; set; }

    public string? ResultadoPruebaVih { get; set; }

    public string? ValorCreatinina { get; set; }

    public string? ResultadoCreatinina { get; set; }

    public DateTime? FechaCreatinina { get; set; }

    public string? AclaramientoCreatinina { get; set; }

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

    public DateTime? FechaInicioPrep { get; set; }

    public bool? PrepArvTdfFtc { get; set; }

    public bool? PrepArvTdf3tc { get; set; }

    public bool? PrepArvTafFtc { get; set; }

    public string? MesesPrescripcion { get; set; }

    public string? Observaciones { get; set; }

    public DateTime? FechaProximoSeguimiento { get; set; }

    public string Usuario { get; set; } = null!;

    public int IdDeptoDepend { get; set; }

    public string? UsuarioModifico { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<TblPrepDemandaSeguimiento> TblPrepDemandaSeguimientos { get; set; } = new List<TblPrepDemandaSeguimiento>();
}
