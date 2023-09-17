using Microsoft.AspNetCore.Mvc;
using ProyectoPREP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace PROYECTO_PREP.Controllers
{
    public class pruebaController : Controller
    {
        DbPrepContext _context = new DbPrepContext();

        // GET: prueba
        public ActionResult PruebaPacientes()
        {

            List<DatosGenerale> data = _context.DatosGenerales.ToList();
            ViewBag.data = data;
            return View();
        }

    }
        
}