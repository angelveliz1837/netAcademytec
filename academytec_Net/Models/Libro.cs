using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
.using System.ComponentModel.DataAnnotations;

namespace academytec_Net.Models
{
    public class Libro
    {
        [Display(Name = "Id Libro")] public int idlibro { get; set; }
        [Display(Name = "Nombre Libro")] public string nombrelibro { get; set; }
        [Display(Name = "Descripcion Libro")] public string descripcionlibro { get; set; }
        [Display(Name = "Precio Libro")] public decimal preciolibro { get; set; }
        [Display(Name = "Stock")] public int stock { get; set; }
        [Display(Name = "Paginas")] public int paginas { get; set; }
        [Display(Name = "Id Area")] public int idarea { get; set; }
        [Display(Name = "Id Impresion")] public int idimpresion { get; set; }
        [Display(Name = "Id Autor")] public int idautor { get; set; }
        [Display(Name = "Id Empleado")] public int idempleado { get; set; }

    }
}