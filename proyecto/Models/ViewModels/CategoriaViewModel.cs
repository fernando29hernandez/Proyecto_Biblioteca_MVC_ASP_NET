using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proyecto.Models.ViewModels
{
    public class CategoriaViewModel
    {
        public int id_categoria { set; get; }
        [Required]
        [Display(Name = "Nombre de categoria")]
        public String categoria { set; get; }
    }
}