using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class TblPrepDemandaSeguimiento
{
    public int IdSeguimiento { get; set; }

    public int? IdPaciente { get; set; }

    public DateTime? FechaSeguimiento { get; set; }

    public string? SignosVitalesTa { get; set; }

    public string? SignosVitalesFc { get; set; }

    public string? SignosVitalesFr { get; set; }

    public int? Peso { get; set; }

    public decimal? TallaPulgadas { get; set; }

    public decimal? TallaPies { get; set; }

    public string? ResultadoPruebaVih { get; set; }

    public DateTime? FechaPruebaVih { get; set; }

    public string? ConsultaSignosInfeccion { get; set; }

    public bool? Linfadenopatias { get; set; }

    public bool? FiebreDesconocida { get; set; }

    public bool? DiarreaProlongada { get; set; }

    public bool? ErupcionesPiel { get; set; }

    public bool? InfeccionesRecurrentes { get; set; }

    public bool? HepatoEsplenomegalia { get; set; }

    public string? Sifilis { get; set; }

    public DateTime? SifilisFecha { get; set; }

    public string? HbsAg { get; set; }

    public DateTime? HbsAgFecha { get; set; }

    public string? HepatitisC { get; set; }

    public DateTime? HepatitisCFecha { get; set; }

    public bool? RepeticionPrepPrescrita { get; set; }

    public bool? PrepArvTdfFtc { get; set; }

    public bool? PrepArvTdf3tc { get; set; }

    public bool? PrepArvTafFtc { get; set; }

    public string? MesesPrescripcion { get; set; }

    public string Usuario { get; set; } = null!;

    public int IdDeptoDepend { get; set; }

    public string? UsuarioModifico { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual TblPrepDemandum? IdPacienteNavigation { get; set; }
}
