using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPREP.Models;
using System.Data.SqlClient;

namespace ProyectoPREP.Controllers
{
    public class RolesController : Controller
    {
        // GET: RolesController
        DbPrepContext db;
        public RolesController(DbPrepContext _db)
        {
            this.db = _db;
        }
        public ActionResult AsignarRol()
        {
            return View();
        }


        [HttpPost]
        public JsonResult BuscarUsuario(string usuario)
        {

            var lista = new List<VwUsuariosIntranet>();
            string sql = "BuscarUsuarios";

            
            using (var connection = new SqlConnection(db.Database.GetConnectionString()))
            {
                lista = connection.Query<VwUsuariosIntranet>(sql, new {usuario}, commandType: System.Data.CommandType.StoredProcedure).ToList();
                
                var result = new { lista };
                return Json(result);

            }
            
        }

        // GET: RolesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RolesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolesController/Create
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

        // GET: RolesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RolesController/Edit/5
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

        // GET: RolesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RolesController/Delete/5
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
