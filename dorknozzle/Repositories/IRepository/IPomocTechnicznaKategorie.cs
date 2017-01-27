using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dorknozzle.Models;

namespace dorknozzle.Repositories.IRepository
{
    internal interface IPomocTechnicznaKategorie : IRepository<PomocTechnicznaKategorie>
    {
        /// <summary>
        /// Pobranie wszystkich kategorii pomocy technicznej
        /// </summary>
        /// <returns>Lista kategorii pomocy technicznej</returns>
        IQueryable<PomocTechnicznaKategorie> GetAllTechnicalSupportCategory();

        /// <summary>
        /// Pobranie kategorii pomocy technicznej po identyfikatorze
        /// </summary>
        /// <param name="id">Identyfikator kategorii pomocy technicznej</param>
        /// <returns>Dział</returns>
        PomocTechnicznaKategorie GetTechnicalSupportCategoryById(int id);
    }

}
