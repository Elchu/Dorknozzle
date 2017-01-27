using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dorknozzle.Models
{
    public class PomocTechnicznaTematy
    {
        [Key]
        public int TematId { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana.")]
        [Display(Name = "Nazwa")]
        public string Nazwa { get; set; }

        [Display(Name = "Kategoria")]
        public int KategoriaId { get; set; }
        public virtual PomocTechnicznaKategorie PomocTechnicznaKategorie { get; set; }

        public virtual ICollection<PomocTechniczna> PomocTechniczna { get; set; }
    }
}