﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAF.Models;

namespace SAF.Controllers
{
    public class TipoBienController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /TipoBien/
        public async Task<ActionResult> Index()
        {
            return View(await db.TipoBiens.ToListAsync());
        }

        // GET: /TipoBien/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoBien tipobien = await db.TipoBiens.FindAsync(id);
            if (tipobien == null)
            {
                return HttpNotFound();
            }
            return View(tipobien);
        }

        // GET: /TipoBien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoBien/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="TipoBienID,TipoBienDescripcion")] TipoBien tipobien)
        {
            if (ModelState.IsValid)
            {
                db.TipoBiens.Add(tipobien);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipobien);
        }

        // GET: /TipoBien/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoBien tipobien = await db.TipoBiens.FindAsync(id);
            if (tipobien == null)
            {
                return HttpNotFound();
            }
            return View(tipobien);
        }

        // POST: /TipoBien/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="TipoBienID,TipoBienDescripcion")] TipoBien tipobien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipobien).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipobien);
        }

        // GET: /TipoBien/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoBien tipobien = await db.TipoBiens.FindAsync(id);
            if (tipobien == null)
            {
                return HttpNotFound();
            }
            return View(tipobien);
        }

        // POST: /TipoBien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipoBien tipobien = await db.TipoBiens.FindAsync(id);
            db.TipoBiens.Remove(tipobien);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
