using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class GestionPaciente
{
    public int Id { get; set; }

    public int DeptoDependOriginal { get; set; }

    public int? DeptoDependDestino { get; set; }

    public int Estatus { get; set; }

    public int UsuarioEnvia { get; set; }

    public int? UsuarioRecibe { get; set; }

    public DateTime FechaEnvio { get; set; }

    public DateTime? FechaRecepcion { get; set; }

    public string EstatusSolicitud { get; set; } = null!;

    public int DatosGeneralesId { get; set; }

    public virtual DatosGenerale DatosGenerales { get; set; } = null!;
}
