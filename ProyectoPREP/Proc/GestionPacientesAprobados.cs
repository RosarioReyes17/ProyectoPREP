﻿namespace ProyectoPREP.Proc
{
    public class GestionPacientesAprobados
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombreCentro { get; set; }
        public DateTime Fecha_Ingreso_SAI { get; set; }
        public string Estatus_Solicitud { get; set; }
        public int DeptoDependDestino { get; set; }
        public int DeptoDependOriginal { get; set; }
    }
}
