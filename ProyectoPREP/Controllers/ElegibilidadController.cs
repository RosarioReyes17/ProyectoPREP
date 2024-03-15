using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPREP.Models;

namespace ProyectoPREP.Controllers
{
    [Authorize(Roles = "Administrador,Psicólogo Medicos")]

    public class ElegibilidadController : Controller
	{

        DbPrepContext db;
        public ElegibilidadController(DbPrepContext _db)
        {
            this.db = _db;
        }
        // GET: ElegibilidadController


        public ActionResult ElegibilidadVer(int id)
        {
            var datos = db.DatosGenerales.FirstOrDefault(d => d.Id == id);
            var formu = db.FormularioPreps.FirstOrDefault(d => d.DatosGeneralesId == id);
            var elegiHistori = db.ElegibilidadPrepHistoricos.Where(d => d.FormularioPrepId == formu.Id).ToList();
            var nacionalidad = db.VwNacionalidads.FirstOrDefault(x => Convert.ToInt32(x.IdNacionalidad) == datos.Nacionalidad);



            ViewBag.Nombre = datos.Nombres;
            ViewBag.Apellido = datos.Apellidos;

            ViewBag.Sexo = datos.Sexo;
            ViewBag.nacionalidad = nacionalidad.Nacionalidad;
            ViewBag.IdDatos = datos.Id;
            return View(elegiHistori);
        }



        [HttpGet]
        public ActionResult ElegibilidadVerPorId(int id)
        {
            var elegi = db.ElegibilidadPreps.FirstOrDefault(d => d.Id == id);
            var elegiHistoco = db.ElegibilidadPrepHistoricos.FirstOrDefault(d => d.IdFila == id);
            var formu = db.FormularioPreps.FirstOrDefault(d => d.Id == elegi.FormularioPrepId);
            var datos = db.DatosGenerales.FirstOrDefault(d => d.Id == formu.DatosGeneralesId);
            var nacionalidad = db.VwNacionalidads.FirstOrDefault(x => Convert.ToInt32(x.IdNacionalidad) == datos.Nacionalidad);


            ViewBag.Nombre = datos.Nombres;
            ViewBag.Apellido = datos.Apellidos;
            ViewBag.IdDatos = datos.Id;



            ViewBag.Sexo = datos.Sexo;
            ViewBag.nacionalidad = nacionalidad.Nacionalidad;

            return View(elegiHistoco);
        }

        public JsonResult VIHPositivo(int id, DateTime FechaPruebaVih,DateTime FechaEntregaVih)
		{
            int idUser = Convert.ToInt32(User.GetUserId());

            bool status = true;

            var elegibilidad = db.ElegibilidadPreps.FirstOrDefault(x => x.Id == id);
			elegibilidad.Estatus = 6;
			elegibilidad.SeronegativoVih = "No";
			elegibilidad.FechaPruebaVih = FechaPruebaVih;
			elegibilidad.FechaEntregaVih = FechaEntregaVih;
			elegibilidad.ResultadoPruebaVih = "Positivo";
			elegibilidad.Usuario = Convert.ToString(idUser);

			db.Entry(elegibilidad).State = EntityState.Modified;
			db.SaveChanges();

            var result = new { status };
            return Json(result);
        }


        public ActionResult FormularioElegibilidad(int id)
		{
			var formulario = db.FormularioPreps.Where(p => p.DatosGeneralesId == id).FirstOrDefault();
			//var datos = db.DatosGenerales.Where(p => p.Id == id).FirstOrDefault();
			var model = new ElegibilidadPrep();
			model = db.ElegibilidadPreps.Where(x=>x.FormularioPrepId == formulario.Id).
				Include(x=>x.FormularioPrep).ThenInclude(x=>x.DatosGenerales).FirstOrDefault();


			
			var edad = model.FormularioPrep.DatosGenerales.Edad;
			if (edad == null)
			{
				edad = 0;
			}
			
			string fecha = model.FormularioPrep.DatosGenerales.FechaIngresoSai.ToString("yyyy-MM-dd");
			

            ViewBag.Peso = model.FormularioPrep.DatosGenerales.Peso;
			ViewBag.Edad = Convert.ToDecimal(edad);
			ViewBag.Sexo = model.FormularioPrep.DatosGenerales.Sexo;
			ViewBag.IdDatos = model.FormularioPrep.DatosGenerales.Id;
			ViewBag.IdElegibilidad = model.Id;
			ViewBag.FechaPrep = fecha;
			ViewBag.Sexo = model.FormularioPrep.DatosGenerales.Sexo;
			ViewBag.Genero = model.FormularioPrep.DatosGenerales.Genero;
			ViewBag.Nombre = model.FormularioPrep.DatosGenerales.Nombres +" "+ model.FormularioPrep.DatosGenerales.Apellidos;


            if (model.FechaReintegro != null)
            {
                return RedirectToAction("FormularioElegibilidadReintegrado", "Elegibilidad", new {id=id});

            }
            
			return View(model);
		}

