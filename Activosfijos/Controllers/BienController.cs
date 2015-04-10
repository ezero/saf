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
    public class BienController : Controller
    {
        private activofijoEntities db = new activofijoEntities();

        //
        // GET: /Bien/

        public ActionResult Index()
        {
            var bien = db.bien.Include(b => b.ingresoegreso).Include(b => b.ingresoegreso1).Include(b => b.tipobien);
            return View(bien.ToList());
        }

        //
        // GET: /Bien/Details/5

        public ActionResult Details(int id = 0)
        {
            bien bien = db.bien.Find(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            return View(bien);
        }

        //
        // GET: /Bien/Create

        public ActionResult Create()
        {
            ViewBag.idegreso = new SelectList(db.ingresoegreso, "idingresoegreso", "tipoingreso");
            ViewBag.idingreso = new SelectList(db.ingresoegreso, "idingresoegreso", "tipoingreso");
            ViewBag.idtipobien = new SelectList(db.tipobien, "idtipobien", "descripcion");
            return View();
        }

        //
        // POST: /Bien/Create

        [HttpPost]
        public ActionResult Create(bien bien)
        {
            if (ModelState.IsValid)
            {
                db.bien.Add(bien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idegreso = new SelectList(db.ingresoegreso, "idingresoegreso", "tipoingreso", bien.idegreso);
            ViewBag.idingreso = new SelectList(db.ingresoegreso, "idingresoegreso", "tipoingreso", bien.idingreso);
            ViewBag.idtipobien = new SelectList(db.tipobien, "idtipobien", "descripcion", bien.idtipobien);
            return View(bien);
        }

        //
        // GET: /Bien/Edit/5

        public ActionResult Edit(int id = 0)
        {
            bien bien = db.bien.Find(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            ViewBag.idegreso = new SelectList(db.ingresoegreso, "idingresoegreso", "tipoingreso", bien.idegreso);
            ViewBag.idingreso = new SelectList(db.ingresoegreso, "idingresoegreso", "tipoingreso", bien.idingreso);
            ViewBag.idtipobien = new SelectList(db.tipobien, "idtipobien", "descripcion", bien.idtipobien);
            return View(bien);
        }

        //
        // POST: /Bien/Edit/5

        [HttpPost]
        public ActionResult Edit(bien bien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idegreso = new SelectList(db.ingresoegreso, "idingresoegreso", "tipoingreso", bien.idegreso);
            ViewBag.idingreso = new SelectList(db.ingresoegreso, "idingresoegreso", "tipoingreso", bien.idingreso);
            ViewBag.idtipobien = new SelectList(db.tipobien, "idtipobien", "descripcion", bien.idtipobien);
            return View(bien);
        }

        //
        // GET: /Bien/Delete/5

        public ActionResult Delete(int id = 0)
        {
            bien bien = db.bien.Find(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            return View(bien);
        }

        //
        // POST: /Bien/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            bien bien = db.bien.Find(id);
            db.bien.Remove(bien);
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