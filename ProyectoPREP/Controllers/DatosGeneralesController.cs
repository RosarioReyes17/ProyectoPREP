using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoPREP.Models;

namespace ProyectoPREP.Controllers
{
    public class DatosGeneralesController : Controller
    {
        // GET: DatosGeneralesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DatosGeneralesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DatosGeneralesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DatosGeneralesController/Create
        [HttpPost]
        public ActionResult Create(DatosGenerale generale,FormularioPrep formulario)
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

        // GET: DatosGeneralesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DatosGeneralesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: DatosGeneralesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DatosGeneralesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
