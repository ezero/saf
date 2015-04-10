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
    public class DetalleDepreciacionController : Controller
    {
        private activofijoEntities db = new activofijoEntities();

        //
        // GET: /DetalleDepreciacion/

        public ActionResult Index()
        {
            var detalledepreciacion = db.detalledepreciacion.Include(d => d.depreciacion).Include(d => d.gestion).Include(d => d.tipobien);
            return View(detalledepreciacion.ToList());
        }

        //
        // GET: /DetalleDepreciacion/Details/5

        public ActionResult Details(int id = 0)
        {
            detalledepreciacion detalledepreciacion = db.detalledepreciacion.Find(id);
            if (detalledepreciacion == null)
            {
                return HttpNotFound();
            }
            return View(detalledepreciacion);
        }

        //
        // GET: /DetalleDepreciacion/Create

        public ActionResult Create()
        {
            ViewBag.iddepreciacion = new SelectList(db.depreciacion, "iddepreciacion", "iddepreciacion");
            ViewBag.idgestion = new SelectList(db.gestion, "idgestion", "idgestion");
            ViewBag.idtipobien = new SelectList(db.tipobien, "idtipobien", "descripcion");
            return View();
        }

        //
        // POST: /DetalleDepreciacion/Create

        [HttpPost]
        public ActionResult Create(detalledepreciacion detalledepreciacion)
        {
            if (ModelState.IsValid)
            {
                db.detalledepreciacion.Add(detalledepreciacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.iddepreciacion = new SelectList(db.depreciacion, "iddepreciacion", "iddepreciacion", detalledepreciacion.iddepreciacion);
            ViewBag.idgestion = new SelectList(db.gestion, "idgestion", "idgestion", detalledepreciacion.idgestion);
            ViewBag.idtipobien = new SelectList(db.tipobien, "idtipobien", "descripcion", detalledepreciacion.idtipobien);
            return View(detalledepreciacion);
        }

        //
        // GET: /DetalleDepreciacion/Edit/5

        public ActionResult Edit(int id = 0)
        {
            detalledepreciacion detalledepreciacion = db.detalledepreciacion.Find(id);
            if (detalledepreciacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.iddepreciacion = new SelectList(db.depreciacion, "iddepreciacion", "iddepreciacion", detalledepreciacion.iddepreciacion);
            ViewBag.idgestion = new SelectList(db.gestion, "idgestion", "idgestion", detalledepreciacion.idgestion);
            ViewBag.idtipobien = new SelectList(db.tipobien, "idtipobien", "descripcion", detalledepreciacion.idtipobien);
            return View(detalledepreciacion);
        }

        //
        // POST: /DetalleDepreciacion/Edit/5

        [HttpPost]
        public ActionResult Edit(detalledepreciacion detalledepreciacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalledepreciacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.iddepreciacion = new SelectList(db.depreciacion, "iddepreciacion", "iddepreciacion", detalledepreciacion.iddepreciacion);
            ViewBag.idgestion = new SelectList(db.gestion, "idgestion", "idgestion", detalledepreciacion.idgestion);
            ViewBag.idtipobien = new SelectList(db.tipobien, "idtipobien", "descripcion", detalledepreciacion.idtipobien);
            return View(detalledepreciacion);
        }

        //
        // GET: /DetalleDepreciacion/Delete/5

        public ActionResult Delete(int id = 0)
        {
            detalledepreciacion detalledepreciacion = db.detalledepreciacion.Find(id);
            if (detalledepreciacion == null)
            {
                return HttpNotFound();
            }
            return View(detalledepreciacion);
        }

        //
        // POST: /DetalleDepreciacion/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            detalledepreciacion detalledepreciacion = db.detalledepreciacion.Find(id);
            db.detalledepreciacion.Remove(detalledepreciacion);
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