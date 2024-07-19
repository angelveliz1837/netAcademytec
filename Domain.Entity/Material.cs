using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Entity
{
    public class Material
    {
        public int idmaterial { get; set; }
        public string nombrematerial { get; set; }
        public decimal preciomaterial { get; set; }
        public int idrecibo { get; set; }
        public string numerorecibo { get; set; }
    }
}