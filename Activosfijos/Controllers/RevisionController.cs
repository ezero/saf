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
    public class RevisionController : Controller
    {
        private activofijoEntities db = new activofijoEntities();

        //
        // GET: /Revision/

        public ActionResult Index()
        {
            var revision = db.revision.Include(r => r.bien).Include(r => r.empleado).Include(r => r.gestion);
            return View(revision.ToList());
        }

        //
        // GET: /Revision/Details/5

        public ActionResult Details(int id = 0)
        {
            revision revision = db.revision.Find(id);
            if (revision == null)
            {
                return HttpNotFound();
            }
            return View(revision);
        }

        //
        // GET: /Revision/Create

        public ActionResult Create()
        {
            ViewBag.idbien = new SelectList(db.bien, "idbien", "nombre");
            ViewBag.idempleado = new SelectList(db.empleado, "idempleado", "nombre");
            ViewBag.idgestion = new SelectList(db.gestion, "idgestion", "idgestion");
            return View();
        }

        //
        // POST: /Revision/Create

        [HttpPost]
        public ActionResult Create(revision revision)
        {
            if (ModelState.IsValid)
            {
                db.revision.Add(revision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idbien = new SelectList(db.bien, "idbien", "nombre", revision.idbien);
            ViewBag.idempleado = new SelectList(db.empleado, "idempleado", "nombre", revision.idempleado);
            ViewBag.idgestion = new SelectList(db.gestion, "idgestion", "idgestion", revision.idgestion);
            return View(revision);
        }

        //
        // GET: /Revision/Edit/5

        public ActionResult Edit(int id = 0)
        {
            revision revision = db.revision.Find(id);
            if (revision == null)
            {
                return HttpNotFound();
            }
            ViewBag.idbien = new SelectList(db.bien, "idbien", "nombre", revision.idbien);
            ViewBag.idempleado = new SelectList(db.empleado, "idempleado", "nombre", revision.idempleado);
            ViewBag.idgestion = new SelectList(db.gestion, "idgestion", "idgestion", revision.idgestion);
            return View(revision);
        }

        //
        // POST: /Revision/Edit/5

        [HttpPost]
        public ActionResult Edit(revision revision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(revision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idbien = new SelectList(db.bien, "idbien", "nombre", revision.idbien);
            ViewBag.idempleado = new SelectList(db.empleado, "idempleado", "nombre", revision.idempleado);
            ViewBag.idgestion = new SelectList(db.gestion, "idgestion", "idgestion", revision.idgestion);
            return View(revision);
        }

        //
        // GET: /Revision/Delete/5

        public ActionResult Delete(int id = 0)
        {
            revision revision = db.revision.Find(id);
            if (revision == null)
            {
                return HttpNotFound();
            }
            return View(revision);
        }

        //
        // POST: /Revision/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            revision revision = db.revision.Find(id);
            db.revision.Remove(revision);
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