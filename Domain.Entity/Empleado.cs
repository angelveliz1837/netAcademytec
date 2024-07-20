using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Empleado
    {
        public int idempleado { get; set; }
        public int iddocumento { get; set; }
        public string numerodocumento { get; set; }
        public string nombreempleado { get; set; }
        public string apellidopaternoempleado { get; set; }
        public string apellidomaternoempleado { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string cargo { get; set; }
        public string foto { get; set; }
    }
}
