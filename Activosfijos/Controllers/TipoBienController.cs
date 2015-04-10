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
    public class TipoBienController : Controller
    {
        private activofijoEntities db = new activofijoEntities();

        //
        // GET: /TipoBien/

        public ActionResult Index()
        {
            var tipobien = db.tipobien.Include(t => t.categoria);
            return View(tipobien.ToList());
        }

        //
        // GET: /TipoBien/Details/5

        public ActionResult Details(int id = 0)
        {
            tipobien tipobien = db.tipobien.Find(id);
            if (tipobien == null)
            {
                return HttpNotFound();
            }
            return View(tipobien);
        }

        //
        // GET: /TipoBien/Create

        public ActionResult Create()
        {
            ViewBag.idcategoria = new SelectList(db.categoria, "idcategoria", "descripcion");
            return View();
        }

        //
        // POST: /TipoBien/Create

        [HttpPost]
        public ActionResult Create(tipobien tipobien)
        {
            if (ModelState.IsValid)
            {
                db.tipobien.Add(tipobien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcategoria = new SelectList(db.categoria, "idcategoria", "descripcion", tipobien.idcategoria);
            return View(tipobien);
        }

        //
        // GET: /TipoBien/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tipobien tipobien = db.tipobien.Find(id);
            if (tipobien == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcategoria = new SelectList(db.categoria, "idcategoria", "descripcion", tipobien.idcategoria);
            return View(tipobien);
        }

        //
        // POST: /TipoBien/Edit/5

        [HttpPost]
        public ActionResult Edit(tipobien tipobien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipobien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcategoria = new SelectList(db.categoria, "idcategoria", "descripcion", tipobien.idcategoria);
            return View(tipobien);
        }

        //
        // GET: /TipoBien/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tipobien tipobien = db.tipobien.Find(id);
            if (tipobien == null)
            {
                return HttpNotFound();
            }
            return View(tipobien);
        }

        //
        // POST: /TipoBien/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            tipobien tipobien = db.tipobien.Find(id);
            db.tipobien.Remove(tipobien);
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