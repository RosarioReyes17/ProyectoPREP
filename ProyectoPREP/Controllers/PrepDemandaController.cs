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
    public class PrepDemandaController : Controller
	{
		// GET: PrepDemanda
		DbPrepContext db;
		public PrepDemandaController(DbPrepContext _db)
		{

			this.db = _db;
		}
		public ActionResult ElegibilidadPrepDemanda()
		{

			return View();
		}


		[HttpPost]
		public ActionResult ElegibilidadPrepDemanda(TblPrepDemanda datos)
		{
			try
            {
                int idUser = Convert.ToInt32(User.GetUserId());
                int IdDeptoDepend = Convert.ToInt32(User.GetIdDepartamento());

				datos.IdDeptoDepend = IdDeptoDepend;
				datos.Usuario = Convert.ToString(idUser);

				//REVISAR - LE QUITÉ EL COMENTARIO PARA VER SI LOS DATOS ESTABAN LLEGANDO
                db.TblPrepDemanda.Add(datos);
                db.SaveChanges();

                return RedirectToAction("HomePrepDemanda", "PrepDemanda");

            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
			
		}
		
		public ActionResult SeguimientoPrepDemanda(int id)
		{

			var datos = db.TblPrepDemanda.FirstOrDefault(d => d.IdPaciente == id);
			var nacionalidad = db.VwNacionalidads.FirstOrDefault(x => Convert.ToInt32(x.IdNacionalidad) == datos.Nacionalidad);


			ViewBag.Nombre = datos.Nombres;
			ViewBag.Apellido = datos.Apellidos;

			ViewBag.Sexo = datos.Sexo;
			ViewBag.nacionalidad = nacionalidad.Nacionalidad;
			ViewBag.IdPaciente = datos.IdPaciente;
			return View();
		}


        public ActionResult HomePrepDemanda()
        {
			int idUser = Convert.ToInt32(User.GetUserId());
			int IdDeptoDepend = Convert.ToInt32(User.GetIdDepartamento());
			string admin = User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(x => x.Value).FirstOrDefault();

			var lista = new List<TblPrepDemanda>();
			string sql = "ListaPrep_Demanda";
			string sqlAdmin = "ListaPrep_Demanda";

			if (admin == "Administrador")
			{
				using (var connection = new SqlConnection(db.Database.GetConnectionString()))
				{
					lista = connection.Query<TblPrepDemanda>(sqlAdmin, commandType: System.Data.CommandType.StoredProcedure).ToList();
					return View(lista);

				}
			}


			using (var connection = new SqlConnection(db.Database.GetConnectionString()))
			{
				lista = connection.Query<TblPrepDemanda>(sql, commandType: System.Data.CommandType.StoredProcedure).ToList();

			}

			return View(lista);
        }


		public ActionResult DemandaEditar(int id)
		{
            var datos = db.TblPrepDemanda.FirstOrDefault(d => d.IdPaciente == id);
            var nacionalidad = db.VwNacionalidads.FirstOrDefault(x => Convert.ToInt32(x.IdNacionalidad) == datos.Nacionalidad);

            return View(datos);
		}


		[HttpPost]
		public ActionResult DemandaEditar(int idPaciente,TblPrepDemanda demanda)
		{

			int idUser = Convert.ToInt32(User.GetUserId());
			int IdDeptoDepend = Convert.ToInt32(User.GetIdDepartamento());

			demanda.FechaModificacion = DateTime.Now;
			demanda.UsuarioModifico = Convert.ToString(idUser);
			demanda.IdDeptoDepend = IdDeptoDepend;

			db.Entry(demanda).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("HomePrepDemanda", "PrepDemanda");

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


       

	

	

		
	}
}
