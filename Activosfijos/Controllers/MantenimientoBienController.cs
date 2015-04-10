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
    public class MantenimientoBienController : Controller
    {
        private activofijoEntities db = new activofijoEntities();

        //
        // GET: /MantenimientoBien/

        public ActionResult Index()
        {
            var mantenimientobien = db.mantenimientobien.Include(m => m.bien).Include(m => m.mantenimiento);
            return View(mantenimientobien.ToList());
        }

        //
        // GET: /MantenimientoBien/Details/5

        public ActionResult Details(int id = 0)
        {
            mantenimientobien mantenimientobien = db.mantenimientobien.Find(id);
            if (mantenimientobien == null)
            {
                return HttpNotFound();
            }
            return View(mantenimientobien);
        }

        //
        // GET: /MantenimientoBien/Create

        public ActionResult Create()
        {
            ViewBag.idbien = new SelectList(db.bien, "idbien", "nombre");
            ViewBag.idmantenimiento = new SelectList(db.mantenimiento, "idmantenimiento", "descripcion");
            return View();
        }

        //
        // POST: /MantenimientoBien/Create

        [HttpPost]
        public ActionResult Create(mantenimientobien mantenimientobien)
        {
            if (ModelState.IsValid)
            {
                db.mantenimientobien.Add(mantenimientobien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idbien = new SelectList(db.bien, "idbien", "nombre", mantenimientobien.idbien);
            ViewBag.idmantenimiento = new SelectList(db.mantenimiento, "idmantenimiento", "descripcion", mantenimientobien.idmantenimiento);
            return View(mantenimientobien);
        }

        //
        // GET: /MantenimientoBien/Edit/5

        public ActionResult Edit(int id = 0)
        {
            mantenimientobien mantenimientobien = db.mantenimientobien.Find(id);
            if (mantenimientobien == null)
            {
                return HttpNotFound();
            }
            ViewBag.idbien = new SelectList(db.bien, "idbien", "nombre", mantenimientobien.idbien);
            ViewBag.idmantenimiento = new SelectList(db.mantenimiento, "idmantenimiento", "descripcion", mantenimientobien.idmantenimiento);
            return View(mantenimientobien);
        }

        //
        // POST: /MantenimientoBien/Edit/5

        [HttpPost]
        public ActionResult Edit(mantenimientobien mantenimientobien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mantenimientobien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idbien = new SelectList(db.bien, "idbien", "nombre", mantenimientobien.idbien);
            ViewBag.idmantenimiento = new SelectList(db.mantenimiento, "idmantenimiento", "descripcion", mantenimientobien.idmantenimiento);
            return View(mantenimientobien);
        }

        //
        // GET: /MantenimientoBien/Delete/5

        public ActionResult Delete(int id = 0)
        {
            mantenimientobien mantenimientobien = db.mantenimientobien.Find(id);
            if (mantenimientobien == null)
            {
                return HttpNotFound();
            }
            return View(mantenimientobien);
        }

        //
        // POST: /MantenimientoBien/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            mantenimientobien mantenimientobien = db.mantenimientobien.Find(id);
            db.mantenimientobien.Remove(mantenimientobien);
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