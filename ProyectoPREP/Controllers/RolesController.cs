using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPREP.Models;
using System.Data.SqlClient;

namespace ProyectoPREP.Controllers
{
    [Authorize(Roles = "Administrador")]

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


        public ActionResult CambiarRol(int id)
        {

            var datos = db.VwPrepGestionUsuarios.First(x => x.IdUsuario == id);
            return View(datos);
        }


        [HttpPost]
        public ActionResult CambiarRol(int IdRol, int IdUsuario)
        {

            var datos = db.VwPrepGestionUsuarios.First(x => x.IdUsuario == IdUsuario);
           
            var usuRol = db.UsuarioRoles.First(x => x.IdUsuario == IdUsuario);


            usuRol.RolesId = IdRol;
            usuRol.IdCentro = Convert.ToInt32(datos.IdDeptoDepend);
            db.UsuarioRoles.Entry(usuRol).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("VerUsuarios", "Roles");

        }


        public ActionResult ActivarDesactivarUsuario(int id)
        {

            var datos = db.VwPrepGestionUsuarios.First(x => x.IdUsuario == id);
            return View(datos);
        }

        [HttpPost]
        public ActionResult ActivarDesactivarUsuario(int IdUsuario, string Estado)
        {

            var datos = db.Usuarios.First(x => x.IdUsuario == IdUsuario);
            datos.Activo = Estado;
            //db.Usuarios.Entry(datos).State = EntityState.Modified;
            //db.SaveChanges();

            return View(datos);
        }


        [HttpGet]

        public ActionResult VerUsuarios()
        {
            var datos = db.VwPrepGestionUsuarios.ToList();

           
            return View(datos);
        }

        public JsonResult BuscarUsuario(int IdUsuario)
        {
            var usuarioRol = db.UsuarioRoles.FirstOrDefault(x => x.IdUsuario == IdUsuario);
            if (usuarioRol != null)
            {
                var result1 = new
                {
                    estatus = true,
                    message = "Si existe el usuario"
                };
                return Json(result1);
            }

            var result = new
            {
                estatus = false,
                message = "No existe el usuario"

            };
            return Json(result);


        }

    }
}
