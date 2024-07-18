using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace academytec_Net.Models
{
    public class Documento
    {
        [Display(Name = "Id Documento")] public int iddocumento { get; set; }
        [Display(Name = "Nombre Documento")] public string nombredocumento { get; set; }
    }
}