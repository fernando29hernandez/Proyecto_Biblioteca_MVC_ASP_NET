using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto.Models.ViewModels
{
    public class ListClienteViewModel
    {

        public int id_cliente { set; get; }
        public String nombre { set; get; }
        public String celular { set; get; }
        public String nit { set; get; }
        public String dpi { set; get; }
    }
}