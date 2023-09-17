using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class DbLog
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public DateTime FechaError { get; set; }
}
