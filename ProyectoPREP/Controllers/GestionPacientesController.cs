using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using ProyectoPREP.Models;
using ProyectoPREP.Proc;
using System.Data.SqlClient;
using static System.Collections.Specialized.BitVector32;

namespace ProyectoPREP.Controllers
{
    [Authorize(Roles = "Administrador,Psicólogo Medicos")]

    public class GestionPacientesController : Controller
    {
        // GET: TransferidoController
        public DbPrepContext db;
        public GestionPacientesController(DbPrepContext _db)
        {
            this.db = _db;
        }

        public ActionResult Transferir(int id)
        {
            var datos = db.DatosGenerales.Include(x => x.FormularioPreps).FirstOrDefault(x => x.Id == id);
            var formulario = db.FormularioPreps.FirstOrDefault(x => x.DatosGeneralesId == id);
            var centros = db.VwUsuariosEstablecimientos.FirstOrDefault(x => x.IdDeptoDepend == datos.IdDeptoDepend);

            ViewBag.idDatos = datos.Id;
            ViewBag.idFormulario = formulario.Id;
            ViewBag.nombre = datos.Nombres;
            ViewBag.apellido = datos.Apellidos;
            ViewBag.fecha = datos.FechaIngresoSai.ToString().Substring(0,10);
            ViewBag.centro = centros.NombreCentro; 
            return View();
        }

   
        // POST: TransferidoController/Create
        [HttpPost]
        public ActionResult Transferir(int idDatos, GestionPaciente paciente)
        {
            try
            {
                var datos = db.DatosGenerales.FirstOrDefault(x => x.Id == idDatos);

                int idUser = Convert.ToInt32(User.GetUserId());
                var Existe = db.GestionPacientes.FirstOrDefault(x => x.DatosGeneralesId == idDatos);

                if (Existe == null)
                {
                    paciente.DeptoDependOriginal = datos.IdDeptoDepend;
                    paciente.FechaRecepcion = DateTime.Now;
                    paciente.UsuarioEnvia = idUser;
                    paciente.EstatusSolicitud = "Pendiente";
                    paciente.DatosGeneralesId = idDatos;

                    db.GestionPacientes.Add(paciente);
                    db.SaveChanges();
                }
                else
                {
                    Existe.FechaRecepcion = DateTime.Now;
                    Existe.UsuarioEnvia = idUser;
                    Existe.EstatusSolicitud = "Pendiente";
                    Existe.DeptoDependOriginal = datos.IdDeptoDepend;
                    Existe.DeptoDependDestino = paciente.DeptoDependDestino;
                    Existe.FechaEnvio = paciente.FechaEnvio;

                    db.Entry(Existe).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("DatosGeneralesPorElegibilidad", "DatosGenerales");
            }
            catch
            {
                return Content("ha ocurrido un error");
            }
        }


        public ActionResult RecibirPacientes()
        {
            var lista = new List<GestionPacientesAprobados>();
            string sql = "GestionPacientesAprobados";
            int DeptoDependDestino = Convert.ToInt32(User.GetIdDepartamento());


            using (var connection = new SqlConnection(db.Database.GetConnectionString()))
            {
                lista = connection.Query<GestionPacientesAprobados>(sql,new { DeptoDependDestino }, commandType: System.Data.CommandType.StoredProcedure).ToList();

            }

            return View(lista);
        }


        public ActionResult AceptarPacientes(int id)
        {
            int idUser = Convert.ToInt32(User.GetUserId());

            var gestion = db.GestionPacientes.FirstOrDefault(x=>x.DatosGeneralesId == id);
            var datos = db.DatosGenerales.FirstOrDefault(x => x.Id == gestion.DatosGeneralesId);
            gestion.UsuarioRecibe = idUser;
            gestion.FechaRecepcion = DateTime.Now;
            gestion.EstatusSolicitud = "Aprobado";

            datos.IdDeptoDepend = (int)gestion.DeptoDependDestino;


            db.Entry(gestion).State = EntityState.Modified;
            db.Entry(datos).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("RecibirPacientes", "GestionPacientes");
        }

        public ActionResult RechazarPacientes(int id)
        {
            int idUser = Convert.ToInt32(User.GetUserId());

            var gestion = db.GestionPacientes.FirstOrDefault(x => x.DatosGeneralesId == id);
            gestion.UsuarioRecibe = idUser;
            gestion.FechaRecepcion = DateTime.Now;
            gestion.EstatusSolicitud = "Rechazado";
            db.Entry(gestion).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("RecibirPacientes", "GestionPacientes");
        }
    }
}
