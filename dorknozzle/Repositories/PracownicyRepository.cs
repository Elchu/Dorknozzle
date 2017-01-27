using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using dorknozzle.Models;
using dorknozzle.Repositories.IRepository;
using dorknozzle.Models.ViewModel;

namespace dorknozzle.Repositories
{
    public class PracownicyRepository : IPracownicy
    {

        private DorknozzleDbContext _db;

        /// <summary>
        /// /// Konstruktor inicjalizujacy baze danych
        /// </summary>
        public PracownicyRepository()
        {
            _db = new DorknozzleDbContext();
        }
        /// <summary>
        /// Pobranie wszystkich pracowników
        /// </summary>
        /// <returns>Lista pracowników</returns>
        public IQueryable<Pracownicy> GetAllEmployess()
        {
            return _db.Pracownicy;
        }
        /// <summary>
        /// Pobranie pracownikow po identyfikatorze ID
        /// </summary>
        /// <param name="id">Identyfikator pracownika</param>
        /// <returns>Pracownik</returns>
        public Pracownicy GetAllEmployessById(int id)
        {
            return _db.Pracownicy.Find(id);

        }
        /// <summary>
        /// Pobranie szczegolowe dane pracownika po identyfikatorze ID
        /// </summary>
        /// <param name="id">Identyfikator pracownika</param>
        /// <returns>Szczegolowy opis pracownika</returns>
        public PelnyOpisPracownikaViewModel GetAllDetailsEmplyessById(int id)
        {

            IQueryable<PelnyOpisPracownikaViewModel> listaAdresow = from k in _db.Pracownicy
                                                                join d in _db.Dzialy on k.DzialId equals d.DzialId
                                                                join u in _db.Users on k.UserId equals u.Id
                                                                where k.PracownicyId == id
                                                                    select new PelnyOpisPracownikaViewModel
                                                                {
                                                                    PracownicyId = k.PracownicyId,
                                                                    PełnaNazwa = k.Imie + " " + k.Nazwisko,
                                                                    Login = u.UserName,
                                                                    Dział = k.Dzialy.Nazwa,
                                                                    Adres = k.Adres,
                                                                    Miasto = k.Miasto,
                                                                    TelefonStacjonarny = k.TelefonDomowy,
                                                                    TelefonKomorkowy = k.TelefonKomorkowy
                                                                };

            return listaAdresow.First();
        }

        /// <summary>
        /// Pobranie pracownikow po identyfikatorze UserId
        /// </summary>
        /// <param name="userId">UserId pracownika</param>
        /// <returns>Pracownik</returns>
        public Pracownicy GetAllEmployessById(string userId)
        {
            return _db.Pracownicy.FirstOrDefault(u => u.UserId.Equals(userId));
        }

        /// <summary>
        /// Sprawdza czy istnieje pracownik o podanym userId
        /// </summary>
        /// <param name="userId">UserId pracownika do sprawdzenia</param>
        /// <returns>true jesli istnieje, false jesli nie</returns>
        public bool CheckExistEmplayess(string userId)
        {
            return _db.Pracownicy.Any(u => u.UserId.Equals(userId));
        }
        /// <summary>
        /// Dodanie pomocy technicznej
        /// </summary>
        /// <param name="element">Pomoc techniczna do dodania</param>
        public void Add(Pracownicy element)
        {
            _db.Pracownicy.Add(element);
        }
        /// <summary>
        /// Edytowanie pomocy technicznej
        /// </summary>
        /// <param name="element">Pomoc techniczna do edycji</param>
        public void Edit(Pracownicy element)
        {
            _db.Entry(element).State = EntityState.Modified;
        }
        /// <summary>
        /// Usuniecie pomocy technicznej
        /// </summary>
        /// <param name="element">Pomoc techniczna do usuniecia</param>
        public void Delete(Pracownicy element)
        {
            _db.Pracownicy.Remove(element);
        }

        /// <summary>
        /// Zapisanie zmian
        /// </summary>
        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        /// <summary>
        /// Pobranie pracownikow po identyfikatorze dzialu
        /// </summary>
        /// <param name="id">Identyfikator dzialu</param>
        /// <returns>Pracownik</returns>
        public IQueryable<Pracownicy> GetAllEmployessByDepartmentId(int id)
        {
            return _db.Pracownicy.Include(p => p.Dzialy).Where(x => x.DzialId == id);
        }
    }
}