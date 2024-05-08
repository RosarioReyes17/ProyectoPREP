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

        public ActionResult AsignarRol(int id)
        {
            var datos = db.VwPrepGestionUsuarios.First(x => x.IdUsuario == id);

            return View(datos);
        }


        [HttpPost]
        public ActionResult AsignarRol(int IdRol, int IdUsuario)
        {
            var datos = db.VwPrepGestionUsuarios.First(x=>x.IdUsuario == IdUsuario);


            var usuRol = new UsuarioRole();
            usuRol.IdUsuario = IdUsuario;
            usuRol.RolesId = IdRol;
            usuRol.IdCentro = Convert.ToInt32(datos.IdDeptoDepend);
            db.UsuarioRoles.Add(usuRol);
            db.SaveChanges();
            return RedirectToAction("VerUsuarios", "Roles");

        }






        [HttpGet]

        public ActionResult VerUsuarios()
        {
            var datos = db.VwPrepGestionUsuarios.ToList();

           
            return View(datos);
        }

    }
}
