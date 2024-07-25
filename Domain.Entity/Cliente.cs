using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Cliente
    {
        public int    idcliente                 { get; set; }
        public int    iddocumento               { get; set; }
        public string numerodocumento           { get; set; }
        public string nombrecliente             { get; set; }
        public string apellidopaternocliente    { get; set; }
        public string apellidomaternocliente    { get; set; }
        public string correo                    { get; set; }
        public string telefono                  { get; set; }
        public string foto                      { get; set; }
    }
}
