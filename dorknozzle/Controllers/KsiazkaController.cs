using System.Linq;
using System.Web.Mvc;
using dorknozzle.Models.ViewModel;
using dorknozzle.Repositories;

namespace dorknozzle.Controllers
{
    public class KsiazkaController : Controller
    {
        private readonly KsiazkaAdresowaRepository ksiazkaAdresowRepository;
        private readonly PracownicyRepository pracownicyRepository;
        public KsiazkaController()
        {
            ksiazkaAdresowRepository = new KsiazkaAdresowaRepository();
            pracownicyRepository = new PracownicyRepository();
        }

        public ActionResult Index()
        {
            IQueryable<KsiazkaAdresowaViewModel> listaAdresow = ksiazkaAdresowRepository.GetAllBookAddress();
            return View(listaAdresow);
        }


        public ActionResult Details(int id)
        {
            var pracownik = pracownicyRepository.GetAllDetailsEmplyessById(id);
            return PartialView("_details2", pracownik);
        }

    }
}
