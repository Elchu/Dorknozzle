using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using dorknozzle.Models;

namespace dorknozzle.Controllers
{
    public class TematyController : Controller
    {
        private DorknozzleDbContext db = new DorknozzleDbContext();

        public ActionResult Index()
        {
            var pomocTechnicznaTematy = db.PomocTechnicznaTematy.Include(p => p.PomocTechnicznaKategorie);
            return View(pomocTechnicznaTematy.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.KategoriaId = new SelectList(db.PomocTechnicznaKategorie, "KategoriaId", "Nazwa");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TematId,Nazwa,KategoriaId")] PomocTechnicznaTematy pomocTechnicznaTematy)
        {
            if (ModelState.IsValid)
            {
                db.PomocTechnicznaTematy.Add(pomocTechnicznaTematy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriaId = new SelectList(db.PomocTechnicznaKategorie, "KategoriaId", "Nazwa", pomocTechnicznaTematy.KategoriaId);
            return View(pomocTechnicznaTematy);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PomocTechnicznaTematy pomocTechnicznaTematy = db.PomocTechnicznaTematy.Find(id);
            if (pomocTechnicznaTematy == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriaId = new SelectList(db.PomocTechnicznaKategorie, "KategoriaId", "Nazwa", pomocTechnicznaTematy.KategoriaId);
            return View(pomocTechnicznaTematy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TematId,Nazwa,KategoriaId")] PomocTechnicznaTematy pomocTechnicznaTematy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pomocTechnicznaTematy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriaId = new SelectList(db.PomocTechnicznaKategorie, "KategoriaId", "Nazwa", pomocTechnicznaTematy.KategoriaId);
            return View(pomocTechnicznaTematy);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PomocTechnicznaTematy pomocTechnicznaTematy = db.PomocTechnicznaTematy.Find(id);
            if (pomocTechnicznaTematy == null)
            {
                return HttpNotFound();
            }
            return View(pomocTechnicznaTematy);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PomocTechnicznaTematy pomocTechnicznaTematy = db.PomocTechnicznaTematy.Find(id);
            db.PomocTechnicznaTematy.Remove(pomocTechnicznaTematy);
            db.SaveChanges();
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
