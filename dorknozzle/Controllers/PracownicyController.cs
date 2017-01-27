using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using dorknozzle.Models;
using Microsoft.AspNet.Identity;

namespace dorknozzle.Controllers
{
    public class PracownicyController : Controller
    {
        private DorknozzleDbContext db = new DorknozzleDbContext();

        public ActionResult Index()
        {
            var pracownicy = db.Pracownicy.Include(p => p.Dzialy);
            return View(pracownicy.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownicy pracownicy = db.Pracownicy.Find(id);
            if (pracownicy == null)
            {
                return HttpNotFound();
            }
            return View(pracownicy);
        }

        public ActionResult Create()
        {
            string userId = User.Identity.GetUserId();
            Pracownicy pracownik = db.Pracownicy.FirstOrDefault(p => p.UserId.Equals(userId));

            if (pracownik != null)
                return RedirectToAction("Edit", new { id = pracownik.PracownicyId});

            ViewBag.DzialId = new SelectList(db.Dzialy, "DzialId", "Nazwa");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PracownicyId,Imie,Nazwisko,Adres,Miasto,Wojewodztwo,KodPocztowy,TelefonDomowy,TelefonKomorkowy,Newsletter,DzialId")] Pracownicy pracownicy)
        {
            pracownicy.UserId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                db.Pracownicy.Add(pracownicy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DzialId = new SelectList(db.Dzialy, "DzialId", "Nazwa", pracownicy.DzialId);
            return View(pracownicy);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownicy pracownicy = db.Pracownicy.Find(id);
            if (pracownicy == null)
            {
                return HttpNotFound();
            }
            ViewBag.DzialId = new SelectList(db.Dzialy, "DzialId", "Nazwa", pracownicy.DzialId);
            return View(pracownicy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PracownicyId,UserId,Imie,Nazwisko,Adres,Miasto,Wojewodztwo,KodPocztowy,TelefonDomowy,TelefonKomorkowy,Newsletter,DzialId")] Pracownicy pracownicy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pracownicy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DzialId = new SelectList(db.Dzialy, "DzialId", "Nazwa", pracownicy.DzialId);
            return View(pracownicy);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownicy pracownicy = db.Pracownicy.Find(id);
            if (pracownicy == null)
            {
                return HttpNotFound();
            }
            return View(pracownicy);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pracownicy pracownicy = db.Pracownicy.Find(id);
            db.Pracownicy.Remove(pracownicy);
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
