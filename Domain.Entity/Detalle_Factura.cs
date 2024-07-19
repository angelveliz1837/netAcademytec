using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Entity
{
    public class Detalle_Factura
    {
        public int iddetallefactura { get; set; }
        public int idfactura { get; set; }
        public int idprograma { get; set; }
        public int idlibro { get; set; }
        public int cantidad { get; set; }
        public int idtransporte { get; set; }
        public decimal importe { get; set; }
        public decimal precioventa { get; set; }
    }
}