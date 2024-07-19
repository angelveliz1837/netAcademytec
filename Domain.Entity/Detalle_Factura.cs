using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Detalle_Factura
    {
        [Display(Name = "Id Detalle Factura")] public int iddetallefactura { get; set; }
        [Display(Name = "Id Factura")] public int idfactura { get; set; }
        [Display(Name = "Id Programa")] public int idprograma { get; set; }
        [Display(Name = "Id Libro")] public int idlibro { get; set; }
        [Display(Name = "Cantidad")] public int cantidad { get; set; }
        [Display(Name = "Id Transporte")] public int idtransporte { get; set; }
        [Display(Name = "Importe")] public decimal importe { get; set; }
        [Display(Name = "Precio Venta")] public decimal precioventa { get; set; }
    }
}