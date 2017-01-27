using System.Linq;
using System.Web.Mvc;
using dorknozzle.Models;
using dorknozzle.Repositories;

namespace dorknozzle.Controllers
{
    public class DzialyController : Controller
    {
        private readonly PracownicyRepository _pracownicyRepository;
        private readonly DzialRepository _dzialyRepository;
        public DzialyController()
        {
            _pracownicyRepository = new PracownicyRepository();
            _dzialyRepository = new DzialRepository();
        }

        public ActionResult Index()
        {
            return View(_dzialyRepository.GetAllDepartment());
        }

        public ActionResult Create()
        {
            if (Request.IsAjaxRequest())
                return PartialView("_create");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DzialId,Nazwa")] Dzialy dzialy)
        {
            if (ModelState.IsValid)
            {
                _dzialyRepository.Add(dzialy);
                _dzialyRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dzialy);
        }

        public ActionResult Edit(int id = 0)
        {
            Dzialy dzialy = _dzialyRepository.GetDepartmentById(id);
            if (dzialy == null)
            {
                return HttpNotFound();
            }

            if (Request.IsAjaxRequest())
                return PartialView("_edit", dzialy);

            return View(dzialy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DzialId,Nazwa")] Dzialy dzialy)
        {
            if (ModelState.IsValid)
            {
                _dzialyRepository.Edit(dzialy);
                _dzialyRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dzialy);
        }

        public ActionResult Delete(int id = 0)
        {
            Dzialy dzialy = _dzialyRepository.GetDepartmentById(id);
            if (dzialy == null)
            {
                return HttpNotFound();
            }

            if (Request.IsAjaxRequest())
                return PartialView("_delete", dzialy);

            return View(dzialy);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dzialy dzialy = _dzialyRepository.GetDepartmentById(id);
            _dzialyRepository.Delete(dzialy);
            _dzialyRepository.SaveChanges();    
            return RedirectToAction("Index");
        }

        public ActionResult ListaPracownikow(int id = 0)
        {
            IQueryable<Pracownicy> lista = _pracownicyRepository.GetAllEmployessByDepartmentId(id);
            
            if(Request.IsAjaxRequest())
                return PartialView("_listaPracownikow", lista);

            return View(lista);
        }

    }
}
