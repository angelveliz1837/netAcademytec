using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Entity
{
    public class Factura
    {
        public int idfactura { get; set; }
        public DateTime fecha { get; set; }
        public int idempresa { get; set; }
        public int idcliente { get; set; }
        public int idempleado { get; set; }
    }
}