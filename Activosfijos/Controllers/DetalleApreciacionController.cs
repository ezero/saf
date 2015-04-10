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
    public class DetalleApreciacionController : Controller
    {
        private activofijoEntities db = new activofijoEntities();

        //
        // GET: /DetalleApreciacion/

        public ActionResult Index()
        {
            var detalleapreciacion = db.detalleapreciacion.Include(d => d.apreciacion).Include(d => d.gestion).Include(d => d.tipobien);
            return View(detalleapreciacion.ToList());
        }

        //
        // GET: /DetalleApreciacion/Details/5

        public ActionResult Details(int id = 0)
        {
            detalleapreciacion detalleapreciacion = db.detalleapreciacion.Find(id);
            if (detalleapreciacion == null)
            {
                return HttpNotFound();
            }
            return View(detalleapreciacion);
        }

        //
        // GET: /DetalleApreciacion/Create

        public ActionResult Create()
        {
            ViewBag.idapreciacion = new SelectList(db.apreciacion, "idapreciacion", "idapreciacion");
            ViewBag.idgestion = new SelectList(db.gestion, "idgestion", "idgestion");
            ViewBag.idtipobien = new SelectList(db.tipobien, "idtipobien", "descripcion");
            return View();
        }

        //
        // POST: /DetalleApreciacion/Create

        [HttpPost]
        public ActionResult Create(detalleapreciacion detalleapreciacion)
        {
            if (ModelState.IsValid)
            {
                db.detalleapreciacion.Add(detalleapreciacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idapreciacion = new SelectList(db.apreciacion, "idapreciacion", "idapreciacion", detalleapreciacion.idapreciacion);
            ViewBag.idgestion = new SelectList(db.gestion, "idgestion", "idgestion", detalleapreciacion.idgestion);
            ViewBag.idtipobien = new SelectList(db.tipobien, "idtipobien", "descripcion", detalleapreciacion.idtipobien);
            return View(detalleapreciacion);
        }

        //
        // GET: /DetalleApreciacion/Edit/5

        public ActionResult Edit(int id = 0)
        {
            detalleapreciacion detalleapreciacion = db.detalleapreciacion.Find(id);
            if (detalleapreciacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idapreciacion = new SelectList(db.apreciacion, "idapreciacion", "idapreciacion", detalleapreciacion.idapreciacion);
            ViewBag.idgestion = new SelectList(db.gestion, "idgestion", "idgestion", detalleapreciacion.idgestion);
            ViewBag.idtipobien = new SelectList(db.tipobien, "idtipobien", "descripcion", detalleapreciacion.idtipobien);
            return View(detalleapreciacion);
        }

        //
        // POST: /DetalleApreciacion/Edit/5

        [HttpPost]
        public ActionResult Edit(detalleapreciacion detalleapreciacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleapreciacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idapreciacion = new SelectList(db.apreciacion, "idapreciacion", "idapreciacion", detalleapreciacion.idapreciacion);
            ViewBag.idgestion = new SelectList(db.gestion, "idgestion", "idgestion", detalleapreciacion.idgestion);
            ViewBag.idtipobien = new SelectList(db.tipobien, "idtipobien", "descripcion", detalleapreciacion.idtipobien);
            return View(detalleapreciacion);
        }

        //
        // GET: /DetalleApreciacion/Delete/5

        public ActionResult Delete(int id = 0)
        {
            detalleapreciacion detalleapreciacion = db.detalleapreciacion.Find(id);
            if (detalleapreciacion == null)
            {
                return HttpNotFound();
            }
            return View(detalleapreciacion);
        }

        //
        // POST: /DetalleApreciacion/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            detalleapreciacion detalleapreciacion = db.detalleapreciacion.Find(id);
            db.detalleapreciacion.Remove(detalleapreciacion);
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