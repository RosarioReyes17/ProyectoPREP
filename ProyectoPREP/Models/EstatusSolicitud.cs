using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class EstatusSolicitud
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<TblPrepDemanda> TblPrepDemanda { get; set; } = new List<TblPrepDemanda>();
}
