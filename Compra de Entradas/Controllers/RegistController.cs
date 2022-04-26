using Compra_de_Entradas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Compra_de_Entradas.Controllers
{
    public class RegistController : Controller
    {
        // GET: RegistController
        private readonly AplicationDbContext context;
        public RegistController(AplicationDbContext context)
        {
            this.context = context;
        }
        public ActionResult Registrarse()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrarse(Usuarios user)
        {
            if (ModelState.IsValid)
            {
                context.Usuarios.Add(user);
                context.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        // GET: RegistController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistController/Create
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

        // GET: RegistController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistController/Edit/5
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

        // GET: RegistController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistController/Delete/5
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
