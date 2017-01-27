using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dorknozzle.Models;
using Microsoft.AspNet.Identity;

namespace dorknozzle.Admin
{        
    [Authorize]
    public class PomocTechnicznaController : Controller
    {
        private DorknozzleDbContext db = new DorknozzleDbContext();

        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var pomocTechniczna = db.PomocTechniczna.Include(p => p.PomocTechnicznaKategorie).Include(p => p.PomocTechnicznaTematy);
            return View(pomocTechniczna.ToList());
        }

        [Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PomocTechniczna pomocTechniczna = db.PomocTechniczna.Find(id);
            if (pomocTechniczna == null)
            {
                return HttpNotFound();
            }
            return View(pomocTechniczna);
        }

        public ActionResult Create()
        {
            ViewBag.KategoriaId = new SelectList(db.PomocTechnicznaKategorie, "KategoriaId", "Nazwa");
            ViewBag.TematId = new SelectList(db.PomocTechnicznaTematy, "TematId", "Nazwa");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PomocTechnicznaId,NunerStanowiska,Opis,KategoriaId,TematId")] PomocTechniczna pomocTechniczna)
        {
            pomocTechniczna.Status = Status.Oczekuje;
            pomocTechniczna.DataZgloszenia = DateTime.Now;
            pomocTechniczna.UserId = User.Identity.GetUserId();
            pomocTechniczna.AdresIp = Request.UserHostAddress;

            if (pomocTechniczna.TematId == 0)
                ModelState.AddModelError("TematId", "Wybierz poprawnie temat");

            if (ModelState.IsValid)
            {
                db.PomocTechniczna.Add(pomocTechniczna);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriaId = new SelectList(db.PomocTechnicznaKategorie, "KategoriaId", "Nazwa", pomocTechniczna.KategoriaId);
            ViewBag.TematId = new SelectList(db.PomocTechnicznaTematy, "TematId", "Nazwa", pomocTechniczna.TematId);
            return View(pomocTechniczna);
        }
        
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PomocTechniczna pomocTechniczna = db.PomocTechniczna.Find(id);
            if (pomocTechniczna == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriaId = new SelectList(db.PomocTechnicznaKategorie, "KategoriaId", "Nazwa", pomocTechniczna.KategoriaId);
            ViewBag.TematId = new SelectList(db.PomocTechnicznaTematy, "TematId", "Nazwa", pomocTechniczna.TematId);
            return View(pomocTechniczna);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "PomocTechnicznaId,UserId,NunerStanowiska,AdresIp,DataZgloszenia,Opis,Status,KategoriaId,TematId")] PomocTechniczna pomocTechniczna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pomocTechniczna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriaId = new SelectList(db.PomocTechnicznaKategorie, "KategoriaId", "Nazwa", pomocTechniczna.KategoriaId);
            ViewBag.TematId = new SelectList(db.PomocTechnicznaTematy, "TematId", "Nazwa", pomocTechniczna.TematId);
            return View(pomocTechniczna);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PomocTechniczna pomocTechniczna = db.PomocTechniczna.Find(id);
            if (pomocTechniczna == null)
            {
                return HttpNotFound();
            }
            return View(pomocTechniczna);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            PomocTechniczna pomocTechniczna = db.PomocTechniczna.Find(id);
            db.PomocTechniczna.Remove(pomocTechniczna);
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

        public ActionResult ListaTematow(int id = 0)
        {
            var listaTematow =
                db.PomocTechnicznaTematy.Where(t => t.KategoriaId == id).Select(x => new { idTematu = x.TematId, nazwaTematu = x.Nazwa }).ToList();
            return Json(listaTematow, JsonRequestBehavior.AllowGet);

        }
    }
}
