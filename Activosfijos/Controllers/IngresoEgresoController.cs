using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Activosfijos.Models;

namespace Activosfijos.Controllers
{
    public class IngresoEgresoController : Controller
    {
        private activofijoEntities db = new activofijoEntities();

        //
        // GET: /IngresoEgreso/

        public ActionResult Index()
        {
            return View(db.ingresoegreso.ToList());
        }

        //
        // GET: /IngresoEgreso/Details/5

        public ActionResult Details(int id = 0)
        {
            ingresoegreso ingresoegreso = db.ingresoegreso.Find(id);
            if (ingresoegreso == null)
            {
                return HttpNotFound();
            }
            return View(ingresoegreso);
        }

        //
        // GET: /IngresoEgreso/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /IngresoEgreso/Create

        [HttpPost]
        public ActionResult Create(ingresoegreso ingresoegreso)
        {
            if (ModelState.IsValid)
            {
                db.ingresoegreso.Add(ingresoegreso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingresoegreso);
        }

        //
        // GET: /IngresoEgreso/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ingresoegreso ingresoegreso = db.ingresoegreso.Find(id);
            if (ingresoegreso == null)
            {
                return HttpNotFound();
            }
            return View(ingresoegreso);
        }

        //
        // POST: /IngresoEgreso/Edit/5

        [HttpPost]
        public ActionResult Edit(ingresoegreso ingresoegreso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingresoegreso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingresoegreso);
        }

        //
        // GET: /IngresoEgreso/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ingresoegreso ingresoegreso = db.ingresoegreso.Find(id);
            if (ingresoegreso == null)
            {
                return HttpNotFound();
            }
            return View(ingresoegreso);
        }

        //
        // POST: /IngresoEgreso/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ingresoegreso ingresoegreso = db.ingresoegreso.Find(id);
            db.ingresoegreso.Remove(ingresoegreso);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}