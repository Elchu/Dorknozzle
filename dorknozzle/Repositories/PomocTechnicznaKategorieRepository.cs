using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using dorknozzle.Models;
using dorknozzle.Repositories.IRepository;

namespace dorknozzle.Repositories
{
    public class PomocTechnicznaKategorieRepository : IPomocTechnicznaKategorie
    {
        private readonly DorknozzleDbContext _db;

        /// <summary>
        /// /// Konstruktor inicjalizujacy baze danych
        /// </summary>
        public PomocTechnicznaKategorieRepository()
        {
            _db = new DorknozzleDbContext();
        }
        /// <summary>
        /// Pobranie wszystkich kategorii pomocy technicznej
        /// </summary>
        /// <returns>Lista kategorii pomocy technicznej</returns>
        public IQueryable<PomocTechnicznaKategorie> GetAllTechnicalSupportCategory()
        {
            return _db.PomocTechnicznaKategorie;
        }
        /// <summary>
        /// Pobranie kategorii pomocy technicznej po identyfikatorze
        /// </summary>
        /// <param name="id">Identyfikator kategorii pomocy technicznej</param>
        /// <returns>Dział</returns>
        public PomocTechnicznaKategorie GetTechnicalSupportCategoryById(int id)
        {
            return _db.PomocTechnicznaKategorie.Find(id);
        }
        /// <summary>
        /// Operacje dodawania
        /// </summary>
        /// <param name="element">Dodawany obiekt</param>
        public void Add(PomocTechnicznaKategorie element)
        {
            _db.PomocTechnicznaKategorie.Add(element);
        }
        /// <summary>
        /// Operacje edycji
        /// </summary>
        /// <param name="element">Edytowany obiekt</param>
        public void Edit(PomocTechnicznaKategorie element)
        {
            _db.Entry(element).State = EntityState.Modified;
        }
        /// <summary>
        /// Operacje usuwania
        /// </summary>
        /// <param name="element">Usuwany obiekt</param>
        public void Delete(PomocTechnicznaKategorie element)
        {
            _db.PomocTechnicznaKategorie.Remove(element);
        }
        /// <summary>
        /// Zapis zmian
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