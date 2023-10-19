using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectoPREP.Models;
using ProyectoPREP.Padron;
using System.Data;
using X.PagedList;
//using System.Data.Entity;
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


        public ActionResult ConsultaDatosGenerales(int? page)
        {
            int pageSize = 25; // Número de elementos por página
            int pageNumber = (page ?? 1); // Número de página actual

            //List<DatosGenerale> data = db.DatosGenerales.ToList();

            //IPagedList<DatosGenerale> pagedData = data.ToPagedList(pageNumber, pageSize);



			var lista = new List<DatosGeneralesNacionalidad>();
			string sql = "DatosGeneralesNacionalidad";


			using (var connection = new SqlConnection(db.Database.GetConnectionString()))
			{
				lista = connection.Query<DatosGeneralesNacionalidad>(sql, commandType: System.Data.CommandType.StoredProcedure).ToList();
			
			}

			return View(lista);
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
		public ActionResult CreateSinDocumento(FormularioPrep formulario)
		{
			try
			{
				
				formulario.DatosGenerales.Usuario = Convert.ToString(1);
				formulario.DatosGenerales.IdDeptoDepend = 1641;
				formulario.DatosGenerales.EnRiesgo = "Si";
			
				if (formulario.DatosGenerales.TieneDocumentos == "Si")
				{
					formulario.DatosGenerales.TipoDocumento = "P";

				}
				else
				{
					formulario.DatosGenerales.TipoDocumento = "SN";

				}

				db.DatosGenerales.Add(formulario.DatosGenerales);

				formulario.Usuario = Convert.ToString(1);
				formulario.DatosGeneralesId = formulario.DatosGenerales.Id;
				formulario.Secuencia = 0;
				formulario.DatosGenerales.FormularioPreps.Add(formulario);
				db.SaveChanges();

				return RedirectToAction("ConsultaDatosGenerales", "DatosGenerales");

			}
			catch	
			{
				return RedirectToAction("ConsultaDatosGenerales", "DatosGenerales"); //Revisar aqui
			}
		}
		// POST: DatosGeneralesController/Create
		[HttpPost]
        public ActionResult CreateCedula(FormularioPrep formulario)
        {
            try
            {
				
				formulario.DatosGenerales.Usuario = Convert.ToString(1);
				formulario.DatosGenerales.IdDeptoDepend = 1641;
				formulario.DatosGenerales.TieneDocumentos = "Si";
				formulario.DatosGenerales.TipoDocumento = "C";
				formulario.DatosGenerales.EnRiesgo = "Si";

				db.DatosGenerales.Add(formulario.DatosGenerales);

				formulario.Usuario = Convert.ToString(1);
				formulario.Secuencia = 0;
				formulario.DatosGeneralesId = formulario.DatosGenerales.Id;
				formulario.DatosGenerales.FormularioPreps.Add(formulario);
				db.SaveChanges();


				return RedirectToAction("ConsultaDatosGenerales", "DatosGenerales");

			}
            catch
            {
				return RedirectToAction("ConsultaDatosGenerales", "DatosGenerales"); //Revisar aqui
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

				if (InfoPaciente != null && InfoPaciente.valido == true)
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
					msj = "La Cédula consultada no ha retornado ningún valor, favor de confirmar su Cédula";
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
		public ActionResult EditarDatosGenerales(int? id)
        {
			try
			{
				var lista = new List<VwMunicipio>();

				FormularioPrep? model1 = new FormularioPrep();

                model1 = db.FormularioPreps.Where(x => x.DatosGenerales.Id == id).Include(x => x.DatosGenerales).FirstOrDefault();

				lista = (from b in db.VwMunicipios
						 where Convert.ToInt64(b.IdProvincia) == Convert.ToInt64(model1.DatosGenerales.ProvinciaResidencia)
						 select b).ToList();

				

				ViewBag.Municipios = lista;
				ViewBag.IdMunicipios = model1.DatosGenerales.MunicipioResidencia;
				ViewBag.IdProvincia = model1.DatosGenerales.ProvinciaResidencia;
				ViewBag.idDatos = model1.DatosGenerales.Id;
				
				return View(model1);
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
			
        }

        // POST: DatosGeneralesController/Edit/5
        [HttpPost]
        public ActionResult EditarDatosGenerales( int idFormulario , FormularioPrep formulario)
        {
            try
            {

				formulario.DatosGenerales.FechaModificacion = DateTime.Now;
				formulario.DatosGenerales.UsuarioModifico = Convert.ToString(1);
				formulario.FechaModificacion = DateTime.Now;
				formulario.UsuarioModifico = Convert.ToString(1);

				db.Entry(formulario).State = EntityState.Modified;
				db.Entry(formulario.DatosGenerales).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("ConsultaDatosGenerales", "DatosGenerales");


			}
			catch(Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }

        
    }
}
