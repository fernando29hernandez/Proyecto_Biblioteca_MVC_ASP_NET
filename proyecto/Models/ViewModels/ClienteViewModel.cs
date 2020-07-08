using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proyecto.Models.ViewModels
{
    public class ClienteViewModel
    {

        public int id_cliente { set; get; }
        [Required]
        [Display(Name = "Nombre Completo")]
        public String nombre { set; get; }
        [Required]
        [Display(Name = "Numero de Celular")]
        public String celular { set; get; }
        [Required]
        [Display(Name = "Numero de NIT")]
        public String nit { set; get; }
        [Required]
        [Display(Name = "Documento de identificacion DPI")]
        public String dpi { set; get; }
    }
}