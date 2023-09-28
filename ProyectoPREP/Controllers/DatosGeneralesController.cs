using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectoPREP.Models;
using ProyectoPREP.Padron;
using System.Data;
using System.Data.Entity;
//using System.Web.Mvc;

namespace ProyectoPREP.Controllers
{

    
    public class DatosGeneralesController : Controller
    {
        DbPrepContext db;
        public DatosGeneralesController(DbPrepContext db) 
        {
            this.db = db;
        }
        // GET: DatosGeneralesController
        public ActionResult Index()
        {
            return View();
        }

       

        // GET: DatosGeneralesController/Create
        public ActionResult CreateCedula()
        {
            var municipio = new VwMunicipio();
            List<VwMunicipio> lista;

            ViewBag.Municipio = db.VwMunicipios.ToList();
            return View();
        }

		public ActionResult CreateSinDocumento()
		{
			var municipio = new VwMunicipio();
			List<VwMunicipio> lista;

			ViewBag.Municipio = db.VwMunicipios.ToList();
			return View();
		}


		[HttpPost]
		public ActionResult CreateSinDocumento(DatosGenerale generale, FormularioPrep formulario)
		{
			try
			{
			
				generale.Usuario = Convert.ToString(1);
				generale.IdDeptoDepend = 1641;
				generale.TieneDocumentos = "No";
				generale.TipoDocumento = "SN";
				generale.EnRiesgo = "Si";
				if (generale.TieneDocumentos == "Si")
				{
					generale.TipoDocumento = "P";

				}

				db.DatosGenerales.Add(generale);

				formulario.Usuario = Convert.ToString(1);
				formulario.DatosGeneralesId = generale.Id;
				generale.FormularioPreps.Add(formulario);
				db.SaveChanges();


				return RedirectToAction("PruebaPacientes", "Prueba");

			}
			catch	
			{
				return RedirectToAction("PruebaPacientes", "Prueba"); //Revisar aqui
			}
		}
		// POST: DatosGeneralesController/Create
		[HttpPost]
        public ActionResult CreateCedula(DatosGenerale generale,FormularioPrep formulario)
        {
            try
            {
                generale.Usuario = Convert.ToString(1);
				generale.IdDeptoDepend = 1641;
				generale.TieneDocumentos = "Si";
				generale.TipoDocumento = "C";
				generale.EnRiesgo = "Si";

				db.DatosGenerales.Add(generale);

				formulario.Usuario = Convert.ToString(1);
				formulario.DatosGeneralesId = generale.Id;
				generale.FormularioPreps.Add(formulario);
				db.SaveChanges();


				return RedirectToAction("PruebaPacientes", "Prueba");

			}
            catch
            {
				return RedirectToAction("PruebaPacientes", "Prueba"); //Revisar aqui
			}
        }

        [HttpPost]
		public ActionResult BuscarEnPadron(string Seleccion, string Prefix)
        {

			var result = new object{};
			bool status = false;
			var msj = "";
			Padron_Imp InfoPaciente = null;
			int Resultado = 0;
			var SolicitudPrep = db.DatosGenerales.Where(x => x.Documento == Prefix).FirstOrDefault();
			var centros = db.VwCentrosSaludPrEps.Where(x => x.IdCentro == SolicitudPrep.IdDeptoDepend);

			InfoPaciente = Query_Padron_Imp.Query_Imp(Prefix);

			if (SolicitudPrep != null)
			{
				
				msj = "El Ciudadano posee actualmente una solicitud de PrEP con el ID: " + SolicitudPrep.Id + " " + SolicitudPrep.Nombres +
					" " + SolicitudPrep.Apellidos + " " + centros.FirstOrDefault().NombreCentro;

				result = new
				{
					status,
					msj
				};
				return Json(result);
			

				
			}
			else
			{

				//Validamos el porque vamos a buscar
				
				InfoPaciente = Query_Padron_Imp.Query_Imp(Prefix);

				if (InfoPaciente != null)
				{
					try
					{
						Resultado = ValidarExisteEnFappsSIRENP(Prefix);
					}
					catch (Exception ex)
					{
						msj = "La Cédula consultada no ha retornado ningún valor";
						result = new
						{
							status,
							msj
						};
						return Json(result);

					}
				}
				else 
				{
					msj = "La Cédula consultada no ha retornado ningún valor";
					result = new
					{
						status,
						msj
					};
					return Json(result);

				}
				
				if (Resultado == 1)
				{
					msj = "El Ciudadano no califica, se encuentra registrado en FAPPS.";
					result = new
					{
						status,
						msj
					};
					return Json(result);

				}
				if (Resultado == 2)
				{
					msj = "El Ciudadano no califica, se encuentra registrado en SIRENP con VIH Positivo.";
					result = new
					{
						status,
						msj
					};
					return Json(result);

				}
			}

			status = true;
			string fechaNacimiento = InfoPaciente.fecha_nacimiento.Date.ToString("yyyy-MM-dd");
			result = new { status, InfoPaciente, fechaNacimiento };
			return Json(result);
		}

		Int32 ValidarExisteEnFappsSIRENP(string DocumentoIdentidad)
		{
			var lista = new SP_ValidarUsuarioFapps_SirenP();
			string sql = "SP_ValidarUsuarioFapps_SirenP";
			Int32 Resultado = 0;


			using (var connection = new SqlConnection(db.Database.GetConnectionString()))
			{
				lista = connection.Query<SP_ValidarUsuarioFapps_SirenP> (sql, new { DocumentoIdentidad }, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
				if (lista == null)
				{
					Resultado = 0;
				}
				else
				{
					Resultado = Convert.ToInt32(lista.Resultado);

				}
			}




			return Resultado;
		}


		[HttpPost]
		public JsonResult llenarMunicipio(int id)
		{
			bool status = true;
            var lista = new List<VwMunicipio>();

			try
			{
				lista = (from a in db.VwMunicipios
				 where Convert.ToInt64(a.IdProvincia) == id
				 select a).ToList();


			}
			catch (Exception ex)
			{
				status = false;
			}

			var result = new { status,lista };
			return Json(result);
		}

		// GET: DatosGeneralesController/Edit/5
		public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DatosGeneralesController/Edit/5
        [HttpPost]
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

        
    }
}
