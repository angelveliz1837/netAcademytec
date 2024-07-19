using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Entity
{
    public class Autor
    {
        public int idautor { get; set; }
        public int iddocumento { get; set; }
        public string numerodocumento { get; set; }
        public string nombreautor { get; set; }
        public string apellidopaternoautor { get; set; }
        public string apellidomaternoautor { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string foto { get; set; }
    }
}