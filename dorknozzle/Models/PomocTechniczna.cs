using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dorknozzle.Models
{
    public enum Status
    {
        Oczekuje,
        Realizacja,
        Zrealizowane
    }

    public class PomocTechniczna
    {
        [Key]
        public int PomocTechnicznaId { get; set; }

        [Display(Name = "Użytkownik")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Numer stanowiska jest wymagany.")]
        [Display(Name = "Numer stanowiska")]
        public string NunerStanowiska { get; set; }

        public string AdresIp { get; set; }

        [Display(Name = "Data zgłoszenia")]
        [DisplayFormat(DataFormatString = "{0:yy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime DataZgloszenia { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany.")]
        public string Opis { get; set; }

        public Status Status { get; set; }

        [Required(ErrorMessage = "Kategoria jest wymagana.")]
        [Display(Name = "Kategoria")]
        public int KategoriaId { get; set; }
        
        public virtual PomocTechnicznaKategorie PomocTechnicznaKategorie { get; set; }

        [Required(ErrorMessage = "Temat jest wymagany.")]
        [Display(Name = "Temat")]
        public int TematId { get; set; }
        
        public virtual PomocTechnicznaTematy PomocTechnicznaTematy { get; set; }
    }
}