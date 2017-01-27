using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dorknozzle.Models;

namespace dorknozzle.Controllers
{
    public class WiadomoscController : Controller
    {
        private DorknozzleDbContext db = new DorknozzleDbContext();

        // GET: Wiadomosc
        public ActionResult Index()
        {
            return View(db.Wiadomosc.ToList());
        }

        // GET: Wiadomosc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wiadomosc wiadomosc = db.Wiadomosc.Find(id);
            if (wiadomosc == null)
            {
                return HttpNotFound();
            }
            return View(wiadomosc);
        }

        // GET: Wiadomosc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wiadomosc/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WiadomoscId,Subject,ShortContent,Content")] Wiadomosc wiadomosc)
        {
            if (ModelState.IsValid)
            {
                db.Wiadomosc.Add(wiadomosc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wiadomosc);
        }

        // GET: Wiadomosc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wiadomosc wiadomosc = db.Wiadomosc.Find(id);
            if (wiadomosc == null)
            {
                return HttpNotFound();
            }
            return View(wiadomosc);
        }

        // POST: Wiadomosc/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WiadomoscId,Subject,ShortContent,Content")] Wiadomosc wiadomosc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wiadomosc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wiadomosc);
        }

        // GET: Wiadomosc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wiadomosc wiadomosc = db.Wiadomosc.Find(id);
            if (wiadomosc == null)
            {
                return HttpNotFound();
            }
            return View(wiadomosc);
        }

        // POST: Wiadomosc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wiadomosc wiadomosc = db.Wiadomosc.Find(id);
            db.Wiadomosc.Remove(wiadomosc);
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
