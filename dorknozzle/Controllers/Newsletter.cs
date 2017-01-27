using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dorknozzle.Helpers;
using dorknozzle.Models;

namespace dorknozzle.Controllers
{
    public class NewsletterController : Controller
    {

        private DorknozzleDbContext _db = new DorknozzleDbContext();

        public NewsletterController()
        {
            _db = new DorknozzleDbContext();
        }

        public ActionResult Send()
        {
            var emails = (from p in _db.Pracownicy
                join u in _db.Users on p.UserId equals u.Id
                where p.Newsletter
                select new
                {
                    id = u.Email,
                    nazwa = p.Imie + " " + p.Nazwisko
                }).ToList();
            
            ViewBag.UserEmails = new SelectList(emails, "id", "nazwa");
            return View();
        }

        [HttpPost]
        public ActionResult Send(Newsletter news, string UserEmails)
        {
            if (string.IsNullOrWhiteSpace(UserEmails))
                ModelState.AddModelError("UserEmails", "Wybierz poprawny email");

            if (ModelState.IsValid)
            {
                    // Wykorzystanie helpera do wysyłania e-maili
                    MailHelper.SendEmail(UserEmails, news.Subject, news.Content);
                    TempData["Message"] = "Newsletter został wysłany";
                    return RedirectToAction("Send");
            }

            var emails = (from p in _db.Pracownicy
                          join u in _db.Users on p.UserId equals u.Id
                          where p.Newsletter
                          select new
                          {
                              id = u.Email,
                              nazwa = p.Imie + " " + p.Nazwisko
                          }).ToList();

            ViewBag.UserEmails = new SelectList(emails, "id", "nazwa");

            // W przypadku błędów zwrócenie aktualnego widoku
            return View(news);
        }

        public ActionResult SendAll()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendAll(Newsletter news)
        {
            if (ModelState.IsValid)
            {
                // Pobranie wszystkich subskrybentów
                List<string> emails = (from p in _db.Pracownicy
                    join u in _db.Users on p.UserId equals u.Id
                    where p.Newsletter
                    select u.Email ).ToList();

                if (emails.Count > 0)
                {
                    // Wykorzystanie helpera do wysyłania e-maili
                    MailHelper.SendEmailAll(emails, news.Subject, news.Content);
                    TempData["Message"] = "Newsletter został wysłany";
                    return RedirectToAction("SendAll");
                }
                else
                {
                    TempData["Error"] = "Brak aktywnych użytkowników. Newsletter nie został wysłany.";
                    return RedirectToAction("SendAll");
                }
            }

            // W przypadku błędów zwrócenie aktualnego widoku
            return View(news);
        }

    }
}