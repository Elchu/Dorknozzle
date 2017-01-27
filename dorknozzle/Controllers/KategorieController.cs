using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using dorknozzle.Models;
using dorknozzle.Repositories;

namespace dorknozzle.Controllers
{
    public class KategorieController : Controller
    {
        private readonly PomocTechnicznaKategorieRepository _kategorieRepository;

        public KategorieController()
        {
            _kategorieRepository = new PomocTechnicznaKategorieRepository();
        }
        public ActionResult Index()
        {
            return View(_kategorieRepository.GetAllTechnicalSupportCategory());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KategoriaId,Nazwa")] PomocTechnicznaKategorie pomocTechnicznaKategorie)
        {
            if (ModelState.IsValid)
            {
                _kategorieRepository.Add(pomocTechnicznaKategorie);
                _kategorieRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pomocTechnicznaKategorie);
        }

        public ActionResult Edit(int id = 0)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PomocTechnicznaKategorie pomocTechnicznaKategorie = _kategorieRepository.GetTechnicalSupportCategoryById(id);
            if (pomocTechnicznaKategorie == null)
            {
                return HttpNotFound();
            }
            return View(pomocTechnicznaKategorie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KategoriaId,Nazwa")] PomocTechnicznaKategorie pomocTechnicznaKategorie)
        {
            if (ModelState.IsValid)
            {
                _kategorieRepository.Edit(pomocTechnicznaKategorie);
                _kategorieRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pomocTechnicznaKategorie);
        }

        public ActionResult Delete(int id = 0)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PomocTechnicznaKategorie pomocTechnicznaKategorie = _kategorieRepository.GetTechnicalSupportCategoryById(id);
            if (pomocTechnicznaKategorie == null)
            {
                return HttpNotFound();
            }
            return View(pomocTechnicznaKategorie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PomocTechnicznaKategorie pomocTechnicznaKategorie = _kategorieRepository.GetTechnicalSupportCategoryById(id);
            _kategorieRepository.Delete(pomocTechnicznaKategorie);
            _kategorieRepository.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _kategorieRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
