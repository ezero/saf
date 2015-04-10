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
    public class GestionController : Controller
    {
        private activofijoEntities db = new activofijoEntities();

        //
        // GET: /Gestion/

        public ActionResult Index()
        {
            return View(db.gestion.ToList());
        }

        //
        // GET: /Gestion/Details/5

        public ActionResult Details(int id = 0)
        {
            gestion gestion = db.gestion.Find(id);
            if (gestion == null)
            {
                return HttpNotFound();
            }
            return View(gestion);
        }

        //
        // GET: /Gestion/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Gestion/Create

        [HttpPost]
        public ActionResult Create(gestion gestion)
        {
            if (ModelState.IsValid)
            {
                db.gestion.Add(gestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gestion);
        }

        //
        // GET: /Gestion/Edit/5

        public ActionResult Edit(int id = 0)
        {
            gestion gestion = db.gestion.Find(id);
            if (gestion == null)
            {
                return HttpNotFound();
            }
            return View(gestion);
        }

        //
        // POST: /Gestion/Edit/5

        [HttpPost]
        public ActionResult Edit(gestion gestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gestion);
        }

        //
        // GET: /Gestion/Delete/5

        public ActionResult Delete(int id = 0)
        {
            gestion gestion = db.gestion.Find(id);
            if (gestion == null)
            {
                return HttpNotFound();
            }
            return View(gestion);
        }

        //
        // POST: /Gestion/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            gestion gestion = db.gestion.Find(id);
            db.gestion.Remove(gestion);
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