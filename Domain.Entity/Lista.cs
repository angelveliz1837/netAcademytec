using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Lista
    {
        public int      idlista     { get; set; }
        public DateTime fechalista  { get; set; }
        public int      idempresa   { get; set; }
        public int      idempleado  { get; set; }
    }
}
