using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace academytec_Net.Models
{
    public class Area
    {
        [Display(Name = "Id Area")] public int idarea { get; set; }
        [Display(Name = "Nombre Area")] public string nombrearea { get; set; }
    }
}