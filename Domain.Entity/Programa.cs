using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Entity
{
    public class Programa
    {
        public int idprograma { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public int idlibro { get; set; }
    }
}