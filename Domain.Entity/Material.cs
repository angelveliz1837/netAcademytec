using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Material
    {
        [Display(Name = "Id Material")] public int idmaterial { get; set; }
        [Display(Name = "Nombre Material")] public string nombrematerial { get; set; }
        [Display(Name = "Precio Material")] public decimal preciomaterial { get; set; }
        [Display(Name = "Id Recibo")] public int idrecibo { get; set; }
        [Display(Name = "Numero Recibo")] public string numerorecibo { get; set; }
    }
}