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
    public class ResponsableController : Controller
    {
        private activofijoEntities db = new activofijoEntities();

        //
        // GET: /Responsable/

        public ActionResult Index()
        {
            var responsable = db.responsable.Include(r => r.bien).Include(r => r.empleado);
            return View(responsable.ToList());
        }

        //
        // GET: /Responsable/Details/5

        public ActionResult Details(int id = 0)
        {
            responsable responsable = db.responsable.Find(id);
            if (responsable == null)
            {
                return HttpNotFound();
            }
            return View(responsable);
        }

        //
        // GET: /Responsable/Create

        public ActionResult Create()
        {
            ViewBag.idbien = new SelectList(db.bien, "idbien", "nombre");
            ViewBag.idempleado = new SelectList(db.empleado, "idempleado", "nombre");
            return View();
        }

        //
        // POST: /Responsable/Create

        [HttpPost]
        public ActionResult Create(responsable responsable)
        {
            if (ModelState.IsValid)
            {
                db.responsable.Add(responsable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idbien = new SelectList(db.bien, "idbien", "nombre", responsable.idbien);
            ViewBag.idempleado = new SelectList(db.empleado, "idempleado", "nombre", responsable.idempleado);
            return View(responsable);
        }

        //
        // GET: /Responsable/Edit/5

        public ActionResult Edit(int id = 0)
        {
            responsable responsable = db.responsable.Find(id);
            if (responsable == null)
            {
                return HttpNotFound();
            }
            ViewBag.idbien = new SelectList(db.bien, "idbien", "nombre", responsable.idbien);
            ViewBag.idempleado = new SelectList(db.empleado, "idempleado", "nombre", responsable.idempleado);
            return View(responsable);
        }

        //
        // POST: /Responsable/Edit/5

        [HttpPost]
        public ActionResult Edit(responsable responsable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(responsable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idbien = new SelectList(db.bien, "idbien", "nombre", responsable.idbien);
            ViewBag.idempleado = new SelectList(db.empleado, "idempleado", "nombre", responsable.idempleado);
            return View(responsable);
        }

        //
        // GET: /Responsable/Delete/5

        public ActionResult Delete(int id = 0)
        {
            responsable responsable = db.responsable.Find(id);
            if (responsable == null)
            {
                return HttpNotFound();
            }
            return View(responsable);
        }

        //
        // POST: /Responsable/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            responsable responsable = db.responsable.Find(id);
            db.responsable.Remove(responsable);
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