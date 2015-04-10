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
    public class ApreciacionController : Controller
    {
        private activofijoEntities db = new activofijoEntities();

        //
        // GET: /Apreciacion/

        public ActionResult Index()
        {
            return View(db.apreciacion.ToList());
        }

        //
        // GET: /Apreciacion/Details/5

        public ActionResult Details(int id = 0)
        {
            apreciacion apreciacion = db.apreciacion.Find(id);
            if (apreciacion == null)
            {
                return HttpNotFound();
            }
            return View(apreciacion);
        }

        //
        // GET: /Apreciacion/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Apreciacion/Create

        [HttpPost]
        public ActionResult Create(apreciacion apreciacion)
        {
            if (ModelState.IsValid)
            {
                db.apreciacion.Add(apreciacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(apreciacion);
        }

        //
        // GET: /Apreciacion/Edit/5

        public ActionResult Edit(int id = 0)
        {
            apreciacion apreciacion = db.apreciacion.Find(id);
            if (apreciacion == null)
            {
                return HttpNotFound();
            }
            return View(apreciacion);
        }

        //
        // POST: /Apreciacion/Edit/5

        [HttpPost]
        public ActionResult Edit(apreciacion apreciacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apreciacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(apreciacion);
        }

        //
        // GET: /Apreciacion/Delete/5

        public ActionResult Delete(int id = 0)
        {
            apreciacion apreciacion = db.apreciacion.Find(id);
            if (apreciacion == null)
            {
                return HttpNotFound();
            }
            return View(apreciacion);
        }

        //
        // POST: /Apreciacion/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            apreciacion apreciacion = db.apreciacion.Find(id);
            db.apreciacion.Remove(apreciacion);
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