using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using dorknozzle.Models;
using dorknozzle.Repositories.IRepository;

namespace dorknozzle.Repositories
{
    public class PomocTechnicznaTematyRepository : IPomocTechnicznaTematy
    {
        private readonly DorknozzleDbContext _db;

        /// <summary>
        /// Pobranie wszystkich pracowników
        /// </summary>
        /// <returns>Lista pracowników</returns>
        public PomocTechnicznaTematyRepository()
        {
            _db = new DorknozzleDbContext();
        }
        /// <summary>
        /// Pobranie wszystkich tematow pomocy technicznej
        /// </summary>
        /// <returns>Lista tematow pomocy technicznej</returns>
        public IQueryable<PomocTechnicznaTematy> GetAllTechnicalSupportTopic()
        {
            return _db.PomocTechnicznaTematy;
        }
        /// <summary>
        /// Pobranie tematow nalezacych do wybranej kategorii pomocy technicznej
        /// </summary>
        /// <param name="id">Identyfikator kategorii pomocy technicznej</param>
        /// <returns>Liste tematow nalezacych do podanej kategorii</returns>
        public IQueryable<PomocTechnicznaTematy> GetAllTechnicalSupportTopicByCategoryId(int id)
        {
            return _db.PomocTechnicznaTematy.Where(t => t.KategoriaId == id);
        }
        /// <summary>
        /// Operacje dodawania
        /// </summary>
        /// <param name="element">Dodawany obiekt</param>
        public void Add(PomocTechnicznaTematy element)
        {
            _db.PomocTechnicznaTematy.Add(element);
        }
        /// <summary>
        /// Operacje edycji
        /// </summary>
        /// <param name="element">Edytowany obiekt</param>
        public void Edit(PomocTechnicznaTematy element)
        {
            _db.Entry(element).State = EntityState.Modified;
        }
        /// <summary>
        /// Operacje usuwania
        /// </summary>
        /// <param name="element">Usuwany obiekt</param>
        public void Delete(PomocTechnicznaTematy element)
        {
            _db.PomocTechnicznaTematy.Remove(element);
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