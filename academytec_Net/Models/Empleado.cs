using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace academytec_Net.Models
{
    public class Empleado
    {
        [Display(Name = "Id Empleado")] public int idempleado { get; set; }
        [Display(Name = "Id Documento")] public int iddocumento { get; set; }
        [Display(Name = "Numero Documento")] public string numerodocumento { get; set; }
        [Display(Name = "Nombre Empleado")] public string nombreempleado { get; set; }
        [Display(Name = "Apellido Paterno Empleado")] public string apellidopaternoempleado { get; set; }
        [Display(Name = "Apellido Materno Empleado")] public string apellidomaternoempleado { get; set; }
        [Display(Name = "Correo")] public string correo { get; set; }
        [Display(Name = "Telefono")] public string telefono { get; set; }
        [Display(Name = "Cargo")] public string cargo { get; set; }
        [Display(Name = "Foto")] public string foto { get; set; }
    }
}