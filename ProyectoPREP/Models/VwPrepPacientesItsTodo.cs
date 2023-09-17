using System;
using System.Collections.Generic;

namespace ProyectoPREP.Models;

public partial class VwPrepPacientesItsTodo
{
    public int Id { get; set; }

    public string? Sifilis { get; set; }

    public DateTime? SifilisFecha { get; set; }

    public string? HbsAg { get; set; }

    public DateTime? HbsAgFecha { get; set; }

    public string? HepatitisC { get; set; }

    public DateTime? HepatitisCFecha { get; set; }

    public string? ItsDiagnosticoPresuntivo { get; set; }

    public int ElegibilidadPrepId { get; set; }

    public bool? SecrecionUretral { get; set; }

    public bool? SecrecionVaginal { get; set; }

    public bool? UlceraGenital { get; set; }

    public bool? VerrugasGenitales { get; set; }

    public bool? Nr { get; set; }

    public string? Hemograma { get; set; }

    public string? Urea { get; set; }
}
