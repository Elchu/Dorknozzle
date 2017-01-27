using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dorknozzle.Models;

namespace dorknozzle.Repositories.IRepository
{
    interface IPomocTechniczna : IRepository<PomocTechniczna>
    {
        /// <summary>
        /// Pobranie wszystkich danych
        /// </summary>
        /// <returns>Lista pomocy technicznej</returns>
        IQueryable<PomocTechniczna> GetAllTechnicalSupport();

        /// <summary>
        /// Pobranie pomocy technicznej po identyfikatorze
        /// </summary>
        /// <param name="id">Identyfikator pomocy technicznej</param>
        /// <returns>Dział</returns>
        PomocTechniczna GetTechnicalSupportById(int id);
    }
}
