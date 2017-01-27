using System.Linq;
using System.Web.Mvc;
using dorknozzle.Models;

namespace dorknozzle.Controllers
{
    public class HomeController : Controller
    {
        private DorknozzleDbContext db = new DorknozzleDbContext();
        
        public ActionResult Index(int id = 0)
        {
            if (id > 0)
            {
                Wiadomosc wiadomosc = db.Wiadomosc.FirstOrDefault(w => w.WiadomoscId == id);

                if (wiadomosc != null)
                    return View("SinglePage", wiadomosc);
            }

            return View(db.Wiadomosc.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}