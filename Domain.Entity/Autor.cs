using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Autor
    {
        [Display(Name = "Id Autor")] public int idautor { get; set; }
        [Display(Name = "Id Documento")] public int iddocumento { get; set; }
        [Display(Name = "Numero Documento")] public string numerodocumento { get; set; }
        [Display(Name = "Nombre Autor")] public string nombreautor { get; set; }
        [Display(Name = "Apellido Paterno Autor")] public string apellidopaternoautor { get; set; }
        [Display(Name = "Apellido Materno Autor")] public string apellidomaternoautor { get; set; }
        [Display(Name = "Correo")] public string correo { get; set; }
        [Display(Name = "Telefono")] public string telefono { get; set; }
        [Display(Name = "Foto")] public string foto { get; set; }
    }
}