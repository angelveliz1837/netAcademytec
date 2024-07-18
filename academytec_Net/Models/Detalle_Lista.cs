using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace academytec_Net.Models
{
    public class Detalle_Lista
    {
        [Display(Name = "Id Detalle Lista")] public int iddetallelista { get; set; }
        [Display(Name = "Id Lista")] public int idlista { get; set; }
        [Display(Name = "Id Material")] public int idmaterial { get; set; }
        [Display(Name = "Cantidad")] public int cantidad { get; set; }
        [Display(Name = "Precio Costo")] public decimal preciocosto { get; set; }
    }
}