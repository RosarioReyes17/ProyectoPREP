using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoPREP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ProyectoPREP.Controllers
{

    public class RechazadoSuspendidoController : Controller
    {
        // GET: Rechazado

        DbPrepContext db;

        public RechazadoSuspendidoController(DbPrepContext _db)
        {
            this.db = _db;
        }
        [Authorize(Roles = "Administrador,Psicólogo Medicos")]

        public ActionResult Reintegrar(int id)
        {
            var datos = db.DatosGenerales.Include(x=>x.FormularioPreps).FirstOrDefault(x => x.Id == id);
            var formulario = db.FormularioPreps.FirstOrDefault(x => x.DatosGeneralesId == id);

            ViewBag.idDatos = datos.Id;
            ViewBag.idFormulario = formulario.Id;
            ViewBag.nombre = datos.Nombres + " " + datos.Apellidos;
            ViewBag.documento = datos.Documento;
            ViewBag.tipo = datos.TipoDocumento;
            return View(formulario);
        }

        [Authorize(Roles = "Administrador,Psicólogo Medicos")]
        [HttpPost]
        public ActionResult Reintegrar(FormularioPrep formulario, int idDatos, int idFormulario)
        {
            int idUser = Convert.ToInt32(User.GetUserId());

            int? estado;
            var elegi = db.ElegibilidadPreps.FirstOrDefault(x => x.FormularioPrepId == idFormulario);
            var datos = db.DatosGenerales.FirstOrDefault(x => x.Id == idDatos);

            estado = elegi.Estatus;

            elegi.Estatus = 1;
            elegi.FechaReintegro = formulario.FechaReintegro;
            elegi.Usuario = Convert.ToString(idUser);

            //datos.FechaIngresoSai = Convert.ToDateTime(formulario.FechaReintegro);

            formulario.Id = idFormulario;
            formulario.DatosGeneralesId = idDatos;
            formulario.UsuarioModifico = Convert.ToString(idUser);
            formulario.FechaModificacion = DateTime.Now;

            db.Entry(elegi).State = EntityState.Modified;
            db.Entry(formulario).State = EntityState.Modified;
            db.Entry(datos).State = EntityState.Modified;
            db.SaveChanges();

            if (estado == 6)
            {
                return RedirectToAction("DatosGeneralesPorRechazado", "DatosGenerales");

            }
            if (estado == 7)
            {
                return RedirectToAction("DatosGeneralesPorSuspendido", "DatosGenerales");

            }

            return RedirectToAction("DatosGeneralesPorElegibilidad", "DatosGenerales");

        }

        [Authorize(Roles = "Administrador,Psicólogo Medicos")]

        public ActionResult Suspender(int id)
        {

            var datos = db.DatosGenerales.Include(x => x.FormularioPreps).FirstOrDefault(x => x.Id == id);
            var formulario = db.FormularioPreps.FirstOrDefault(x => x.DatosGeneralesId == id);

            ViewBag.idDatos = datos.Id;
            ViewBag.idFormulario = formulario.Id;
            ViewBag.nombre = datos.Nombres + " " + datos.Apellidos;
            ViewBag.documento = datos.Documento;
            ViewBag.tipo = datos.TipoDocumento;
            return View();
        }

        [Authorize(Roles = "Administrador,Psicólogo Medicos")]

        [HttpPost]
        public ActionResult Suspender(int idDatos, TratamientoPrep tratamiento)
        {
            int idUser = Convert.ToInt32(User.GetUserId());

            var formulario = db.FormularioPreps.FirstOrDefault(x => x.DatosGeneralesId == idDatos);
            var elegi = db.ElegibilidadPreps.FirstOrDefault(x => x.FormularioPrepId == formulario.Id);
            var trata = db.TratamientoPreps.FirstOrDefault(x => x.ElegibilidadPrepId == elegi.Id);


            elegi.Estatus = 7;
            elegi.Usuario = Convert.ToString(idUser);
            
            trata.PrepSuspendida = tratamiento.PrepSuspendida;
            trata.MotivosInterrupcionPrep = tratamiento.MotivosInterrupcionPrep;
            trata.EstadoVihAlInterrumpir = tratamiento.EstadoVihAlInterrumpir;
            trata.Observaciones = tratamiento.Observaciones;
            

            db.Entry(trata).State = EntityState.Modified;
            db.Entry(elegi).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("DatosGeneralesPorAprobado", "DatosGenerales");
        }

  
        
    }
}
