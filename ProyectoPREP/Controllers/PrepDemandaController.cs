using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPREP.Models;
using ProyectoPREP.Padron;
using System.Data.SqlClient;
using System.Security.Claims;

namespace ProyectoPREP.Controllers
{
    [Authorize(Roles = "Administrador,Ambos,PrEP Demanda")]
    public class PrepDemandaController : Controller
	{
		// GET: PrepDemanda
		DbPrepContext db;
		public PrepDemandaController(DbPrepContext _db)
		{

			this.db = _db;
		}


        [HttpPost]
        public JsonResult VIHPositivoSeguimiento(int IdPaciente, DateTime FechaSeguimiento, DateTime FechaPruebaVih)
        {
            bool status = true;
            int idUser = Convert.ToInt32(User.GetUserId());
            int IdDeptoDepend = Convert.ToInt32(User.GetIdDepartamento());


            var prep = db.TblPrepDemanda.FirstOrDefault(X => X.IdPaciente == IdPaciente);
            var seguimiento = new TblPrepDemandaSeguimiento();

            prep.EstatusId = 6;
            prep.Usuario = Convert.ToString(idUser);
            prep.UsuarioModifico = Convert.ToString(idUser);
            prep.FechaModificacion = DateTime.Now;
            seguimiento.IdDeptoDepend = IdDeptoDepend;


            seguimiento.IdPaciente = IdPaciente;
            seguimiento.Usuario = Convert.ToString(idUser);
            seguimiento.UsuarioModifico = Convert.ToString(idUser);
            seguimiento.FechaModificacion = DateTime.Now;
            seguimiento.FechaPruebaVih = FechaPruebaVih;
            seguimiento.FechaSeguimiento = FechaSeguimiento;
            seguimiento.IdDeptoDepend = IdDeptoDepend;
            seguimiento.ResultadoPruebaVih = "Positivo";


            db.Entry(prep).State = EntityState.Modified;
            db.TblPrepDemandaSeguimientos.Add(seguimiento);
            db.SaveChanges();



            var result = new { status };
            return Json(result);
        }

        [HttpPost]
		public JsonResult VIHPositivo(DateTime FechaPruebaVih, DateTime FechaEntregaVih, string Nombres, string Apellidos, 
			 string TieneDocumentos, string Documento, DateTime FechaIngresoSai, string Genero,int Nacionalidad,
			 int MunicipioResidencia,int ProvinciaResidencia)
		{
			int idUser = Convert.ToInt32(User.GetUserId());
			int IdDeptoDepend = Convert.ToInt32(User.GetIdDepartamento());

			bool status = true;

			var demanda = new TblPrepDemanda();
			demanda.EstatusId = 6;
			demanda.SeronegativoVih = "SI";
			demanda.FechaPruebaVih = FechaPruebaVih;
			demanda.FechaEntregaVih = FechaEntregaVih;
			demanda.Nombres = Nombres;
			demanda.Apellidos = Apellidos;
			demanda.FechaIngresoSai = FechaIngresoSai;
			demanda.TieneDocumentos = TieneDocumentos;
			demanda.Documento = Documento;
			demanda.ResultadoPruebaVih = "Positivo";
			demanda.IdDeptoDepend = IdDeptoDepend;
			demanda.Genero = Genero;
			demanda.Nacionalidad = Nacionalidad;
			demanda.MunicipioResidencia = MunicipioResidencia;
			demanda.ProvinciaResidencia = ProvinciaResidencia;
			demanda.Sexo = "M";

			demanda.Usuario = Convert.ToString(idUser);

			db.TblPrepDemanda.Add(demanda);
			db.SaveChanges();

			string idPaciente = Convert.ToString(demanda.IdPaciente);

			var result = new { status,idPaciente };
			return Json(result);
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

			var result = new { status, lista };
			return Json(result);
		}

