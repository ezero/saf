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
    public class TipoCambioController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /TipoCambio/
        public async Task<ActionResult> Index()
        {
            return View(await db.TipoCambios.ToListAsync());
        }

        // GET: /TipoCambio/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCambio tipocambio = await db.TipoCambios.FindAsync(id);
            if (tipocambio == null)
            {
                return HttpNotFound();
            }
            return View(tipocambio);
        }

        // GET: /TipoCambio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoCambio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="TipoCambioId")] TipoCambio tipocambio)
        {
            if (ModelState.IsValid)
            {
                db.TipoCambios.Add(tipocambio);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipocambio);
        }

        // GET: /TipoCambio/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCambio tipocambio = await db.TipoCambios.FindAsync(id);
            if (tipocambio == null)
            {
                return HttpNotFound();
            }
            return View(tipocambio);
        }

        // POST: /TipoCambio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="TipoCambioId")] TipoCambio tipocambio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipocambio).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipocambio);
        }

        // GET: /TipoCambio/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCambio tipocambio = await db.TipoCambios.FindAsync(id);
            if (tipocambio == null)
            {
                return HttpNotFound();
            }
            return View(tipocambio);
        }

        // POST: /TipoCambio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipoCambio tipocambio = await db.TipoCambios.FindAsync(id);
            db.TipoCambios.Remove(tipocambio);
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
