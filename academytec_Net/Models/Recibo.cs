using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace academytec_Net.Models
{
    public class Recibo
    {
        [Display(Name = "Id Recibo")] public int idrecibo { get; set; }
        [Display(Name = "Nombre Recibo")] public string nombrerecibo { get; set; }
    }
}