		public ActionResult ElegibilidadPrepDemanda()
		{
			//TempData["Mensaje"] = "Operación realizada exitosamente";

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
				datos.EstatusId = 1;
				datos.TipoDocumento = "C";

				DateTime fechaNacimiento1 = (DateTime)datos.FechaNacimiento;
				var edad = CalcularEdadPrep(fechaNacimiento1);

				datos.Edad = edad;

				//REVISAR - LE QUITÉ EL COMENTARIO PARA VER SI LOS DATOS ESTABAN LLEGANDO
				db.TblPrepDemanda.Add(datos);
                db.SaveChanges();

				var Upaciente = datos.IdPaciente;
				TempData["idPaciente"] = Upaciente;
				//return View();
				return RedirectToAction("HomePrepDemanda", "PrepDemanda");

			}

			catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
			
		}
		public ActionResult ElegibilidadPasaporte()
		{
            //TempData["Mensaje"] = "Operación realizada exitosamente";

            ViewBag.Municipio = db.VwMunicipios.ToList();

			return View();
		}


		[HttpPost]
		public ActionResult ElegibilidadPasaporte(TblPrepDemanda datos)
		{
			try
            {
                int idUser = Convert.ToInt32(User.GetUserId());
                int IdDeptoDepend = Convert.ToInt32(User.GetIdDepartamento());

				datos.IdDeptoDepend = IdDeptoDepend;
				datos.Usuario = Convert.ToString(idUser);
				datos.EstatusId = 1;
				datos.TipoDocumento = "P";

				DateTime fechaNacimiento1 = (DateTime)datos.FechaNacimiento;
				var edad = CalcularEdadPrep(fechaNacimiento1);

				datos.Edad = edad;

				//REVISAR - LE QUITÉ EL COMENTARIO PARA VER SI LOS DATOS ESTABAN LLEGANDO
				db.TblPrepDemanda.Add(datos);
                db.SaveChanges();

				var Upaciente = datos.IdPaciente;
				TempData["idPaciente"] = Upaciente;
				//return View();
				return RedirectToAction("HomePrepDemanda", "PrepDemanda");

			}

			catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
			
		}
		public ActionResult ElegibilidadNSS()
		{
            //TempData["Mensaje"] = "Operación realizada exitosamente";

            ViewBag.Municipio = db.VwMunicipios.ToList();

			return View();
		}


		[HttpPost]
		public ActionResult ElegibilidadNSS(TblPrepDemanda datos)
		{
			try
            {
                int idUser = Convert.ToInt32(User.GetUserId());
                int IdDeptoDepend = Convert.ToInt32(User.GetIdDepartamento());

				datos.IdDeptoDepend = IdDeptoDepend;
				datos.Usuario = Convert.ToString(idUser);
				datos.EstatusId = 1;
				datos.TipoDocumento = "NSS";

				DateTime fechaNacimiento1 = (DateTime)datos.FechaNacimiento;
				var edad = CalcularEdadPrep(fechaNacimiento1);

				datos.Edad = edad;

				//REVISAR - LE QUITÉ EL COMENTARIO PARA VER SI LOS DATOS ESTABAN LLEGANDO
				db.TblPrepDemanda.Add(datos);
                db.SaveChanges();

				var Upaciente = datos.IdPaciente;
				TempData["idPaciente"] = Upaciente;
				//return View();
				return RedirectToAction("HomePrepDemanda", "PrepDemanda");

			}

			catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
			
		}

		public ActionResult ElegibilidadSinDocumento()
		{
			ViewBag.Municipio = db.VwMunicipios.ToList();

			return View();
		}
		

