using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using dorknozzle.Models;
using dorknozzle.Repositories.IRepository;

namespace dorknozzle.Repositories
{
    public class PomocTechnicznaRepository : IPomocTechniczna
    {
        private readonly DorknozzleDbContext _db;

        /// <summary>
        /// /// Konstruktor inicjalizujacy baze danych
        /// </summary>
        public PomocTechnicznaRepository()
        {
            _db = new DorknozzleDbContext();
        }

        /// <summary>
        /// Pobranie wszystkich danych
        /// </summary>
        /// <returns>Lista pomocy technicznej</returns>
        public IQueryable<PomocTechniczna> GetAllTechnicalSupport()
        {
            return _db.PomocTechniczna;
        }

        /// <summary>
        /// Pobranie pomocy technicznej po identyfikatorze
        /// </summary>
        /// <param name="id">Identyfikator pomocy technicznej</param>
        /// <returns>Dział</returns>
        public PomocTechniczna GetTechnicalSupportById(int id)
        {
            return _db.PomocTechniczna.Find(id);
        }
        /// <summary>
        /// Dodanie pomocy technicznej
        /// </summary>
        /// <param name="element">Pomoc techniczna do dodania</param>
        public void Add(PomocTechniczna element)
        {
            _db.PomocTechniczna.Add(element);
        }
        /// <summary>
        /// Edytowanie pomocy technicznej
        /// </summary>
        /// <param name="element">Pomoc techniczna do edycji</param>
        public void Edit(PomocTechniczna element)
        {
            _db.Entry(element).State = EntityState.Modified;
        }
        /// <summary>
        /// Usuniecie pomocy technicznej
        /// </summary>
        /// <param name="element">Pomoc techniczna do usuniecia</param>
        public void Delete(PomocTechniczna element)
        {
            _db.PomocTechniczna.Remove(element);
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
    }
}