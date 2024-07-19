using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Lista
    {
        [Display(Name = "Id Lista")] public int idlista { get; set; }
        [Display(Name = "Fecha Lista")] public DateTime fechalista { get; set; }
        [Display(Name = "Id Empresa")] public int idempresa { get; set; }
        [Display(Name = "Id Empleado")] public int idempleado { get; set; }
    }
}