		[HttpPost]
		public ActionResult ElegibilidadSinDocumento(TblPrepDemanda datos)
		{
			try
			{
				int idUser = Convert.ToInt32(User.GetUserId());
				int IdDeptoDepend = Convert.ToInt32(User.GetIdDepartamento());
				datos.Documento = "SN";
				datos.TipoDocumento = "SN";
				datos.TieneDocumentos = "NO";
				datos.EstatusId = 1;

				DateTime fechaNacimiento1 = (DateTime) datos.FechaNacimiento;
				var edad = CalcularEdadPrep(fechaNacimiento1);

				datos.Edad = edad;
				datos.IdDeptoDepend = IdDeptoDepend;
				datos.Usuario = Convert.ToString(idUser);

				//REVISAR - LE QUITÉ EL COMENTARIO PARA VER SI LOS DATOS ESTABAN LLEGANDO
				db.TblPrepDemanda.Add(datos);
				db.SaveChanges();

				var Upaciente = datos.IdPaciente;
				TempData["idPaciente"] = Upaciente;
				return View();

			}

			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}

		}
		
		public ActionResult DemandaVer(int id)
		{
			var lista = new List<VwMunicipio>();
			var datos = db.TblPrepDemanda.FirstOrDefault(d => d.IdPaciente == id);
			var nacionalidad = db.VwNacionalidads.FirstOrDefault(x => Convert.ToInt32(x.IdNacionalidad) == datos.Nacionalidad);

			var model1 = db.TblPrepDemanda.Where(x => x.IdPaciente == id).FirstOrDefault();

			lista = (from b in db.VwMunicipios
					 where Convert.ToInt64(b.IdProvincia) == Convert.ToInt64(model1.ProvinciaResidencia)
					 select b).ToList();

			ViewBag.Municipios = lista;
			ViewBag.IdMunicipios = model1.MunicipioResidencia;
			ViewBag.IdProvincia = model1.ProvinciaResidencia;
			ViewBag.tipoDocumento = model1.TipoDocumento;
			ViewBag.documento = model1.Documento;
			return View(datos);
		}

		public ActionResult SeguimientoPrepDemanda(int id)
		{

			var datos = db.TblPrepDemanda.FirstOrDefault(d => d.IdPaciente == id);
			var nacionalidad = db.VwNacionalidads.FirstOrDefault(x => Convert.ToInt32(x.IdNacionalidad) == datos.Nacionalidad);


			ViewBag.Nombre = datos.Nombres;
			ViewBag.Apellido = datos.Apellidos;

			ViewBag.Sexo = datos.Sexo;
			ViewBag.Edad = datos.Edad;
			ViewBag.Peso = datos.Peso;
			ViewBag.Genero = datos.Genero;
			ViewBag.nacionalidad = nacionalidad.Nacionalidad;
			ViewBag.IdPaciente = datos.IdPaciente;
			ViewBag.IdPred = datos.IdPaciente;
			return View();
		}

		[HttpPost]
		public ActionResult SeguimientoPrepDemanda(TblPrepDemandaSeguimiento datos)
		{
			try
			{
				int idUser = Convert.ToInt32(User.GetUserId());
				int IdDeptoDepend = Convert.ToInt32(User.GetIdDepartamento());

				datos.IdDeptoDepend = IdDeptoDepend;
				datos.Usuario = Convert.ToString(idUser);
				datos.UsuarioModifico = Convert.ToString(idUser);
				datos.FechaModificacion = DateTime.Now;

				//REVISAR - LE QUITÉ EL COMENTARIO PARA VER SI LOS DATOS ESTABAN LLEGANDO
				db.TblPrepDemandaSeguimientos.Add(datos);
				db.SaveChanges();

				return RedirectToAction("HomePrepDemanda", "PrepDemanda");

			}

			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}

		}


        public ActionResult HomePrepDemanda()
        {
			int idUser = Convert.ToInt32(User.GetUserId());
			int IdDeptoDepend = Convert.ToInt32(User.GetIdDepartamento());
			string admin = User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(x => x.Value).FirstOrDefault();

			var lista = new List<DatosGenerales>();
			string sql = "ListaPrep_Demanda";
			string sqlAdmin = "ListaPrep_DemandaAdmin";

			if (admin == "Administrador")
			{
				using (var connection = new SqlConnection(db.Database.GetConnectionString()))
				{
					lista = connection.Query<DatosGenerales>(sqlAdmin, commandType: System.Data.CommandType.StoredProcedure).ToList();
					return View(lista);

				}
			}


			using (var connection = new SqlConnection(db.Database.GetConnectionString()))
			{
				lista = connection.Query<DatosGenerales>(sql, new { IdDeptoDepend }, commandType: System.Data.CommandType.StoredProcedure).ToList();

			}



			return View(lista);


        }



		public ActionResult DemandaEditar(int id)
		{

			var lista = new List<VwMunicipio>();
			var datos = db.TblPrepDemanda.FirstOrDefault(d => d.IdPaciente == id);
            var nacionalidad = db.VwNacionalidads.FirstOrDefault(x => Convert.ToInt32(x.IdNacionalidad) == datos.Nacionalidad);

			var model1 = db.TblPrepDemanda.Where(x => x.IdPaciente == id).FirstOrDefault();

			lista = (from b in db.VwMunicipios
					 where Convert.ToInt64(b.IdProvincia) == Convert.ToInt64(model1.ProvinciaResidencia)
					 select b).ToList();



			ViewBag.Municipio = db.VwMunicipios.ToList();
			//ViewBag.Peso = datos.Peso;
			ViewBag.Edad = datos.Edad;
			//ViewBag.Sexo = datos.Sexo;
			//ViewBag.Genero = datos.Genero;

			ViewBag.Municipios = lista;
			ViewBag.IdMunicipios = model1.MunicipioResidencia;
			ViewBag.IdProvincia = model1.ProvinciaResidencia;
			ViewBag.tipoDocumento = model1.TipoDocumento;
			ViewBag.documento = model1.Documento;
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
			if (demanda.ResultadoPruebaVih == "Positivo")
			{
                demanda.EstatusId = 6;

			}
			else
			{
				demanda.EstatusId = 1;

			}



			db.Entry(demanda).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("HomePrepDemanda", "PrepDemanda");

		}

		

		[HttpPost]
		public ActionResult BuscarEnPadron(string Seleccion, string Prefix)
		{

			var result = new object { };
			bool status = false;
			var msj = "";
			Padron_Imp InfoPaciente = null;
			int Resultado = 0;
			var SolicitudPrep = db.DatosGenerales.Where(x => x.Documento == Prefix).FirstOrDefault();
			var SolicitudPrepDemanda = db.TblPrepDemanda.Where(x => x.Documento == Prefix).FirstOrDefault();
			var centros = db.VwCentrosSaludPrEps.Where(x => x.IdCentro == SolicitudPrep.IdDeptoDepend);
			var centrosDemanda = db.VwCentrosSaludPrEps.Where(x => x.IdCentro == SolicitudPrepDemanda.IdDeptoDepend);


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
			else if(SolicitudPrepDemanda != null){
				msj = "El Ciudadano posee actualmente una solicitud de PrEP Demanda con el ID: " + SolicitudPrepDemanda.IdPaciente + " " + SolicitudPrepDemanda.Nombres +
					" " + SolicitudPrepDemanda.Apellidos + " " + centrosDemanda.FirstOrDefault().NombreCentro;

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
						Resultado = ValidarExisteEnFappsSIRENPPrep(Prefix);
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
				
				if (Resultado == 3)
				{
					msj = "El Ciudadano no califica, se encuentra registrado en SIRENP y FAPPS.";
					result = new
					{
						status,
						msj
					};
					return Json(result);

				}
			}

			if (InfoPaciente.apellido2 == null)
			{
				InfoPaciente.apellido2 = "";

			}

			status = true;
			string fechaNacimiento = InfoPaciente.fecha_nacimiento.Date.ToString("yyyy-MM-dd");
			DateTime fechaNacimiento1 = InfoPaciente.fecha_nacimiento.Date;
			var edad = CalcularEdadPrep(fechaNacimiento1);
			result = new { status, InfoPaciente, fechaNacimiento, edad };
			return Json(result);
		}


		[HttpPost]
		public ActionResult ValidarNSS(string Seleccion, string Prefix)
		{

			var result = new object { };
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
						Resultado = ValidarExisteEnFappsSIRENPPrep(Prefix);
					}
					catch (Exception ex)
					{
						msj = "El NSS consultado no ha retornado ningún valor";
						result = new
						{
							status,
							msj
						};
						return Json(result);

					}
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
			result = new { status, InfoPaciente };
			return Json(result);
		}


		[HttpPost]
		public ActionResult ValidarPasaporte(string Seleccion, string Prefix)
		{

			var result = new object { };
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
						Resultado = ValidarExisteEnFappsSIRENPPrep(Prefix);
					}
					catch (Exception ex)
					{
						msj = "El pasaporte consultado no ha retornado ningún valor";
						result = new
						{
							status,
							msj
						};
						return Json(result);

					}
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
			result = new { status, InfoPaciente };
			return Json(result);
		}



		int CalcularEdadPrep(DateTime fechaNacimiento)
		{
			DateTime fechaActual = DateTime.Now;
			if (fechaActual.Month > fechaNacimiento.Month || fechaNacimiento.Month == fechaActual.Month && fechaActual.Day > fechaNacimiento.Day)
			{
				return fechaActual.Year - fechaNacimiento.Year;
			}
			return fechaActual.Year - fechaNacimiento.Year - 1;
		}


		public JsonResult CalcularEdadSinDocumentos(DateTime fechaNacimiento)
		{
			bool status = true;
			var lista = new List<VwMunicipio>();
			int edad = 0;
			try
			{
				DateTime fechaActual = DateTime.Now;
				if (fechaActual.Month > fechaNacimiento.Month || fechaNacimiento.Month == fechaActual.Month && fechaActual.Day > fechaNacimiento.Day)
				{
					edad = fechaActual.Year - fechaNacimiento.Year;
				}
				edad = fechaActual.Year - fechaNacimiento.Year - 1;



			}
			catch (Exception ex)
			{
				status = false;
			}

			var result = new { status, edad };
			return Json(result);
		}



		Int32 ValidarExisteEnFappsSIRENPPrep(string DocumentoIdentidad)
		{
			var lista = new SP_ValidarUsuarioFapps_SirenP();
			string sql = "SP_ValidarUsuarioFapps_SirenP_Prep";
			Int32 Resultado = 0;


			using (var connection = new SqlConnection(db.Database.GetConnectionString()))
			{
				lista = connection.Query<SP_ValidarUsuarioFapps_SirenP>(sql, new { DocumentoIdentidad }, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
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


        public ActionResult SeguimientosVer(int id)
        {
            int idUser = Convert.ToInt32(User.GetUserId());
            int IdDeptoDepend = Convert.ToInt32(User.GetIdDepartamento());
            string admin = User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(x => x.Value).FirstOrDefault();

            var datos = db.TblPrepDemanda.FirstOrDefault(d => d.IdPaciente == id);
			var segui = db.TblPrepDemandaSeguimientos.Where(s=> s.IdPaciente == datos.IdPaciente ).ToList();
			var condicion = "";


            var lista = new DatosGenerales();
            string sql = "ListaPrep_Demanda";
            string sqlAdmin = "ListaPrep_DemandaAdmin";

            if (admin == "Administrador")
            {
                using (var connection = new SqlConnection(db.Database.GetConnectionString()))
                {
                    lista = connection.Query<DatosGenerales>(sqlAdmin, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault(x => x.Id == id);

                }
			}
			else
			{
                using (var connection = new SqlConnection(db.Database.GetConnectionString()))
                {
                    lista = connection.Query<DatosGenerales>(sql, new { IdDeptoDepend }, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault(x => x.Id == id);

                }
            }

         

			if (lista.Condicion == true)
			{
				condicion = "True";
			}

			ViewBag.estatusId = lista.EstatusId;
			ViewBag.condicionnn = condicion;

            ViewBag.Nombres = datos.Nombres;
            ViewBag.Apellidos = datos.Apellidos;

            ViewBag.Sexo = datos.Sexo;

            ViewBag.IdPaciente = datos.IdPaciente;
            return View(segui);
        }


        [HttpGet]
        public ActionResult SeguimientosVerPorId(int id)
        {
            var segui = db.TblPrepDemandaSeguimientos.Where(d => d.IdSeguimiento == id).FirstOrDefault();
			var datos = db.TblPrepDemanda.FirstOrDefault(d => d.IdPaciente == segui.IdPaciente);

            ViewBag.Nombres = datos.Nombres;
            ViewBag.Apellidos = datos.Apellidos;
            ViewBag.IdPaciente = datos.IdPaciente;

            return View(segui);
        }
    }
}
