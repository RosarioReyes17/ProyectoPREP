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


        [HttpGet]

        public ActionResult VerUsuarios()
        {
            var datos = db.VwPrepGestionUsuarios.ToList();

           
            return View(datos);
        }

        public JsonResult BuscarUsuario(int IdUsuario, string link)
        {
            var usuarioRol = db.UsuarioRoles.FirstOrDefault(x => x.IdUsuario == IdUsuario);
            var datos = db.VwPrepGestionUsuarios.FirstOrDefault(x => x.IdUsuario == IdUsuario);
            var usuarios = db.VwPrepGestionUsuarios.Where(x => x.IdUsuario == IdUsuario).ToList();
            var estadolink = false;

            if (link == "asignarRol")
            {
                estadolink = true;
            }
            else
            {
                estadolink = false;
            }

            if (datos.Activo.Substring(0,1) == "N")
            {
                var result1 = new
                {
                    estadolink = "",
                    activo = "N",
                    cantidad = 0,
                    estatus = "",
                    message = "Este usuario esta inactivo,por favor comuniquese con su superior."
                };
                return Json(result1);
            }

            if (usuarios.Count > 1)
            {
                var result1 = new
                {
                    estadolink = "",
                    activo = "",
                    cantidad = usuarios.Count,
                    estatus = "",
                    message = "Este usuario esta repetido, por favor comuniquese con su superior."
                };
                return Json(result1);
            }



            if (usuarioRol != null)
            {
                var result1 = new
                {
                    estadolink = estadolink,
                    activo = "",
                    cantidad = 0,
                    estatus = true,
                    message = "Si existe el usuario con un rol"
                };
                return Json(result1);
            }
            else
            {
                var result = new
                {
                    estadolink = estadolink,
                    activo = "",
                    cantidad = 0,
                    estatus = false,
                    message = "No existe el usuario con un rol"

                };
                return Json(result);
            }

          
        }

    }
}
