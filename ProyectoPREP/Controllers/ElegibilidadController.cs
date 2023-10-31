using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPREP.Models;

namespace ProyectoPREP.Controllers
{
	public class ElegibilidadController : Controller
	{

        DbPrepContext db;
        public ElegibilidadController(DbPrepContext _db)
        {
            this.db = _db;
        }
        // GET: ElegibilidadController
        public ActionResult Index()
		{
			return View();
		}

		// GET: ElegibilidadController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: ElegibilidadController/Create
		public ActionResult Create(int id)
		{
			var formulario = db.FormularioPreps.Where(p => p.DatosGeneralesId == id).FirstOrDefault();
			var model = new ElegibilidadPrep();
			model = db.ElegibilidadPreps.Where(x=>x.FormularioPrepId == formulario.Id).
				Include(x=>x.FormularioPrep).ThenInclude(x=>x.DatosGenerales).FirstOrDefault();

			//ViewBag.IdElegibilidad = model.Id;
			//ViewBag.Idformulario = model.FormularioPrepId;
			//ViewBag.Usuario = model.Usuario;

			return View(model);
		}

		// POST: ElegibilidadController/Create
		[HttpPost]
		public ActionResult Create(int IdDatos, ElegibilidadPrep elegibilidad)
		{
			try
			{

                var formulario = db.FormularioPreps.Where(X => X.DatosGeneralesId == IdDatos).FirstOrDefault();

				var elegi = db.ElegibilidadPreps.Where(X => X.FormularioPrepId == formulario.Id).FirstOrDefault();
				elegibilidad.Id = elegi.Id;
				elegibilidad.Usuario = elegi.Usuario;
				elegibilidad.Estatus = elegi.Estatus;

                //db.Entry(elegibilidad).State = EntityState.Modified;
				//db.SaveChanges();


                return RedirectToAction("ConsultaDatosGenerales", "DatosGenerales");
            }
            catch
			{
				return View();
			}
		}

		// GET: ElegibilidadController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: ElegibilidadController/Edit/5
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

		// GET: ElegibilidadController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: ElegibilidadController/Delete/5
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
