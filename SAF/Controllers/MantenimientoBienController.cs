using System;
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
    public class MantenimientoBienController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /MantenimientoBien/
        public async Task<ActionResult> Index()
        {
            return View(await db.MantenimientoBiens.ToListAsync());
        }

        // GET: /MantenimientoBien/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MantenimientoBien mantenimientobien = await db.MantenimientoBiens.FindAsync(id);
            if (mantenimientobien == null)
            {
                return HttpNotFound();
            }
            return View(mantenimientobien);
        }

        // GET: /MantenimientoBien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /MantenimientoBien/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="MantenimientoBienId,MantenimientoDescripcion")] MantenimientoBien mantenimientobien)
        {
            if (ModelState.IsValid)
            {
                db.MantenimientoBiens.Add(mantenimientobien);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mantenimientobien);
        }

        // GET: /MantenimientoBien/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MantenimientoBien mantenimientobien = await db.MantenimientoBiens.FindAsync(id);
            if (mantenimientobien == null)
            {
                return HttpNotFound();
            }
            return View(mantenimientobien);
        }

        // POST: /MantenimientoBien/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="MantenimientoBienId,MantenimientoDescripcion")] MantenimientoBien mantenimientobien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mantenimientobien).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mantenimientobien);
        }

        // GET: /MantenimientoBien/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MantenimientoBien mantenimientobien = await db.MantenimientoBiens.FindAsync(id);
            if (mantenimientobien == null)
            {
                return HttpNotFound();
            }
            return View(mantenimientobien);
        }

        // POST: /MantenimientoBien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MantenimientoBien mantenimientobien = await db.MantenimientoBiens.FindAsync(id);
            db.MantenimientoBiens.Remove(mantenimientobien);
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
