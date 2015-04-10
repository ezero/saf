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
    public class MonedaController : Controller
    {
        private activofijoEntities db = new activofijoEntities();

        //
        // GET: /Moneda/

        public ActionResult Index()
        {
            return View(db.moneda.ToList());
        }

        //
        // GET: /Moneda/Details/5

        public ActionResult Details(int id = 0)
        {
            moneda moneda = db.moneda.Find(id);
            if (moneda == null)
            {
                return HttpNotFound();
            }
            return View(moneda);
        }

        //
        // GET: /Moneda/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Moneda/Create

        [HttpPost]
        public ActionResult Create(moneda moneda)
        {
            if (ModelState.IsValid)
            {
                db.moneda.Add(moneda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moneda);
        }

        //
        // GET: /Moneda/Edit/5

        public ActionResult Edit(int id = 0)
        {
            moneda moneda = db.moneda.Find(id);
            if (moneda == null)
            {
                return HttpNotFound();
            }
            return View(moneda);
        }

        //
        // POST: /Moneda/Edit/5

        [HttpPost]
        public ActionResult Edit(moneda moneda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moneda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moneda);
        }

        //
        // GET: /Moneda/Delete/5

        public ActionResult Delete(int id = 0)
        {
            moneda moneda = db.moneda.Find(id);
            if (moneda == null)
            {
                return HttpNotFound();
            }
            return View(moneda);
        }

        //
        // POST: /Moneda/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            moneda moneda = db.moneda.Find(id);
            db.moneda.Remove(moneda);
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