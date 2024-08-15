using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPREP.Models;
using System.Data.SqlClient;
using System.Security.Claims;

namespace ProyectoPREP.Controllers
{
    [Authorize(Roles = "Administrador,Psicólogo Medicos")]
    public class PrepDemanda : Controller
	{
		// GET: PrepDemanda
		DbPrepContext db;
		public PrepDemanda(DbPrepContext _db)
		{

			this.db = _db;
		}
		public ActionResult ElegibilidadPrepDemanda()
		{
			return View();
		}


        public ActionResult HomePrepDemanda()
        {
            return View();
        }

        public ActionResult DatosGeneralesPorElegibilidad(int id)
        {
            int idUser = Convert.ToInt32(User.GetUserId());
            int IdDeptoDepend = Convert.ToInt32(User.GetIdDepartamento());
            string admin = User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(x => x.Value).FirstOrDefault();

            var lista = new List<DatosGenerales>();
            string sql = "DatosGeneralesPorElegibilidad";
            //string sqlAdmin = "DatosGeneralesPorElegibilidadAdmin";

            //if (admin == "Administrador")
            //{
            //    using (var connection = new SqlConnection(db.Database.GetConnectionString()))
            //    {
            //        lista = connection.Query<DatosGenerales>(sqlAdmin, commandType: System.Data.CommandType.StoredProcedure).ToList();
            //        return View(lista);

            //    }
            //}


            using (var connection = new SqlConnection(db.Database.GetConnectionString()))
            {
                lista = connection.Query<DatosGenerales>(sql, new { IdDeptoDepend }, commandType: System.Data.CommandType.StoredProcedure).ToList();

            }

            ViewBag.Establecimientos = db.VwUsuariosEstablecimientos.ToList();

            return View(lista);
        }


        // GET: PrepDemanda/Details/5
        public ActionResult Details(int id)
		{
			return View();
		}

		// GET: PrepDemanda/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: PrepDemanda/Create
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

		// GET: PrepDemanda/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: PrepDemanda/Edit/5
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

		// GET: PrepDemanda/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: PrepDemanda/Delete/5
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
