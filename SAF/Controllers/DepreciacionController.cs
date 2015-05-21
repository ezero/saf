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
    public class DepreciacionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Depreciacion/
        public async Task<ActionResult> Index()
        {
            return View(await db.Depreciacions.ToListAsync());
        }

        // GET: /Depreciacion/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Depreciacion depreciacion = await db.Depreciacions.FindAsync(id);
            if (depreciacion == null)
            {
                return HttpNotFound();
            }
            return View(depreciacion);
        }

        // GET: /Depreciacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Depreciacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="DepreciacionId,DepreciacionPorcentaje")] Depreciacion depreciacion)
        {
            if (ModelState.IsValid)
            {
                db.Depreciacions.Add(depreciacion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(depreciacion);
        }

        // GET: /Depreciacion/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Depreciacion depreciacion = await db.Depreciacions.FindAsync(id);
            if (depreciacion == null)
            {
                return HttpNotFound();
            }
            return View(depreciacion);
        }

        // POST: /Depreciacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="DepreciacionId,DepreciacionPorcentaje")] Depreciacion depreciacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(depreciacion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(depreciacion);
        }

        // GET: /Depreciacion/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Depreciacion depreciacion = await db.Depreciacions.FindAsync(id);
            if (depreciacion == null)
            {
                return HttpNotFound();
            }
            return View(depreciacion);
        }

        // POST: /Depreciacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Depreciacion depreciacion = await db.Depreciacions.FindAsync(id);
            db.Depreciacions.Remove(depreciacion);
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
