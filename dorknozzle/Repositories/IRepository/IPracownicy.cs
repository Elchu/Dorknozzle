using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dorknozzle.Models;
using dorknozzle.Models.ViewModel;

namespace dorknozzle.Repositories.IRepository
{
    interface IPracownicy : IRepository<Pracownicy>
    {
        /// <summary>
        /// Pobranie wszystkich pracowników
        /// </summary>
        /// <returns>Lista pracowników</returns>
        IQueryable<Pracownicy> GetAllEmployess();

        /// <summary>
        /// Pobranie pracownikow po identyfikatorze ID
        /// </summary>
        /// <param name="id">Identyfikator pracownika</param>
        /// <returns>Pracownik</returns>
        Pracownicy GetAllEmployessById(int id);

        /// <summary>
        /// Pobranie pracownikow po identyfikatorze UserId
        /// </summary>
        /// <param name="userId">UserId pracownika</param>
        /// <returns>Pracownik</returns>
        Pracownicy GetAllEmployessById(string userId);

        /// <summary>
        /// Pobranie szczegolowe dane pracownika po identyfikatorze ID
        /// </summary>
        /// <param name="id">Identyfikator pracownika</param>
        /// <returns>Szczegolowy opis pracownika</returns>
        PelnyOpisPracownikaViewModel GetAllDetailsEmplyessById(int id);

        /// <summary>
        /// Sprawdza czy istnieje pracownik o podanym userId
        /// </summary>
        /// <param name="userId">UserId pracownika do sprawdzenia</param>
        /// <returns>true jesli istnieje false jesli nie</returns>
        bool CheckExistEmplayess(string userId);

        /// <summary>
        /// Pobranie pracownikow po identyfikatorze dzialu
        /// </summary>
        /// <param name="id">Identyfikator dzialu</param>
        /// <returns>Pracownik</returns>
        IQueryable<Pracownicy> GetAllEmployessByDepartmentId(int id);
    }

}
