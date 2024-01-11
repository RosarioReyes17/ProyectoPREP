using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProyectoPREP.Models;

namespace ProyectoPREP.Proc;

public partial class DatosGenerale
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    public string? Nombres { get; set; } = null!;
    [Required(ErrorMessage = "Este campo es requerido")]


    public string? Apellidos { get; set; }

    public string? TieneDocumentos { get; set; }

    public string? TipoDocumento { get; set; }

    public string? Documento { get; set; }

    public int? Nacionalidad { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public int? Edad { get; set; }

    public decimal? Peso { get; set; }

    public decimal? TallaPies { get; set; }

    public decimal? TallaPulgadas { get; set; }

    public string? Genero { get; set; } = null!;

    public string? Sexo { get; set; } = null!;

    public string? Ocupacion { get; set; }

    public string? Direccion { get; set; }
    public DateTime FechaIngresoSai { get; set; }

    public string? ServicioSai { get; set; }

    public int? NacionalidadMadre { get; set; }

    public string? EnRiesgo { get; set; }

    public string? Sector { get; set; }

    public string? RegionSalud { get; set; }

    public int? ProvinciaResidencia { get; set; }

    public int? MunicipioResidencia { get; set; }

    public string? Descendiente { get; set; }

    //[Required(ErrorMessage = "Este campo es requerido")]

    public string? NombreContacto { get; set; }
    //[Required(ErrorMessage = "Este campo es requerido")]


    public string? TelefonoContacto { get; set; }

    public string? Ars { get; set; }

    public string? NombreArs { get; set; }

    public string? Regimen { get; set; }

    public int? Parentesco { get; set; }

    public string? Usuario { get; set; } = null!;

    public string? Telefono { get; set; }

    public int? IdDeptoDepend { get; set; }

    public string? UsuarioModifico { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<FormularioPrep> FormularioPreps { get; set; } = new List<FormularioPrep>();

    public virtual ICollection<GestionPaciente> GestionPacientes { get; set; } = new List<GestionPaciente>();
}
