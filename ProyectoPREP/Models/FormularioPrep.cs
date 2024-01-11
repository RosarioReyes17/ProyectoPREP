using System;
using System.Collections.Generic;
using ProyectoPREP.Proc;

namespace ProyectoPREP.Models;

public partial class FormularioPrep
{
    public int Id { get; set; }

    public string? TienesRelacionesCon { get; set; }

    public string? DrogasIlicitas { get; set; }

    public string? SexoPorBienes { get; set; }

    public string? HaTenidoIts { get; set; }

    public string? HaRecibidoProfilaxisPostExposicion { get; set; }

    public string? SexoPorBienesPareja { get; set; }

    public string? SexoSinProteccion { get; set; }

    public string? CantParejasSexuales { get; set; }

    public int? DatosGeneralesId { get; set; }

    public string? SexoConVihpositivo { get; set; }

    public int? Secuencia { get; set; }

    public string? Usuario { get; set; } = null!;

    public string? UsuarioModifico { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public DateTime? FechaReintegro { get; set; }

    public virtual DatosGenerale DatosGenerales { get; set; } = null!;

    public virtual ICollection<ElegibilidadPrep> ElegibilidadPreps { get; set; } = new List<ElegibilidadPrep>();
}
