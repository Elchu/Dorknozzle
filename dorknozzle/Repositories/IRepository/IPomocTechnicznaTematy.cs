using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dorknozzle.Models;

namespace dorknozzle.Repositories.IRepository
{
    interface IPomocTechnicznaTematy : IRepository<PomocTechnicznaTematy>
    {
        /// <summary>
        /// Pobranie wszystkich tematow pomocy technicznej
        /// </summary>
        /// <returns>Lista tematow pomocy technicznej</returns>
        IQueryable<PomocTechnicznaTematy> GetAllTechnicalSupportTopic();

        /// <summary>
        /// Pobranie tematow nalezacych do wybranej kategorii pomocy technicznej
        /// </summary>
        /// <param name="id">Identyfikator kategorii pomocy technicznej</param>
        /// <returns>Liste tematow nalezacych do podanej kategorii</returns>
        IQueryable<PomocTechnicznaTematy> GetAllTechnicalSupportTopicByCategoryId(int id);
    }

}
