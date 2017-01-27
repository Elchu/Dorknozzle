using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dorknozzle.Models;

namespace dorknozzle.Repositories.IRepository
{
    interface IDzial : IRepository<Dzialy>
    {
        /// <summary>
        /// Pobranie wszystkich działów
        /// </summary>
        /// <returns>Lista działów</returns>
        IQueryable<Dzialy> GetAllDepartment();

        /// <summary>
        /// Pobranie działów po identyfikatorze
        /// </summary>
        /// <param name="id">Identyfikator działu</param>
        /// <returns>Dział</returns>
        Dzialy GetDepartmentById(int id);
    }
}
