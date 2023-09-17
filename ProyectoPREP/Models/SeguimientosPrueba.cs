using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class SeguimientosPrueba
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public bool? Hemograma { get; set; }

    public bool? Urea { get; set; }

    public bool? Creatinina { get; set; }

    public bool? Vdrl { get; set; }

    public bool? HepatitisB { get; set; }

    public bool? HepatitisC { get; set; }

    public bool? Vih { get; set; }
}
