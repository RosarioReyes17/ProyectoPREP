namespace ProyectoPREP.Models
{
	public class DatosGenerales
	{
        public int ID_PAIS { get; set; }
        public string NOMBRE_CORTO_ES { get; set; }
        public int Id { get; set; }
        public int ElegibilidadPrepId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public string Documento { get; set; }
        public DateTime Fecha_Ingreso_SAI { get; set; }
        public int Estatus { get; set; }
        public int IdDeptoDepend { get; set; }
        public bool Condicion { get; set; }
    }
}
