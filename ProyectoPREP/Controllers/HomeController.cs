﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ProyectoPREP.Models;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace ProyectoPREP.Controllers
{
    public class HomeController : Controller
    {
        DbPrepContext db;

        public HomeController(DbPrepContext _db)
        {
            this.db = _db;
        }
    

        public class UsuarioSeguridad
        {

            public int IdUsuario { get; set; }
            public string NombreApellidos { get; set; }
            public string Usuario { get; set; }
            public string Password { get; set; }
            public string PasswordExpira { get; set; }
            public DateTime? PasswordExpiraFecha { get; set; }
            public string Activo { get; set; }
            public string IdDepartamento { get; set; }
            public string Departamento { get; set; }
            public string ID_Region { get; set; }
          
        }
        public UsuarioSeguridad ValidarUsuario(string usuario, string clave)
        {
            var info = from a in db.VwUsuariosIntranets
                       join b in db.UsuariosDepartamentos
                       on a.IdUsuario equals b.IdUsuario
                       where
                       a.IdDeptoDepend == b.IdDeptoDepend && a.Identificador == "C" && a.Usuario.ToLower() == usuario && a.Password == clave

                       select new UsuarioSeguridad
                       {
                           IdUsuario = a.IdUsuario,
                           NombreApellidos = a.NombreApellidos,
                           Usuario = a.Usuario,
                           Password = a.Password,
                           PasswordExpira = a.PasswordExpira,
                           PasswordExpiraFecha = a.PasswordExpiraFecha,
                           Activo = a.Activo,
                           IdDepartamento = b.IdDeptoDepend,
                           Departamento = b.DeptoDependSid,
                           ID_Region = b.IdRegion
                       };
            return info.FirstOrDefault();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(VwUsuariosIntranet user )
        {
            if (user.Usuario == null)
            {
                ViewBag.Error = "Debe ingresar el nombre de usuario";
                return View();
            }

            if (user.Password == null)
            {
                ViewBag.Error = "Debe ingresar la contraseña";
                return View();
            }

            //if (ModelState.IsValid)
            //{
                var Clave = GetMd5Hash(MD5.Create(), user.Password);
                var IsValidUser = ValidarUsuario(user.Usuario.ToLower(), Clave);
                var usuarioRole = db.UsuarioRoles.Include(x=>x.Roles).Where(x=>x.IdUsuario == IsValidUser.IdUsuario).FirstOrDefault();
                if (IsValidUser != null)
                {
                    if (IsValidUser.Activo.Trim() == "N")
                    {
                        ViewBag.Error = "Este usuario esta inactivo.";
                    }
                    else if (IsValidUser.PasswordExpiraFecha < DateTime.Now && IsValidUser.PasswordExpira == "S")
                    {
                        ViewBag.Error = "La contraseña de este usuario expiro, debe dirigirse a la intranet para resetear su contraseña.";
                    }

                    else if (usuarioRole != null)
                    {


                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,IsValidUser.NombreApellidos),
                            new Claim("IdUser",Convert.ToString(IsValidUser.IdUsuario)),
                            new Claim(ClaimTypes.Role,Convert.ToString(usuarioRole.Roles.Nombre)),
                            new Claim("Depertamento",IsValidUser.Departamento),
                            new Claim("IdDepertamento",IsValidUser.IdDepartamento),
                            new Claim("IdRegion",IsValidUser.ID_Region),
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                        return RedirectToAction("DatosGeneralesPorElegibilidad", "DatosGenerales");


                    }
                    else
                    {
                        ViewBag.Error = "Usuario no tiene permisos para acceder este recurso.";
                    }

                }
            //else
            //{
            //    ViewBag.Error = "La cédula o contraseña proporcionada son incorrectos.";
            //}
            //}
            return RedirectToAction("Login", "Home");
        }
        public async Task<IActionResult> CerrarSesionAsync()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Home");
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convertimos la informacion que pasamos en un arreglo de bytes array
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        //public ActionResult LogOff()
        //{
        //    FormsAuthentication.SignOut();
        //    FormsAuthentication.RedirectToLoginPage();
        //    Validado = 0;
        //    return View();

        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}