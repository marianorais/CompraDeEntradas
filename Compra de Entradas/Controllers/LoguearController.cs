using Compra_de_Entradas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Compra_de_Entradas.Controllers
{
    public class LoguearController : Controller
    {
        private readonly AplicationDbContext context;
        public LoguearController(AplicationDbContext context)
        {
            this.context = context;
        }
        // GET: LoguearController
        public ActionResult Loguearse()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Loguearse(string User, string Contra)
        {
            if (ModelState.IsValid)
            {
                var check = (from d in context.Usuarios
                             where d.Username == User.Trim() && d.Password == Contra.Trim()
                             select d).FirstOrDefault();
                if (check == null) {
                    ViewBag.Error = "Usuario o Contraseña incorrecta";
                    return View();
                }
                TempData["Mensaje"]= "Usuario y Contraseña correcta";
                return RedirectToAction("Index", "Home");
            }
                return View();
        }

        // GET: LoguearController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoguearController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoguearController/Create
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

        // GET: LoguearController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoguearController/Edit/5
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

        // GET: LoguearController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoguearController/Delete/5
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
