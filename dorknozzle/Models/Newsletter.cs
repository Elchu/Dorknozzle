using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dorknozzle.Models
{
    public class Newsletter
    {

        [Required(ErrorMessage = "Temat jest wymagany.")]
        [Display(Name = "Temat")]
        [StringLength(20, ErrorMessage = "Temat może mieć maksymalnie 20 znaków.")]
        [DataType(DataType.Text)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Treść jest wymagana.")]
        [Display(Name = "Treść")]
        [StringLength(200, ErrorMessage = "Treść może mieć maksymalnie 200 znaków.")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }

}