using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace academytec_Net.Models
{
    public class Factura
    {
        [Display(Name = "Id Factura")] public int idfactura { get; set; }
        [Display(Name = "Fecha")] public DateTime fecha { get; set; }
        [Display(Name = "Id Empresa")] public int idempresa { get; set; }
        [Display(Name = "Id Cliente")] public int idcliente { get; set; }
        [Display(Name = "Id Empleado")] public int idempleado { get; set; }
    }
}