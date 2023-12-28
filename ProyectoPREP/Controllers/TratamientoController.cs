using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPREP.Models;

namespace ProyectoPREP.Controllers
{
    public class TratamientoController : Controller
    {
        // GET: TratamientoController
        DbPrepContext db;

        public TratamientoController(DbPrepContext _db)
        {
            this.db = _db;
        }
        public ActionResult InicioTratamiento(int id)
        {

            var datos = db.DatosGenerales.FirstOrDefault(x => x.Id == id);
            //var formulario = db.FormularioPreps.FirstOrDefault(x => x.DatosGeneralesId == id);
            //var elegibilidad = db.ElegibilidadPreps.FirstOrDefault(x=>x.FormularioPrepId == formulario.Id);
            ViewBag.idDatos = datos.Id;
            ViewBag.nombre = datos.Nombres;
            ViewBag.apellido = datos.Apellidos;
            ViewBag.documento = datos.Documento;
            //ViewBag.fechaPrep = datos.FechaIngresoSai.ToString("yyyy-MM-dd");
            return View();
        }

        [HttpPost]
        public ActionResult InicioTratamiento(int idDatos, TratamientoPrep tratamiento, DateTime? FechaSeguimiento
            ,string MesesPrescripcion, string Observaciones, DateTime? FechaInicio
            , bool PrepArvTdfFtc, bool PrepArvTdf3tc, bool PrepArvTafFtc)
        {

            //var datos = db.DatosGenerales.FirstOrDefault(x => x.Id == idDatos);
            var formulario = db.FormularioPreps.FirstOrDefault(x => x.DatosGeneralesId == idDatos);
            var elegibilidad = db.ElegibilidadPreps.FirstOrDefault(x=>x.FormularioPrepId == formulario.Id);
            var seguimientos = db.Seguimientos.FirstOrDefault(x => x.ElegibilidadPrepId == elegibilidad.Id);

            tratamiento.ElegibilidadPrepId = elegibilidad.Id;

            seguimientos.FechaProximoSeguimiento = FechaSeguimiento;
            seguimientos.Usuario = "1";
            seguimientos.SeguimimientoPruebaId = 1;
            seguimientos.FechaSeguimiento = FechaInicio;
            seguimientos.MesesPrescripcion = MesesPrescripcion;
            seguimientos.Observaciones = Observaciones;
            seguimientos.PrepArvTdfFtc = PrepArvTdfFtc;
            seguimientos.PrepArvTdf3tc = PrepArvTdf3tc;
            seguimientos.PrepArvTafFtc = PrepArvTafFtc;


            elegibilidad.Estatus = 4;
            
            tratamiento.Id = 0;

            db.TratamientoPreps.Add(tratamiento);
            db.Entry(elegibilidad).State = EntityState.Modified;
            db.Entry(seguimientos).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("DatosGeneralesPorTratamiento", "DatosGenerales");
        }

        [HttpPost]
        public JsonResult rechazarPaciente(int idDatos, string ObservacionesModal)
        {
            bool estatus = true;
            var formulario = db.FormularioPreps.FirstOrDefault(x => x.DatosGeneralesId == idDatos);
            var elegibilidad = db.ElegibilidadPreps.FirstOrDefault(x=>x.FormularioPrepId == formulario.Id);

            elegibilidad.Estatus = 6;

            var tratamiento = new TratamientoPrep();
            tratamiento.Observaciones = ObservacionesModal;
            tratamiento.ElegibilidadPrepId = elegibilidad.Id;

            db.Entry(elegibilidad).State = EntityState.Modified;
            db.TratamientoPreps.Add(tratamiento);
            db.SaveChanges();


            var result = new
            {
                estatus = estatus
            };
            return Json(result);
        }

       
   
      
     
    }
}
