using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Entity
{
    public class Detalle_Lista
    {
        public int iddetallelista { get; set; }
        public int idlista { get; set; }
        public int idmaterial { get; set; }
        public int cantidad { get; set; }
        public decimal preciocosto { get; set; }
    }
}