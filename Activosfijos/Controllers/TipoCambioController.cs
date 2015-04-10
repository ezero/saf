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
    public class TipoCambioController : Controller
    {
        private activofijoEntities db = new activofijoEntities();

        //
        // GET: /TipoCambio/

        public ActionResult Index()
        {
            var tipocambio = db.tipocambio.Include(t => t.gestion).Include(t => t.moneda);
            return View(tipocambio.ToList());
        }

        //
        // GET: /TipoCambio/Details/5

        public ActionResult Details(int id = 0)
        {
            tipocambio tipocambio = db.tipocambio.Find(id);
            if (tipocambio == null)
            {
                return HttpNotFound();
            }
            return View(tipocambio);
        }

        //
        // GET: /TipoCambio/Create

        public ActionResult Create()
        {
            ViewBag.idgestion = new SelectList(db.gestion, "idgestion", "idgestion");
            ViewBag.idmoneda = new SelectList(db.moneda, "idmoneda", "nombre");
            return View();
        }

        //
        // POST: /TipoCambio/Create

        [HttpPost]
        public ActionResult Create(tipocambio tipocambio)
        {
            if (ModelState.IsValid)
            {
                db.tipocambio.Add(tipocambio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idgestion = new SelectList(db.gestion, "idgestion", "idgestion", tipocambio.idgestion);
            ViewBag.idmoneda = new SelectList(db.moneda, "idmoneda", "nombre", tipocambio.idmoneda);
            return View(tipocambio);
        }

        //
        // GET: /TipoCambio/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tipocambio tipocambio = db.tipocambio.Find(id);
            if (tipocambio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idgestion = new SelectList(db.gestion, "idgestion", "idgestion", tipocambio.idgestion);
            ViewBag.idmoneda = new SelectList(db.moneda, "idmoneda", "nombre", tipocambio.idmoneda);
            return View(tipocambio);
        }

        //
        // POST: /TipoCambio/Edit/5

        [HttpPost]
        public ActionResult Edit(tipocambio tipocambio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipocambio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idgestion = new SelectList(db.gestion, "idgestion", "idgestion", tipocambio.idgestion);
            ViewBag.idmoneda = new SelectList(db.moneda, "idmoneda", "nombre", tipocambio.idmoneda);
            return View(tipocambio);
        }

        //
        // GET: /TipoCambio/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tipocambio tipocambio = db.tipocambio.Find(id);
            if (tipocambio == null)
            {
                return HttpNotFound();
            }
            return View(tipocambio);
        }

        //
        // POST: /TipoCambio/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            tipocambio tipocambio = db.tipocambio.Find(id);
            db.tipocambio.Remove(tipocambio);
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