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
    public class DepreciacionController : Controller
    {
        private activofijoEntities db = new activofijoEntities();

        //
        // GET: /Depreciacion/

        public ActionResult Index()
        {
            return View(db.depreciacion.ToList());
        }

        //
        // GET: /Depreciacion/Details/5

        public ActionResult Details(int id = 0)
        {
            depreciacion depreciacion = db.depreciacion.Find(id);
            if (depreciacion == null)
            {
                return HttpNotFound();
            }
            return View(depreciacion);
        }

        //
        // GET: /Depreciacion/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Depreciacion/Create

        [HttpPost]
        public ActionResult Create(depreciacion depreciacion)
        {
            if (ModelState.IsValid)
            {
                db.depreciacion.Add(depreciacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(depreciacion);
        }

        //
        // GET: /Depreciacion/Edit/5

        public ActionResult Edit(int id = 0)
        {
            depreciacion depreciacion = db.depreciacion.Find(id);
            if (depreciacion == null)
            {
                return HttpNotFound();
            }
            return View(depreciacion);
        }

        //
        // POST: /Depreciacion/Edit/5

        [HttpPost]
        public ActionResult Edit(depreciacion depreciacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(depreciacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(depreciacion);
        }

        //
        // GET: /Depreciacion/Delete/5

        public ActionResult Delete(int id = 0)
        {
            depreciacion depreciacion = db.depreciacion.Find(id);
            if (depreciacion == null)
            {
                return HttpNotFound();
            }
            return View(depreciacion);
        }

        //
        // POST: /Depreciacion/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            depreciacion depreciacion = db.depreciacion.Find(id);
            db.depreciacion.Remove(depreciacion);
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