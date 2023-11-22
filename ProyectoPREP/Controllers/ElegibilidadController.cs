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

        public JsonResult VIHPositivo(int id)
		{
            bool status = true;

            var elegibilidad = db.ElegibilidadPreps.FirstOrDefault(x => x.Id == id);
			elegibilidad.Estatus = 6;
			db.Entry(elegibilidad).State = EntityState.Modified;
			db.SaveChanges();

            var result = new { status };
            return Json(result);
        }


        public ActionResult Create(int id)
		{
			var formulario = db.FormularioPreps.Where(p => p.DatosGeneralesId == id).FirstOrDefault();
			var model = new ElegibilidadPrep();
			model = db.ElegibilidadPreps.Where(x=>x.FormularioPrepId == formulario.Id).
				Include(x=>x.FormularioPrep).ThenInclude(x=>x.DatosGenerales).FirstOrDefault();

			var edad = model.FormularioPrep.DatosGenerales.Edad;
			if (edad == null)
			{
				edad = 0;
			}
			
			string fecha = model.FormularioPrep.DatosGenerales.FechaIngresoSai.ToString("yyyy-MM-dd");
			

            ViewBag.Peso = model.FormularioPrep.DatosGenerales.Peso;
			ViewBag.Edad = Convert.ToDecimal(edad);
			ViewBag.Sexo = model.FormularioPrep.DatosGenerales.Sexo;
			ViewBag.IdDatos = model.FormularioPrep.DatosGenerales.Id;
			ViewBag.IdElegibilidad = model.Id;
			ViewBag.FechaPrep = fecha;
			ViewBag.Nombre = model.FormularioPrep.DatosGenerales.Nombres +" "+ model.FormularioPrep.DatosGenerales.Apellidos;

			return View(model);
		}

		// POST: ElegibilidadController/Create
		[HttpPost]
		public ActionResult Create(int IdDatos, ElegibilidadPrep elegibilidad, Seguimiento seguimiento)
		{
			try
			{

                var formulario = db.FormularioPreps.Where(X => X.DatosGeneralesId == IdDatos).FirstOrDefault();

                var elegi = db.ElegibilidadPreps.Where(X => X.FormularioPrepId == formulario.Id).FirstOrDefault();

				using (DbPrepContext db = new DbPrepContext())
				{
                    int id = elegi.Id;

                    elegibilidad.Id = id;
                    elegibilidad.Usuario = Convert.ToString(1);
                    elegibilidad.Estatus = 3;

                    seguimiento.ElegibilidadPrepId = id;
                    seguimiento.SeguimimientoPruebaId = 1;
                    seguimiento.Id = 0;

                    //db.Seguimientos.Add(seguimiento);
                    //db.ElegibilidadPreps.Entry(elegibilidad).State = EntityState.Modified;
                    //db.SaveChanges();
					
                }

               
				return RedirectToAction("ConsultaDatosGenerales", "DatosGenerales");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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
