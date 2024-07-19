using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Almacen
    {
        [Display(Name = "Id Almacen")] public int idalmacen { get; set; }
        [Display(Name = "Id Libro")] public int idlibro { get; set; }
        [Display(Name = "Cantidad")] public int cantidad { get; set; }
        [Display(Name = "Id Empleado")] public int idempleado { get; set; }

    }
}