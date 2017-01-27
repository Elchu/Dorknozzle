using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dorknozzle.Models.ViewModel
{
    public class PelnyOpisPracownikaViewModel
    {
        public int PracownicyId { get; set; }

        [Display(Name = "Imię nazwisko")]
        public string PełnaNazwa { get; set; }

        public string Dział { get; set; }

        public string Login { get; set; }

        public string Adres { get; set; }

        public string Miasto { get; set; }

        [Phone]
        [Display(Name = "Tel. stacjonarny")]
        [DataType(DataType.PhoneNumber)]
        public string TelefonStacjonarny { get; set; }

        [Display(Name = "Tel. komórkowy")]
        [DataType(DataType.PhoneNumber)]
        public string TelefonKomorkowy { get; set; }
    }
}