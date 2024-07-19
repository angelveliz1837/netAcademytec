using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Empresa
    {
        [Display(Name = "Id Empresa")] public int idempresa { get; set; }
        [Display(Name = "Ruc")] public int ruc { get; set; }
        [Display(Name = "Nombre")] public string nombre { get; set; }
        [Display(Name = "Direccion")] public string direccion { get; set; }
        [Display(Name = "Correo")] public string correo { get; set; }
        [Display(Name = "Telefono")] public string telefono { get; set; }
        [Display(Name = "Web")] public string web { get; set; }
        [Display(Name = "Logo")] public string logo { get; set; }
    }
}