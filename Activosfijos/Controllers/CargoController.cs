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
    public class CargoController : Controller
    {
        private activofijoEntities db = new activofijoEntities();

        //
        // GET: /Cargo/

        public ActionResult Index()
        {
            return View(db.cargo.ToList());
        }

        //
        // GET: /Cargo/Details/5

        public ActionResult Details(int id = 0)
        {
            cargo cargo = db.cargo.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        //
        // GET: /Cargo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cargo/Create

        [HttpPost]
        public ActionResult Create(cargo cargo)
        {
            if (ModelState.IsValid)
            {
                db.cargo.Add(cargo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cargo);
        }

        //
        // GET: /Cargo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            cargo cargo = db.cargo.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        //
        // POST: /Cargo/Edit/5

        [HttpPost]
        public ActionResult Edit(cargo cargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cargo);
        }

        //
        // GET: /Cargo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            cargo cargo = db.cargo.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        //
        // POST: /Cargo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            cargo cargo = db.cargo.Find(id);
            db.cargo.Remove(cargo);
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