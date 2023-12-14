using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoPREP.Models;
using Microsoft.EntityFrameworkCore;


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

        [HttpPost]
        public ActionResult Reintegrar(FormularioPrep formulario, int idDatos, int idFormulario)
        {
            int? estado;
            string vista;
            var elegi = db.ElegibilidadPreps.FirstOrDefault(x => x.FormularioPrepId == idFormulario);

            estado = elegi.Estatus;

            elegi.Estatus = 1;
            elegi.FechaReintegro = formulario.FechaReintegro;

            formulario.Id = idFormulario;
            formulario.DatosGeneralesId = idDatos;
            formulario.UsuarioModifico = "1";
            formulario.FechaModificacion = DateTime.Now;

            db.Entry(elegi).State = EntityState.Modified;
            db.Entry(formulario).State = EntityState.Modified;
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

        // GET: Rechazado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rechazado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rechazado/Create
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

        // GET: Rechazado/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rechazado/Edit/5
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

        // GET: Rechazado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rechazado/Delete/5
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
