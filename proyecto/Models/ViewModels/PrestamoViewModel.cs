using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proyecto.Models
{
    [MetadataType(typeof(metadata))]
    public partial class Prestamo
    {
        public class metadata {
            public int id_prestamo { get; set; }
            [Display(Name =  "Libro a prestar")]
            [DisplayFormat(ApplyFormatInEditMode = true)]
            public int id_libro { get; set; }
            [Display( Name = "Cliente quien presta el libro")]
            [DisplayFormat(ApplyFormatInEditMode = true)]
            public int id_cliente { get; set; }
            [DataType(DataType.Date)]
            [Display(Name = "Fecha de inicio del prestamo")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
            public System.DateTime inicio { get; set; }
            [DataType(DataType.Date)]
            [Display(Name = "Fecha Fin del prestamo")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
            public System.DateTime final { get; set; }
            [Display(Name = "Cliente quien presta el libro")]
            [DisplayFormat(ApplyFormatInEditMode = true)]
            public virtual Cliente Cliente { get; set; }
            [Display(Name = "Libro a prestar")]
            [DisplayFormat(ApplyFormatInEditMode = true)]
            public virtual Libro Libro { get; set; }
        }
    }
}