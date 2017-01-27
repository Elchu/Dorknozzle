using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using dorknozzle.Models;
using dorknozzle.Repositories.IRepository;

namespace dorknozzle.Repositories
{
    public class DzialRepository : IDzial
    {
        private readonly DorknozzleDbContext _db;

        /// <summary>
        /// /// Konstruktor inicjalizujacy baze danych
        /// </summary>
        public DzialRepository()
        {
            _db = new DorknozzleDbContext();
        }

        /// <summary>
        /// Pobranie wszystkich działów
        /// </summary>
        /// <returns>Lista działów</returns>
        public IQueryable<Dzialy> GetAllDepartment()
        {
            return _db.Dzialy;
        }

        /// <summary>
        /// Pobranie działów po identyfikatorze
        /// </summary>
        /// <param name="id">Identyfikator działu</param>
        /// <returns>Dział</returns>
        public Dzialy GetDepartmentById(int id)
        {
            return _db.Dzialy.Find(id);
        }

        /// <summary>
        /// Dodanie działu
        /// </summary>
        /// <param name="element">Dział do dodania</param>
        public void Add(Dzialy element)
        {
            _db.Dzialy.Add(element);
        }

        /// <summary>
        /// Edytowanie działu
        /// </summary>
        /// <param name="element">Dział do edycji</param>
        public void Edit(Dzialy element)
        {
            _db.Entry(element).State = EntityState.Modified;
        }

        /// <summary>
        /// Usuniecie działu
        /// </summary>
        /// <param name="element">Dział do usuniecia</param>
        public void Delete(Dzialy element)
        {
            _db.Dzialy.Remove(element);
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