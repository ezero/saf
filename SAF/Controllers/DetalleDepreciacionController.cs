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
    public class DetalleDepreciacionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /DetalleDepreciacion/
        public async Task<ActionResult> Index()
        {
            return View(await db.DetalleDepreciacions.ToListAsync());
        }

        // GET: /DetalleDepreciacion/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleDepreciacion detalledepreciacion = await db.DetalleDepreciacions.FindAsync(id);
            if (detalledepreciacion == null)
            {
                return HttpNotFound();
            }
            return View(detalledepreciacion);
        }

        // GET: /DetalleDepreciacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /DetalleDepreciacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="DetalleDepreciacionId")] DetalleDepreciacion detalledepreciacion)
        {
            if (ModelState.IsValid)
            {
                db.DetalleDepreciacions.Add(detalledepreciacion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(detalledepreciacion);
        }

        // GET: /DetalleDepreciacion/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleDepreciacion detalledepreciacion = await db.DetalleDepreciacions.FindAsync(id);
            if (detalledepreciacion == null)
            {
                return HttpNotFound();
            }
            return View(detalledepreciacion);
        }

        // POST: /DetalleDepreciacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="DetalleDepreciacionId")] DetalleDepreciacion detalledepreciacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalledepreciacion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(detalledepreciacion);
        }

        // GET: /DetalleDepreciacion/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleDepreciacion detalledepreciacion = await db.DetalleDepreciacions.FindAsync(id);
            if (detalledepreciacion == null)
            {
                return HttpNotFound();
            }
            return View(detalledepreciacion);
        }

        // POST: /DetalleDepreciacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DetalleDepreciacion detalledepreciacion = await db.DetalleDepreciacions.FindAsync(id);
            db.DetalleDepreciacions.Remove(detalledepreciacion);
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