		// POST: ElegibilidadController/Create
		[HttpPost]
		public ActionResult FormularioElegibilidad(int IdDatos, ElegibilidadPrep elegibilidad, Seguimiento seguimiento)
		{
			try
			{
                int idUser = Convert.ToInt32(User.GetUserId());

                var formulario = db.FormularioPreps.Where(X => X.DatosGeneralesId == IdDatos).FirstOrDefault();

                var elegi = db.ElegibilidadPreps.Where(X => X.FormularioPrepId == formulario.Id).FirstOrDefault();

				if (elegibilidad.ResultadoCargaViralPcr == null && elegibilidad.CargaViralPcr == "Si" && elegibilidad.ResultadoCreatinina == null)
				{
					using (DbPrepContext db = new DbPrepContext())
					{

						int id = elegi.Id;

						elegibilidad.Id = id;
						elegibilidad.Usuario = Convert.ToString(idUser);
						elegibilidad.Estatus = 2;
                        elegibilidad.FormularioPrepId = elegi.FormularioPrepId;

                        
						db.ElegibilidadPreps.Entry(elegibilidad).State = EntityState.Modified;
						db.SaveChanges();
					}
					
					return RedirectToAction("DatosGeneralesPorElegibilidad", "DatosGenerales");

                }



                using (DbPrepContext db = new DbPrepContext())
				{
                    int id = elegi.Id;

                    elegibilidad.Id = id;
                    elegibilidad.Usuario = Convert.ToString(idUser);
                    elegibilidad.Estatus = 3;
					elegibilidad.FormularioPrepId = elegi.FormularioPrepId;

                   
					db.ElegibilidadPreps.Entry(elegibilidad).State = EntityState.Modified;
					db.SaveChanges();

				}

               
				return RedirectToAction("DatosGeneralesPorElegibilidad", "DatosGenerales");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET: ElegibilidadController/Edit/5


        public ActionResult FormularioElegibilidadReintegrado(int id)
        {
            var formulario = db.FormularioPreps.Where(p => p.DatosGeneralesId == id).FirstOrDefault();
            //var datos = db.DatosGenerales.Where(p => p.Id == id).FirstOrDefault();
            var model = new ElegibilidadPrep();
            model = db.ElegibilidadPreps.Where(x => x.FormularioPrepId == formulario.Id).
                Include(x => x.FormularioPrep).ThenInclude(x => x.DatosGenerales).FirstOrDefault();



            var edad = model.FormularioPrep.DatosGenerales.Edad;
            if (edad == null)
            {
                edad = 0;
            }

            string fecha = model.FormularioPrep.DatosGenerales.FechaIngresoSai.ToString("yyyy-MM-dd");


            ViewBag.Peso = model.FormularioPrep.DatosGenerales.Peso;
            ViewBag.Edad = Convert.ToDecimal(edad);
            ViewBag.Sexo = model.FormularioPrep.DatosGenerales.Sexo;
            ViewBag.IdDatos = model.FormularioPrep.DatosGenerales.Id;
            ViewBag.IdElegibilidad = model.Id;
            ViewBag.FechaPrep = fecha;
            ViewBag.Sexo = model.FormularioPrep.DatosGenerales.Sexo;
            ViewBag.Genero = model.FormularioPrep.DatosGenerales.Genero;
            ViewBag.Nombre = model.FormularioPrep.DatosGenerales.Nombres + " " + model.FormularioPrep.DatosGenerales.Apellidos;

          
            return View();
        }

        // POST: ElegibilidadController/Create
        [HttpPost]
        public ActionResult FormularioElegibilidadReintegrado(int IdDatos, ElegibilidadPrep elegibilidad, Seguimiento seguimiento)
        {
            try
            {
                int idUser = Convert.ToInt32(User.GetUserId());

                var formulario = db.FormularioPreps.Where(X => X.DatosGeneralesId == IdDatos).FirstOrDefault();

                var elegi = db.ElegibilidadPreps.Where(X => X.FormularioPrepId == formulario.Id).FirstOrDefault();

                if (elegibilidad.ResultadoCargaViralPcr == null && elegibilidad.CargaViralPcr == "Si" && elegibilidad.ResultadoCreatinina == null)
                {
                    using (DbPrepContext db = new DbPrepContext())
                    {

                        int id = elegi.Id;

                        elegibilidad.Id = id;
                        elegibilidad.Usuario = Convert.ToString(idUser);
                        elegibilidad.Estatus = 2;
                        elegibilidad.FormularioPrepId = elegi.FormularioPrepId;


                        db.ElegibilidadPreps.Entry(elegibilidad).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                    return RedirectToAction("DatosGeneralesPorElegibilidad", "DatosGenerales");

                }



                using (DbPrepContext db = new DbPrepContext())
                {
                    int id = elegi.Id;

                    elegibilidad.Id = id;
                    elegibilidad.Usuario = Convert.ToString(idUser);
                    elegibilidad.Estatus = 3;
                    elegibilidad.FormularioPrepId = elegi.FormularioPrepId;


                    db.ElegibilidadPreps.Entry(elegibilidad).State = EntityState.Modified;
                    db.SaveChanges();

                }


                return RedirectToAction("DatosGeneralesPorElegibilidad", "DatosGenerales");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        public JsonResult PCRDetectado(int IdDatos, ElegibilidadPrep elegibilidad)
		{
            int idUser = Convert.ToInt32(User.GetUserId());

            var formulario = db.FormularioPreps.Where(X => X.DatosGeneralesId == IdDatos).FirstOrDefault();

            var elegi = db.ElegibilidadPreps.Where(X => X.FormularioPrepId == formulario.Id).FirstOrDefault();

            using (DbPrepContext db = new DbPrepContext())
            {
				var estatus = true;
				//int id = elegi.Id;

				elegi.SeronegativoVih = elegibilidad.SeronegativoVih;
				elegi.FechaPruebaVih = elegibilidad.FechaPruebaVih;
				elegi.FechaEntregaVih = elegibilidad.FechaEntregaVih;
				elegi.ResultadoPruebaVih = elegibilidad.ResultadoPruebaVih;
				elegi.RiesgoInfeccionVih = elegibilidad.RiesgoInfeccionVih;
				elegi.SignosSintomas = elegibilidad.SignosSintomas;

				elegi.Linfadenopatias = elegibilidad.Linfadenopatias;
				elegi.FiebreDesconocida = elegibilidad.FiebreDesconocida;
				elegi.DiarreaProlongada = elegibilidad.DiarreaProlongada;
				elegi.ErupcionesPiel = elegibilidad.ErupcionesPiel;
				elegi.InfeccionesRecurrentes = elegibilidad.InfeccionesRecurrentes;
				elegi.HepatoEsplenomegalia = elegibilidad.HepatoEsplenomegalia;

				elegi.CargaViralPcr = elegibilidad.CargaViralPcr;
				elegi.FechaVisitaPcr = elegibilidad.FechaVisitaPcr;
				elegi.FechaPruebaPcr = elegibilidad.FechaPruebaPcr;
				elegi.ResultadoCargaViralPcr = "Detectado";


				//elegibilidad.Id = id;
				elegi.Usuario = Convert.ToString(idUser);
				elegi.Estatus = 6;

				
				db.ElegibilidadPreps.Entry(elegi).State = EntityState.Modified;
				db.SaveChanges();

            }

            var result = new
            {
                estatus = true
            };
            return Json(result);
        }

        public JsonResult CreatininaMenor60(int IdDatos, ElegibilidadPrep elegibilidad)
        {
            int idUser = Convert.ToInt32(User.GetUserId());

            var formulario = db.FormularioPreps.Where(X => X.DatosGeneralesId == IdDatos).FirstOrDefault();

            var elegi = db.ElegibilidadPreps.Where(X => X.FormularioPrepId == formulario.Id).FirstOrDefault();

            using (DbPrepContext db = new DbPrepContext())
            {
                var estatus = true;
                //int id = elegi.Id;

                elegi.SeronegativoVih = elegibilidad.SeronegativoVih;
                elegi.FechaPruebaVih = elegibilidad.FechaPruebaVih;
                elegi.FechaEntregaVih = elegibilidad.FechaEntregaVih;
                elegi.ResultadoPruebaVih = elegibilidad.ResultadoPruebaVih;
                elegi.RiesgoInfeccionVih = elegibilidad.RiesgoInfeccionVih;
                elegi.SignosSintomas = elegibilidad.SignosSintomas;

                elegi.Linfadenopatias = elegibilidad.Linfadenopatias;
                elegi.FiebreDesconocida = elegibilidad.FiebreDesconocida;
                elegi.DiarreaProlongada = elegibilidad.DiarreaProlongada;
                elegi.ErupcionesPiel = elegibilidad.ErupcionesPiel;
                elegi.InfeccionesRecurrentes = elegibilidad.InfeccionesRecurrentes;
                elegi.HepatoEsplenomegalia = elegibilidad.HepatoEsplenomegalia;

                elegi.CargaViralPcr = elegibilidad.CargaViralPcr;



                //elegibilidad.Id = id;
                elegi.Usuario = Convert.ToString(idUser);
                elegi.Estatus = 2;


                db.ElegibilidadPreps.Entry(elegi).State = EntityState.Modified;
                db.SaveChanges();

            }

            var result = new
            {
                estatus = true
            };
            return Json(result);
        }

      
		
		
	}
}
