using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPREP.Models;

namespace ProyectoPREP.Controllers
{
    public class SeguimientosController : Controller
    {

        DbPrepContext db;

        public SeguimientosController(DbPrepContext _db)
        {
            this.db = _db;
        }
        // GET: SeguimientosController
        [HttpPost]
        public JsonResult CreatininaMenor60(int IdDatos, Seguimiento seguimiento)
        {

            var formulario = db.FormularioPreps.Where(X => X.DatosGeneralesId == IdDatos).FirstOrDefault();

            var elegibilidad = db.ElegibilidadPreps.FirstOrDefault(x => x.FormularioPrepId == formulario.Id);

            elegibilidad.Estatus = 6;

            seguimiento.Id = 0;
            seguimiento.ElegibilidadPrepId = elegibilidad.Id;
            seguimiento.SeguimimientoPruebaId = 5;
            seguimiento.Usuario = "1";


            db.Entry(elegibilidad).State = EntityState.Modified;
            db.Seguimientos.Add(seguimiento);
            db.SaveChanges();

            var result = new
            {
                estatus = true
            };
            return Json(result);
        }

        [HttpPost]
        public JsonResult VIHPositivo(int IdDatos, Seguimiento seguimiento)
        {
            bool status = true;

            var formu = db.FormularioPreps.FirstOrDefault(X => X.DatosGeneralesId == IdDatos);
            var elegibilidad = db.ElegibilidadPreps.FirstOrDefault(x => x.FormularioPrepId == formu.Id);

            elegibilidad.Estatus = 6;

            seguimiento.Id = 0;
            seguimiento.ElegibilidadPrepId = elegibilidad.Id;
            seguimiento.SeguimimientoPruebaId = 5;
            seguimiento.Usuario = "1";


            db.Entry(elegibilidad).State = EntityState.Modified;
            db.Seguimientos.Add(seguimiento);
            db.SaveChanges();



            var result = new { status };
            return Json(result);
        }


        public ActionResult SeguimientoPrep(int id)
        {
            var datos = db.DatosGenerales.FirstOrDefault(d => d.Id == id);
            var formu = db.FormularioPreps.FirstOrDefault(d => d.DatosGeneralesId == id);
            var elegi = db.ElegibilidadPreps.FirstOrDefault(d => d.FormularioPrepId == formu.Id);


            ViewBag.Nombre = datos.Nombres + " " + datos.Apellidos;
            ViewBag.IdDatos = datos.Id;

            ViewBag.Peso = datos.Peso;
            ViewBag.Edad = Convert.ToDecimal(datos.Edad);
            ViewBag.Sexo = datos.Sexo;
            ViewBag.Genero = datos.Genero;


         
            return View();
        }

        [HttpPost]
        public ActionResult SeguimientoPrep(int IdDatos, Seguimiento seguimiento) 
        {
            var formulario = db.FormularioPreps.FirstOrDefault(x => x.DatosGeneralesId == IdDatos);
            var elegibilidad = db.ElegibilidadPreps.FirstOrDefault(x => x.FormularioPrepId == formulario.Id);

            seguimiento.Id = 0;
            seguimiento.ElegibilidadPrepId = elegibilidad.Id;
            seguimiento.SeguimimientoPruebaId = 5;
            seguimiento.Usuario = "1";

            elegibilidad.Estatus = 6;



            db.Entry(elegibilidad).State = EntityState.Modified;
            db.Seguimientos.Add(seguimiento);
            db.SaveChanges();

            return RedirectToAction("DatosGeneralesPorAprobado", "DatosGenerales");
        }


        [HttpGet]
        public ActionResult SeguimientoVer(int id)
        {
            var datos = db.DatosGenerales.FirstOrDefault(d => d.Id == id);
            var formu = db.FormularioPreps.FirstOrDefault(d => d.DatosGeneralesId == id);
            var elegi = db.ElegibilidadPreps.FirstOrDefault(d => d.FormularioPrepId == formu.Id);
            var segui = db.Seguimientos.Where(d => d.ElegibilidadPrepId == elegi.Id).ToList();
            var nacionalidad = db.VwNacionalidads.FirstOrDefault(x => Convert.ToInt32(x.IdNacionalidad) == datos.Nacionalidad);


            ViewBag.Nombre = datos.Nombres;
            ViewBag.Apellido = datos.Apellidos;

            ViewBag.Sexo = datos.Sexo;
            ViewBag.nacionalidad = nacionalidad.Nacionalidad;

            return View(segui);
        }


    }
}
