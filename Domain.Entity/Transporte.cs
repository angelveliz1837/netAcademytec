using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Entity
{
    public class Transporte
    {
        public int idtransporte {  get; set; }
        public string direccionpartida { get; set; }
        public string direccionllegada{ get; set; }
        public int idempleado { get; set; }
        public int idalmacen { get; set; }
    }
}