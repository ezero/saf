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
    public class MantenimientoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Mantenimiento/
        public async Task<ActionResult> Index()
        {
            return View(await db.Mantenimientoes.ToListAsync());
        }

        // GET: /Mantenimiento/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mantenimiento mantenimiento = await db.Mantenimientoes.FindAsync(id);
            if (mantenimiento == null)
            {
                return HttpNotFound();
            }
            return View(mantenimiento);
        }

        // GET: /Mantenimiento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Mantenimiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="MantenimientoId,MantenimientoDescripcion,MantenimientoTipo")] Mantenimiento mantenimiento)
        {
            if (ModelState.IsValid)
            {
                db.Mantenimientoes.Add(mantenimiento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mantenimiento);
        }

        // GET: /Mantenimiento/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mantenimiento mantenimiento = await db.Mantenimientoes.FindAsync(id);
            if (mantenimiento == null)
            {
                return HttpNotFound();
            }
            return View(mantenimiento);
        }

        // POST: /Mantenimiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="MantenimientoId,MantenimientoDescripcion,MantenimientoTipo")] Mantenimiento mantenimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mantenimiento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mantenimiento);
        }

        // GET: /Mantenimiento/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mantenimiento mantenimiento = await db.Mantenimientoes.FindAsync(id);
            if (mantenimiento == null)
            {
                return HttpNotFound();
            }
            return View(mantenimiento);
        }

        // POST: /Mantenimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Mantenimiento mantenimiento = await db.Mantenimientoes.FindAsync(id);
            db.Mantenimientoes.Remove(mantenimiento);
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
