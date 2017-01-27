using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dorknozzle.Models
{

    public class PomocTechnicznaKategorie
    {
        [Key]
        public int KategoriaId { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana.")]
        [Display(Name = "Nazwa")]
        public string Nazwa { get; set; }

        public virtual ICollection<PomocTechniczna> PomocTechniczna { get; set; }
        public virtual ICollection<PomocTechnicznaTematy> PomocTechnicznaTematy { get; set; }
    }
}