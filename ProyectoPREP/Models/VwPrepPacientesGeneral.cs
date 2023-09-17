using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class VwPrepPacientesGeneral
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

    public string? ComoTeConsideras { get; set; }

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
}
