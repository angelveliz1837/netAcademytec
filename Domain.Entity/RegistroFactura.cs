using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class RegistroFactura
    {
        public int      idlibro          { get; set; }
        public string   nombrelibro      { get; set; }
        public string   descripcionlibro { get; set; }
        public decimal  preciolibro      { get; set; }
        public int      cantidad         { get; set; }
        public int      paginas          { get; set; }
        public int      idarea           { get; set; }
        public int      idimpresion      { get; set; }
        public int      idautor          { get; set; }
        public int      idempleado       { get; set; }
        public decimal  monto            { get { return preciolibro * cantidad; } } //campo acumulado
    }
}
