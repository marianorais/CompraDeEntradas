using Compra_de_Entradas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Compra_de_Entradas.Controllers
{
    public class PelisController : Controller
    {
        // GET: PelisController
        private readonly AplicationDbContext context;
        public PelisController(AplicationDbContext context)
        {
            this.context = context;
        }
        public ActionResult Movies()
        {
            var listMovie = context.Peliculas.OrderBy(s => s.Id_pelicula).ToList();
            return View(listMovie);
        }


        // GET: PelisController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PelisController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: PelisController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PelisController/Edit/5
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

        // GET: PelisController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            //_repo.Delete(id);
            var peli = context.Peliculas.Where(s => s.Id_pelicula == id).FirstOrDefault();
            if (peli != null)
            {
                context.Peliculas.Remove(peli);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // POST: PelisController/Delete/5
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
