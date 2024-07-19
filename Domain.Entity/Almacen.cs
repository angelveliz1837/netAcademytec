using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Entity
{
    public class Almacen
    {
        public int idalmacen { get; set; }
        public int idlibro { get; set; }
        public int cantidad { get; set; }
        public int idempleado { get; set; }

    }
}