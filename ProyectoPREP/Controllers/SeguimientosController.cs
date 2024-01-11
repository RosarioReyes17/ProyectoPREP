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
        public JsonResult CreatininaMenor60(int IdDatos, ElegibilidadPrep elegibilidad, Seguimiento seguimiento)
        {

            var formulario = db.FormularioPreps.Where(X => X.DatosGeneralesId == IdDatos).FirstOrDefault();

            var elegi = db.ElegibilidadPreps.Where(X => X.FormularioPrepId == formulario.Id).FirstOrDefault();

            using (DbPrepContext db = new DbPrepContext())
            {
                var estatus = true;
                //int id = elegi.Id;

                elegi.SeronegativoVih = elegibilidad.SeronegativoVih;
                elegi.FechaPruebaVih = elegibilidad.FechaPruebaVih;
                elegi.FechaEntregaVih = elegibilidad.FechaEntregaVih;
                elegi.ResultadoPruebaVih = elegibilidad.ResultadoPruebaVih;
                elegi.RiesgoInfeccionVih = elegibilidad.RiesgoInfeccionVih;
                elegi.SignosSintomas = elegibilidad.SignosSintomas;

                elegi.Linfadenopatias = elegibilidad.Linfadenopatias;
                elegi.FiebreDesconocida = elegibilidad.FiebreDesconocida;
                elegi.DiarreaProlongada = elegibilidad.DiarreaProlongada;
                elegi.ErupcionesPiel = elegibilidad.ErupcionesPiel;
                elegi.InfeccionesRecurrentes = elegibilidad.InfeccionesRecurrentes;
                elegi.HepatoEsplenomegalia = elegibilidad.HepatoEsplenomegalia;

                elegi.CargaViralPcr = elegibilidad.CargaViralPcr;

                //elegi.FechaVisitaPcr = elegibilidad.FechaVisitaPcr;
                //elegi.FechaPruebaPcr = elegibilidad.FechaPruebaPcr;
                //elegi.ResultadoCargaViralPcr = elegibilidad.ResultadoCargaViralPcr;


                //elegibilidad.Id = id;
                elegi.Usuario = Convert.ToString(1);
                elegi.Estatus = 2;


                //db.ElegibilidadPreps.Entry(elegi).State = EntityState.Modified;
                //db.SaveChanges();

            }

            var result = new
            {
                estatus = true
            };
            return Json(result);
        }

        public JsonResult VIHPositivo(int id, DateTime FechaPruebaVih, DateTime FechaEntregaVih)
        {
            bool status = true;

            var formu = db.FormularioPreps.FirstOrDefault(X => X.DatosGeneralesId == id);
            var elegibilidad = db.ElegibilidadPreps.FirstOrDefault(x => x.FormularioPrepId == formu.Id);
            elegibilidad.Estatus = 6;
            elegibilidad.SeronegativoVih = "No";
            elegibilidad.FechaPruebaVih = FechaPruebaVih;
            elegibilidad.FechaEntregaVih = FechaEntregaVih;
            elegibilidad.ResultadoPruebaVih = "Positivo";
            //db.Entry(elegibilidad).State = EntityState.Modified;
            //db.SaveChanges();

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
            var formulario = db.FormularioPreps.FirstOrDefault(x=>x.DatosGeneralesId == IdDatos);
            var elegibilidad = db.ElegibilidadPreps.FirstOrDefault(x=>x.FormularioPrepId == formulario.Id);
            var segui = db.Seguimientos.FirstOrDefault(x=>x.ElegibilidadPrepId == elegibilidad.Id);

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
            var centros = db.VwUsuariosEstablecimientos.FirstOrDefault(x => x.IdDeptoDepend == datos.IdDeptoDepend);


            ViewBag.Nombre = datos.Nombres;
            ViewBag.Apellido = datos.Apellidos;

            ViewBag.Sexo = datos.Sexo;
            ViewBag.nacionalidad = datos.Nacionalidad;
            ViewBag.centro = centros.NombreCentro;

            return View(segui);
        }
    }
}
