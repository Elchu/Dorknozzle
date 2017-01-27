using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using dorknozzle.Models;

namespace dorknozzle.Models
{
    public enum Wojewodztwa
    {
        [Display(Name = "Dolnośląskie")]
        Dolnoslaskie,

        [Display(Name = "Kujawsko-Pomorskie")]
        KujawskoPomorskie,

        [Display(Name = "Lubelskie")]
        Lubelskie,

        [Display(Name = "Lubuskie")]
        Lubuskie,

        [Display(Name = "Łódzkie")]
        Łódzkie,

        [Display(Name = "Małopolskie")]
        Małopolskie,

        [Display(Name = "Mazowieckie")]
        Mazowieckie,

        [Display(Name = "Opolskie")]
        Opolskie,

        [Display(Name = "Podkarpackie")]
        Podkarpackie,

        [Display(Name = "Podlaskie")]
        Podlaskie,

        [Display(Name = "Pomorskie")]
        Pomorskie,

        [Display(Name = "Śląskie")]
        Śląskie,

        [Display(Name = "Świętokrzyskie")]
        Świętokrzyskie,

        [Display(Name = "Warmińsko-Mazurskie")]
        WarmińskoMazurskie,

        [Display(Name = "Wielkopolskie")]
        Wielkopolskie,

        [Display(Name = "Zachodniopomorskie")]
        Zachodniopomorskie
    }

    public class Pracownicy
    {
        [Key]
        public int PracownicyId { get; set; }

        [Display(Name = "Użytkownik")]
        public string UserId { get; set; }

        [Display(Name = "Imię")]
        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Adres jest wymagany.")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Miasto jest wymagane.")]
        public string Miasto { get; set; }

        public Wojewodztwa Wojewodztwo { get; set; }

        [Display(Name = "Kod pocztowy")]
        [RegularExpression(@"^\(?([0-9]{2})\)?[-]?([0-9]{3})$", ErrorMessage = "Wprowadzony numer telefonu jest niepoprawny.")]
        public string KodPocztowy { get; set; }

        [Phone]
        [Display(Name = "Tel. stacjonarny")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Wprowadzony numer telefonu jest niepoprawny.")]
        [DataType(DataType.PhoneNumber)]
        public string TelefonDomowy { get; set; }

        [Phone]
        [Display(Name = "Tel. komórkowy")]
        [RegularExpression(@"^(\d{9})$", ErrorMessage = "Wprowadzony numer telefonu jest niepoprawny.")]
        [DataType(DataType.PhoneNumber)]
        public string TelefonKomorkowy { get; set; }

        public bool Newsletter { get; set; }

        [Display(Name = "Dyiał")]
        public int DzialId { get; set; }
        public virtual Dzialy Dzialy { get; set; }

    }
}