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
    public class MantinimientoController : Controller
    {
        private activofijoEntities db = new activofijoEntities();

        //
        // GET: /Mantinimiento/

        public ActionResult Index()
        {
            return View(db.mantenimiento.ToList());
        }

        //
        // GET: /Mantinimiento/Details/5

        public ActionResult Details(int id = 0)
        {
            mantenimiento mantenimiento = db.mantenimiento.Find(id);
            if (mantenimiento == null)
            {
                return HttpNotFound();
            }
            return View(mantenimiento);
        }

        //
        // GET: /Mantinimiento/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Mantinimiento/Create

        [HttpPost]
        public ActionResult Create(mantenimiento mantenimiento)
        {
            if (ModelState.IsValid)
            {
                db.mantenimiento.Add(mantenimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mantenimiento);
        }

        //
        // GET: /Mantinimiento/Edit/5

        public ActionResult Edit(int id = 0)
        {
            mantenimiento mantenimiento = db.mantenimiento.Find(id);
            if (mantenimiento == null)
            {
                return HttpNotFound();
            }
            return View(mantenimiento);
        }

        //
        // POST: /Mantinimiento/Edit/5

        [HttpPost]
        public ActionResult Edit(mantenimiento mantenimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mantenimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mantenimiento);
        }

        //
        // GET: /Mantinimiento/Delete/5

        public ActionResult Delete(int id = 0)
        {
            mantenimiento mantenimiento = db.mantenimiento.Find(id);
            if (mantenimiento == null)
            {
                return HttpNotFound();
            }
            return View(mantenimiento);
        }

        //
        // POST: /Mantinimiento/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            mantenimiento mantenimiento = db.mantenimiento.Find(id);
            db.mantenimiento.Remove(mantenimiento);
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