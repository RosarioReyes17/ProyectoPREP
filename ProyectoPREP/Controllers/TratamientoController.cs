using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPREP.Models;

namespace ProyectoPREP.Controllers
{
    [Authorize(Roles = "Administrador,Psicólogo Medicos")]

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
            ViewBag.Fecha = datos.FechaIngresoSai.ToString("yyyy-MM-dd");
            //ViewBag.fechaPrep = datos.FechaIngresoSai.ToString("yyyy-MM-dd");
            return View();
        }

        [HttpPost]
        public ActionResult InicioTratamiento(int idDatos, TratamientoPrep tratamiento, DateTime? FechaSeguimiento
            ,string MesesPrescripcion, string Observaciones, DateTime? FechaInicio
            , bool PrepArvTdfFtc, bool PrepArvTdf3tc, bool PrepArvTafFtc)
        {

            try
            {
                if (PrepArvTafFtc == false && PrepArvTdfFtc == false && PrepArvTdf3tc == false)
                {
                    TempData["ARV"] = "Debe de seleccionar una ARV Prescrita.";
                    var datos = db.DatosGenerales.FirstOrDefault(x => x.Id == idDatos);
                    //var formulario = db.FormularioPreps.FirstOrDefault(x => x.DatosGeneralesId == id);
                    //var elegibilidad = db.ElegibilidadPreps.FirstOrDefault(x=>x.FormularioPrepId == formulario.Id);
                    ViewBag.idDatos = datos.Id;
                    ViewBag.nombre = datos.Nombres;
                    ViewBag.apellido = datos.Apellidos;
                    ViewBag.documento = datos.Documento;
                    return View();
                }

                int idUser = Convert.ToInt32(User.GetUserId());

                var formulario = db.FormularioPreps.FirstOrDefault(x => x.DatosGeneralesId == idDatos);
                var elegibilidad = db.ElegibilidadPreps.FirstOrDefault(x => x.FormularioPrepId == formulario.Id);

                tratamiento.ElegibilidadPrepId = elegibilidad.Id;



                elegibilidad.Estatus = 4;
                elegibilidad.Usuario = Convert.ToString(idUser);
                tratamiento.Id = 0;

                db.TratamientoPreps.Add(tratamiento);
                db.Entry(elegibilidad).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("DatosGeneralesPorTratamiento", "DatosGenerales");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);//Revisar aqui
            }


            
        }

        [HttpPost]
        public JsonResult rechazarPaciente(int idDatos, string ObservacionesModal)
        {
            bool estatus = true;
            int idUser = Convert.ToInt32(User.GetUserId());

            var formulario = db.FormularioPreps.FirstOrDefault(x => x.DatosGeneralesId == idDatos);
            var elegibilidad = db.ElegibilidadPreps.FirstOrDefault(x=>x.FormularioPrepId == formulario.Id);

            elegibilidad.Estatus = 6;
            elegibilidad.Usuario= Convert.ToString(idUser);

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
