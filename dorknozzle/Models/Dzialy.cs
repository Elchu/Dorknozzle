using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dorknozzle.Models
{
    public class Dzialy
    {
        [Key]
        public int DzialId { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana.")]
        [Display(Name = "Nazwa")]
        public string Nazwa { get; set; }

        public virtual ICollection<Pracownicy> Pracownicy { get; set; }
    }
}