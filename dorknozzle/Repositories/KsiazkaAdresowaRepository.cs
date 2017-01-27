using dorknozzle.Models;
using dorknozzle.Models.ViewModel;
using dorknozzle.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dorknozzle.Repositories
{
    public class KsiazkaAdresowaRepository
    {
        private readonly DorknozzleDbContext _db;

        public KsiazkaAdresowaRepository()
        {
            _db = new DorknozzleDbContext();
        }

        public IQueryable<KsiazkaAdresowaViewModel> GetAllBookAddress()
        {
            IQueryable<KsiazkaAdresowaViewModel> listaAdresow = from k in _db.Pracownicy
                                select new KsiazkaAdresowaViewModel
                                {
                                    PracownicyId = k.PracownicyId,
                                    PełnaNazwa = k.Imie + " " + k.Nazwisko,
                                    Adres = k.Adres,
                                    Miasto = k.Miasto,
                                    TelefonKomorkowy = k.TelefonKomorkowy
                                };

            return listaAdresow;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}