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
    public class RevisionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Revision/
        public async Task<ActionResult> Index()
        {
            return View(await db.Revisions.ToListAsync());
        }

        // GET: /Revision/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revision revision = await db.Revisions.FindAsync(id);
            if (revision == null)
            {
                return HttpNotFound();
            }
            return View(revision);
        }

        // GET: /Revision/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Revision/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="RevisionId")] Revision revision)
        {
            if (ModelState.IsValid)
            {
                db.Revisions.Add(revision);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(revision);
        }

        // GET: /Revision/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revision revision = await db.Revisions.FindAsync(id);
            if (revision == null)
            {
                return HttpNotFound();
            }
            return View(revision);
        }

        // POST: /Revision/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="RevisionId")] Revision revision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(revision).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(revision);
        }

        // GET: /Revision/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revision revision = await db.Revisions.FindAsync(id);
            if (revision == null)
            {
                return HttpNotFound();
            }
            return View(revision);
        }

        // POST: /Revision/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Revision revision = await db.Revisions.FindAsync(id);
            db.Revisions.Remove(revision);
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
