using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proyecto.Models.ViewModels
{
    public class AutorViewModel
    {

        public int id_autor { set; get; }

        [Required]
        [Display(Name = "Nombre")]
        public String nombre { set; get; }
    }
}