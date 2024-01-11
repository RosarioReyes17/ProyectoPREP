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
        public JsonResult CreatininaMenor60(int IdDatos, Seguimiento seguimiento)
        {

            var formulario = db.FormularioPreps.Where(X => X.DatosGeneralesId == IdDatos).FirstOrDefault();

            var elegibilidad = db.ElegibilidadPreps.FirstOrDefault(x => x.FormularioPrepId == formulario.Id);
            var segui = db.Seguimientos.FirstOrDefault(x => x.ElegibilidadPrepId == elegibilidad.Id);


            using (DbPrepContext db = new DbPrepContext())
            {
                segui.FechaRegistroSeguimiento = seguimiento.FechaRegistroSeguimiento;
                segui.SignosVitalesTa = seguimiento.SignosVitalesTa;
                segui.SignosVitalesFc = seguimiento.SignosVitalesFc;
                segui.SignosVitalesFr = seguimiento.SignosVitalesFr;
                segui.Peso = seguimiento.Peso;
                segui.TallaPies = seguimiento.TallaPies;
                segui.TallaPulgadas = seguimiento.TallaPulgadas;
                segui.FechaPruebaVih = seguimiento.FechaPruebaVih;
                segui.ResultadoPruebaVih = seguimiento.ResultadoPruebaVih;
                segui.FechaRegistroSeguimiento = seguimiento.FechaRegistroSeguimiento;

                elegibilidad.Estatus = 6;
                //db.Entry(elegibilidad).State = EntityState.Modified;
                //db.Entry(segui).State = EntityState.Modified;
                //db.SaveChanges();

            }

            var result = new
            {
                estatus = true
            };
            return Json(result);
        }

        public JsonResult VIHPositivo(int IdDatos, Seguimiento seguimiento)
        {
            bool status = true;

            var formu = db.FormularioPreps.FirstOrDefault(X => X.DatosGeneralesId == IdDatos);
            var elegibilidad = db.ElegibilidadPreps.FirstOrDefault(x => x.FormularioPrepId == formu.Id);
            var segui = db.Seguimientos.FirstOrDefault(x => x.ElegibilidadPrepId == elegibilidad.Id);

            elegibilidad.Estatus = 6;

            using (DbPrepContext db = new DbPrepContext())
            {
                segui.FechaRegistroSeguimiento = seguimiento.FechaRegistroSeguimiento;
                segui.SignosVitalesTa = seguimiento.SignosVitalesTa;
                segui.SignosVitalesFc = seguimiento.SignosVitalesFc;
                segui.SignosVitalesFr = seguimiento.SignosVitalesFr;
                segui.Peso = seguimiento.Peso;
                segui.TallaPies = seguimiento.TallaPies;
                segui.TallaPulgadas = seguimiento.TallaPulgadas;
                segui.FechaPruebaVih = seguimiento.FechaPruebaVih;
                segui.ResultadoPruebaVih = seguimiento.ResultadoPruebaVih;
                segui.FechaRegistroSeguimiento = seguimiento.FechaRegistroSeguimiento;

                //db.Entry(elegibilidad).State = EntityState.Modified;
                //db.Entry(segui).State = EntityState.Modified;
                //db.SaveChanges();

            }

            var result = new { status };
            return Json(result);
        }


        public ActionResult SeguimientoPrep(int id)
        {
            var datos = db.DatosGenerales.FirstOrDefault(d => d.Id == id);
            var formu = db.FormularioPreps.FirstOrDefault(d => d.DatosGeneralesId == id);
            var elegi = db.ElegibilidadPreps.FirstOrDefault(d => d.FormularioPrepId == formu.Id);
            var segui = db.Seguimientos.FirstOrDefault(d => d.ElegibilidadPrepId == elegi.Id);


            ViewBag.Nombre = datos.Nombres + " " + datos.Apellidos;
            ViewBag.IdDatos = datos.Id;

            ViewBag.Peso = datos.Peso;
            ViewBag.Edad = Convert.ToDecimal(datos.Edad);
            ViewBag.Sexo = datos.Sexo;
            ViewBag.Genero = datos.Genero;
            ViewBag.seguimientosPrep = segui.SeguimimientoPruebaId;


         
            return View();
        }

        [HttpPost]
        public ActionResult SeguimientoPrep(int IdDatos, Seguimiento seguimiento) 
        {
            var formulario = db.FormularioPreps.FirstOrDefault(x => x.DatosGeneralesId == IdDatos);
            var elegibilidad = db.ElegibilidadPreps.FirstOrDefault(x => x.FormularioPrepId == formulario.Id);
            var segui = db.Seguimientos.FirstOrDefault(x => x.ElegibilidadPrepId == elegibilidad.Id);

            seguimiento.ElegibilidadPrepId = elegibilidad.Id;
            seguimiento.Usuario = "1";


            var pruebaId = segui.SeguimimientoPruebaId;

            if (pruebaId == 1)
            {
                seguimiento.SeguimimientoPruebaId = 2;

            }
            if (pruebaId == 2)
            {
                seguimiento.SeguimimientoPruebaId = 3;

            }
            if (pruebaId == 3)
            {
                seguimiento.SeguimimientoPruebaId = 4;

            }
            if (pruebaId == 4)
            {
                seguimiento.SeguimimientoPruebaId = 5;

            }
            if (pruebaId == 5)
            {
                seguimiento.SeguimimientoPruebaId = 2;

            }
            //db.Seguimientos.Add(seguimiento);
            //db.SaveChanges();

            return View(); 
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
