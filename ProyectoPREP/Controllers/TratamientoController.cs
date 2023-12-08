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
        public ActionResult InicioTratamiento(int idDatos, TratamientoPrep tratamiento, DateTime FechaSeguimiento)
        {

            //var datos = db.DatosGenerales.FirstOrDefault(x => x.Id == idDatos);
            var formulario = db.FormularioPreps.FirstOrDefault(x => x.DatosGeneralesId == idDatos);
            var elegibilidad = db.ElegibilidadPreps.FirstOrDefault(x=>x.FormularioPrepId == formulario.Id);

            tratamiento.ElegibilidadPrepId = elegibilidad.Id;

            var seguimiento = new Seguimiento();
            seguimiento.ElegibilidadPrepId = elegibilidad.Id;
            seguimiento.FechaSeguimiento = FechaSeguimiento;
            seguimiento.Usuario = "1";
            seguimiento.SeguimimientoPruebaId = 1;

            elegibilidad.Estatus = 4;
            tratamiento.Id = 0;

            db.TratamientoPreps.Add(tratamiento);
            db.Seguimientos.Add(seguimiento);
            
            db.Entry(elegibilidad).State = EntityState.Modified;
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

        // GET: TratamientoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TratamientoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TratamientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TratamientoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TratamientoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TratamientoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TratamientoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
