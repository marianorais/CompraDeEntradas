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
    public class CompraController : Controller
    {
        private readonly AplicationDbContext context;
        public CompraController(AplicationDbContext context)
        {
            this.context = context;
        }


        public ActionResult ticketShow(int id) 
        {
            var listaEntradas = context.Entradas.ToList();
            return View(listaEntradas);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ticketShow()
        {
            return View();
        }


        public ActionResult Ticket(int id)
        {
            //Entradas _Entrada = new Entradas(){
            //   Cantidad = 3,
            //    Fila = "E7",
            //    Id_usuario=27,
            //   Id_pelicula=id //12
            //};
            
            var fav = context.Movie_fav.Include("Usuarios").FirstOrDefault();
            var user = fav.Usuarios;
            Entradas _NuevaEntrada = new Entradas()
            {
                Cantidad=1,
                Id_pelicula = id
            };
            return View(_NuevaEntrada);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ticket(Entradas ticket)
        {
            if (ModelState.IsValid)
            {
                context.Entradas.Add(ticket);
                //var tick = context.Entradas.Include("Usuarios").Include("Peliculas")
                //    .FirstOrDefault(a=>a.Id_pelicula==Id_pelicula);

                context.SaveChanges();
                return RedirectToAction("Movies", "Pelis");
            }
            return View();
        }

        // GET: CompraController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompraController/Edit/5
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

        // GET: CompraController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            //_repo.Delete(id);
            var des = context.Entradas.Where(s => s.Id_entrada == id).FirstOrDefault();
            if (des != null)
            {
                context.Entradas.Remove(des);
                context.SaveChanges();
            }
            return RedirectToAction("ticketShow","Compra");
        }

        // POST: CompraController/Delete/5
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
