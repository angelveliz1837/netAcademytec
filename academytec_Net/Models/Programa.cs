using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace academytec_Net.Models
{
    public class Programa
    {
        [Display(Name = "Id Programa")] public int idprograma { get; set; }
        [Display(Name = "Titulo")] public string titulo { get; set; }
        [Display(Name = "Descripcion")] public string Descripcion { get; set; }
        [Display(Name = "Id Libro")] public int idlibro { get; set; }
    }
}