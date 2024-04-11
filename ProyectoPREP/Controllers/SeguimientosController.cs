using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPREP.Models;

namespace ProyectoPREP.Controllers
{
    [Authorize(Roles = "Administrador,Psicólogo Medicos")]

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
            int idUser = Convert.ToInt32(User.GetUserId());

            var formulario = db.FormularioPreps.Where(X => X.DatosGeneralesId == IdDatos).FirstOrDefault();

            var elegibilidad = db.ElegibilidadPreps.FirstOrDefault(x => x.FormularioPrepId == formulario.Id);

            elegibilidad.Estatus = 6;
            elegibilidad.Usuario = Convert.ToString(idUser);
            seguimiento.Id = 0;
            seguimiento.ElegibilidadPrepId = elegibilidad.Id;
            seguimiento.SeguimimientoPruebaId = 5;
            seguimiento.Usuario = Convert.ToString(idUser);


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
            int idUser = Convert.ToInt32(User.GetUserId());

            var formu = db.FormularioPreps.FirstOrDefault(X => X.DatosGeneralesId == IdDatos);
            var elegibilidad = db.ElegibilidadPreps.FirstOrDefault(x => x.FormularioPrepId == formu.Id);

            elegibilidad.Estatus = 6;
            elegibilidad.Usuario = Convert.ToString(idUser);
            seguimiento.Id = 0;
            seguimiento.ElegibilidadPrepId = elegibilidad.Id;
            seguimiento.SeguimimientoPruebaId = 5;
            seguimiento.Usuario = Convert.ToString(idUser);


            db.Entry(elegibilidad).State = EntityState.Modified;
            db.Seguimientos.Add(seguimiento);
            db.SaveChanges();



            var result = new { status };
            return Json(result);
        }

        [HttpGet]

        public ActionResult SeguimientoPrep(int id)
        {
            var datos = db.DatosGenerales.FirstOrDefault(d => d.Id == id);
            var formu = db.FormularioPreps.FirstOrDefault(d => d.DatosGeneralesId == id);
            var elegi = db.ElegibilidadPreps.FirstOrDefault(d => d.FormularioPrepId == formu.Id);


            ViewBag.Nombre = datos.Nombres + " " + datos.Apellidos;
            ViewBag.IdDatos = datos.Id;

            ViewBag.Edad = Convert.ToDecimal(datos.Edad);
            ViewBag.Sexo = datos.Sexo;
            ViewBag.Peso = datos.Peso;
            ViewBag.Genero = datos.Genero;

            return View();
        }

        [HttpPost]
        public ActionResult SeguimientoPrep(int IdDatos,bool PrepArvTdf3tc,bool PrepArvTdfFtc,bool PrepArvTafFtc, Seguimiento seguimiento) 
        {

            if (PrepArvTdf3tc == false && PrepArvTdfFtc == false && PrepArvTafFtc == false)
            {
                TempData["ARV"] = "Seleccione una de las ARV Preescrita";
                return View();
            }

            int idUser = Convert.ToInt32(User.GetUserId());

            var formulario = db.FormularioPreps.FirstOrDefault(x => x.DatosGeneralesId == IdDatos);
            var elegibilidad = db.ElegibilidadPreps.FirstOrDefault(x => x.FormularioPrepId == formulario.Id);
            DateTime fecha = DateTime.Now;

            seguimiento.Id = 0;
            seguimiento.FechaSeguimiento = fecha;
            seguimiento.ElegibilidadPrepId = elegibilidad.Id;
            seguimiento.SeguimimientoPruebaId = 5;
            seguimiento.Usuario = Convert.ToString(idUser);

            elegibilidad.Usuario = Convert.ToString(idUser);
            elegibilidad.Estatus = 4;


            db.Entry(elegibilidad).State = EntityState.Modified;
            db.Seguimientos.Add(seguimiento);
            db.SaveChanges();
            return RedirectToAction("SeguimientoVer", "Seguimientos", new { id = IdDatos });
        }


       
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
            ViewBag.IdDatos = datos.Id;
            return View(segui);
        }


      
        [HttpGet]
        public ActionResult SeguimientoVerPorId(int id)
        {
            var segui = db.Seguimientos.Where(d => d.Id == id).FirstOrDefault();
            var elegi = db.ElegibilidadPreps.FirstOrDefault(d => d.Id == segui.ElegibilidadPrepId);
            var formu = db.FormularioPreps.FirstOrDefault(d => d.Id == elegi.FormularioPrepId);
            var datos = db.DatosGenerales.FirstOrDefault(d => d.Id == formu.DatosGeneralesId);
            var nacionalidad = db.VwNacionalidads.FirstOrDefault(x => Convert.ToInt32(x.IdNacionalidad) == datos.Nacionalidad);


            ViewBag.Nombre = datos.Nombres;
            ViewBag.Apellido = datos.Apellidos;
            ViewBag.IdDatos = datos.Id;

            

            ViewBag.Sexo = datos.Sexo;
            ViewBag.nacionalidad = nacionalidad.Nacionalidad;

            return View(segui);
        }


        [HttpGet]

        public ActionResult Editar(int id)
        {
            var segui = db.Seguimientos.Where(d => d.Id == id).FirstOrDefault();
            var elegi = db.ElegibilidadPreps.FirstOrDefault(d => d.Id == segui.ElegibilidadPrepId);
            var formu = db.FormularioPreps.FirstOrDefault(d => d.Id == elegi.FormularioPrepId);
            var datos = db.DatosGenerales.FirstOrDefault(d => d.Id == formu.DatosGeneralesId);
            var nacionalidad = db.VwNacionalidads.FirstOrDefault(x => Convert.ToInt32(x.IdNacionalidad) == datos.Nacionalidad);
            

            

            ViewBag.Nombre = datos.Nombres;
            ViewBag.Apellido = datos.Apellidos;

            ViewBag.Sexo = datos.Sexo;
            ViewBag.nacionalidad = nacionalidad.Nacionalidad;

            ViewBag.Edad = Convert.ToDecimal(datos.Edad);
            ViewBag.Genero = datos.Genero;
            ViewBag.IdDatos = datos.Id;



            return View(segui);
        }


        [HttpPost]
        public ActionResult SeguimientoEditar(int IdDatos, bool PrepArvTdf3tc, bool PrepArvTdfFtc, bool PrepArvTafFtc, Seguimiento seguimiento)
        {
            if (PrepArvTdf3tc == false && PrepArvTdfFtc == false && PrepArvTafFtc == false)
            {
                TempData["ARV"] = "Seleccione una de las ARV Preescrita";
                return View();
            }
            int idUser = Convert.ToInt32(User.GetUserId());

            var formulario = db.FormularioPreps.FirstOrDefault(x => x.DatosGeneralesId == IdDatos);
            var elegibilidad = db.ElegibilidadPreps.FirstOrDefault(x => x.FormularioPrepId == formulario.Id);
            DateTime fecha = DateTime.Now;

            seguimiento.FechaRegistroSeguimiento = fecha;
            seguimiento.Usuario = Convert.ToString(idUser); ;

            elegibilidad.Estatus = 4;
            elegibilidad.Usuario = Convert.ToString(idUser);


            db.ElegibilidadPreps.Entry(elegibilidad).State = EntityState.Modified;
            db.Seguimientos.Entry(seguimiento).State = EntityState.Modified;
            db.SaveChanges();

			return RedirectToAction("SeguimientoVer", "Seguimientos", new { id = IdDatos });
		}

    }
}
