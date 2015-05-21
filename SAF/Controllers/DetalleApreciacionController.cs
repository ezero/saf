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
    public class DetalleApreciacionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /DetalleApreciacion/
        public async Task<ActionResult> Index()
        {
            return View(await db.DetalleApreciacions.ToListAsync());
        }

        // GET: /DetalleApreciacion/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleApreciacion detalleapreciacion = await db.DetalleApreciacions.FindAsync(id);
            if (detalleapreciacion == null)
            {
                return HttpNotFound();
            }
            return View(detalleapreciacion);
        }

        // GET: /DetalleApreciacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /DetalleApreciacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="DetalleApreciacionId")] DetalleApreciacion detalleapreciacion)
        {
            if (ModelState.IsValid)
            {
                db.DetalleApreciacions.Add(detalleapreciacion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(detalleapreciacion);
        }

        // GET: /DetalleApreciacion/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleApreciacion detalleapreciacion = await db.DetalleApreciacions.FindAsync(id);
            if (detalleapreciacion == null)
            {
                return HttpNotFound();
            }
            return View(detalleapreciacion);
        }

        // POST: /DetalleApreciacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="DetalleApreciacionId")] DetalleApreciacion detalleapreciacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleapreciacion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(detalleapreciacion);
        }

        // GET: /DetalleApreciacion/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleApreciacion detalleapreciacion = await db.DetalleApreciacions.FindAsync(id);
            if (detalleapreciacion == null)
            {
                return HttpNotFound();
            }
            return View(detalleapreciacion);
        }

        // POST: /DetalleApreciacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DetalleApreciacion detalleapreciacion = await db.DetalleApreciacions.FindAsync(id);
            db.DetalleApreciacions.Remove(detalleapreciacion);
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
