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
    public class ApreciacionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Apreciacion/
        public async Task<ActionResult> Index()
        {
            return View(await db.Apreciacions.ToListAsync());
        }

        // GET: /Apreciacion/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apreciacion apreciacion = await db.Apreciacions.FindAsync(id);
            if (apreciacion == null)
            {
                return HttpNotFound();
            }
            return View(apreciacion);
        }

        // GET: /Apreciacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Apreciacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ApreciacionId,ApreciacionPorcentaje")] Apreciacion apreciacion)
        {
            if (ModelState.IsValid)
            {
                db.Apreciacions.Add(apreciacion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(apreciacion);
        }

        // GET: /Apreciacion/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apreciacion apreciacion = await db.Apreciacions.FindAsync(id);
            if (apreciacion == null)
            {
                return HttpNotFound();
            }
            return View(apreciacion);
        }

        // POST: /Apreciacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ApreciacionId,ApreciacionPorcentaje")] Apreciacion apreciacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apreciacion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(apreciacion);
        }

        // GET: /Apreciacion/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apreciacion apreciacion = await db.Apreciacions.FindAsync(id);
            if (apreciacion == null)
            {
                return HttpNotFound();
            }
            return View(apreciacion);
        }

        // POST: /Apreciacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Apreciacion apreciacion = await db.Apreciacions.FindAsync(id);
            db.Apreciacions.Remove(apreciacion);
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
