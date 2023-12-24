using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPREP.Models;
using System.Data.SqlClient;

namespace ProyectoPREP.Controllers
{
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
                var Existe = db.GestionPacientes.Where(x => x.DatosGeneralesId == idDatos && x.EstatusSolicitud == "Pendiente").ToList();
                if (Existe.Count() == 0)
                {
                    paciente.DeptoDependOriginal = 1641;
                    paciente.FechaRecepcion = DateTime.Now;
                    paciente.UsuarioEnvia = 1;
                    paciente.EstatusSolicitud = "Pendiente";
                    paciente.DatosGeneralesId = idDatos;
                    //db.GestionPacientes.Add(paciente);
                    //db.SaveChanges();
                }
                else
                {
                    return Content("Ha ocurrido un error, por favor intentarlo mas tarde.");

                }
                return RedirectToAction("DatosGeneralesPorElegibilidad", "DatosGenerales");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult RecibirPacientes()
        {
            var lista = new List<GestionPacientesAprobados>();
            string sql = "GestionPacientesAprobados";


            using (var connection = new SqlConnection(db.Database.GetConnectionString()))
            {
                lista = connection.Query<GestionPacientesAprobados>(sql, commandType: System.Data.CommandType.StoredProcedure).ToList();

            }

            return View(lista);
        }


        public ActionResult AceptarPacientes(int id)
        {

            var gestion = db.GestionPacientes.FirstOrDefault(x=>x.DatosGeneralesId == id);
            gestion.UsuarioRecibe = 2;
            gestion.FechaRecepcion = DateTime.Now;
            gestion.EstatusSolicitud = "Aprobado";
            db.Entry(gestion).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("RecibirPacientes", "GestionPacientes");
        }

        public ActionResult RechazarPacientes(int id)
        {

            var gestion = db.GestionPacientes.FirstOrDefault(x => x.DatosGeneralesId == id);
            gestion.UsuarioRecibe = 2;
            gestion.FechaRecepcion = DateTime.Now;
            gestion.EstatusSolicitud = "Rechazado";
            db.Entry(gestion).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("RecibirPacientes", "GestionPacientes");
        }
    }
}
