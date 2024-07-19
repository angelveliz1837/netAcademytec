using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Impresion
    {
        [Display(Name = "Id Impresion")] public int idimpresion { get; set; }
        [Display(Name = "Descripcion")] public string descripcion { get; set; }
    }
}