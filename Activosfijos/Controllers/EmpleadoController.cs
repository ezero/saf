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
    public class EmpleadoController : Controller
    {
        private activofijoEntities db = new activofijoEntities();

        //
        // GET: /Empleado/

        public ActionResult Index()
        {
            var empleado = db.empleado.Include(e => e.cargo).Include(e => e.departamento);
            return View(empleado.ToList());
        }

        //
        // GET: /Empleado/Details/5

        public ActionResult Details(int id = 0)
        {
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        //
        // GET: /Empleado/Create

        public ActionResult Create()
        {
            ViewBag.idcargo = new SelectList(db.cargo, "idcargo", "descripcion");
            ViewBag.iddepartamento = new SelectList(db.departamento, "iddepartamento", "descripcion");
            return View();
        }

        //
        // POST: /Empleado/Create

        [HttpPost]
        public ActionResult Create(empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcargo = new SelectList(db.cargo, "idcargo", "descripcion", empleado.idcargo);
            ViewBag.iddepartamento = new SelectList(db.departamento, "iddepartamento", "descripcion", empleado.iddepartamento);
            return View(empleado);
        }

        //
        // GET: /Empleado/Edit/5

        public ActionResult Edit(int id = 0)
        {
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcargo = new SelectList(db.cargo, "idcargo", "descripcion", empleado.idcargo);
            ViewBag.iddepartamento = new SelectList(db.departamento, "iddepartamento", "descripcion", empleado.iddepartamento);
            return View(empleado);
        }

        //
        // POST: /Empleado/Edit/5

        [HttpPost]
        public ActionResult Edit(empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcargo = new SelectList(db.cargo, "idcargo", "descripcion", empleado.idcargo);
            ViewBag.iddepartamento = new SelectList(db.departamento, "iddepartamento", "descripcion", empleado.iddepartamento);
            return View(empleado);
        }

        //
        // GET: /Empleado/Delete/5

        public ActionResult Delete(int id = 0)
        {
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        //
        // POST: /Empleado/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            empleado empleado = db.empleado.Find(id);
            db.empleado.Remove(empleado);
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