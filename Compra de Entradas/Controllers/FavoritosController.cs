using Compra_de_Entradas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Compra_de_Entradas.Controllers
{
    public class FavoritosController : Controller
    {
        private readonly AplicationDbContext context;
        public FavoritosController(AplicationDbContext context)
        {
            this.context = context;
        }
        // GET: FavoritosController
        public ActionResult Fav(int id)
        {
            if (id <= 0)
                return BadRequest();

            //_repo.Delete(id);

            var peli = context.Peliculas.Where(s => s.Id_pelicula == id).FirstOrDefault();
            if (peli != null)
            {
                Movie_fav _MovieFav = new Movie_fav()
                {
                    Titulo = peli.Titulo,
                    Duracion = peli.Duracion,
                    Anio = peli.Anio,
                    Id_usuario = 27 //26-29
                };
                context.Movie_fav.Add(_MovieFav);
                context.SaveChanges();
            }
            return RedirectToAction("ticketShow","Compra");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Fav()
        {

            return View();
        }
        public ActionResult MovieFavShow(int id) 
        {
            //var listFavMovie = context.Movie_fav.ToList();
            var fav = context.Movie_fav.Where(a=>a.Id_usuario==id).ToList();
            
            return View(fav);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MovieFavShow(Movie_fav movieFav)
        {
            var listFavMovie = context.Movie_fav.ToList();
            return View();
        }

        // GET: FavoritosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FavoritosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FavoritosController/Create
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

        // GET: FavoritosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FavoritosController/Edit/5
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

        // GET: FavoritosController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            //_repo.Delete(id);
            var movieFav = context.Movie_fav.Where(s => s.Id_pelicula == id).FirstOrDefault();
            if (movieFav != null)
            {
                context.Movie_fav.Remove(movieFav);
                context.SaveChanges();
            }
            return RedirectToAction("MovieFavShow", "Favoritos");
        }

        // POST: FavoritosController/Delete/5
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
