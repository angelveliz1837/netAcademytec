using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Cliente
    {
        [Display(Name = "Id Cliente")] public int idcliente { get; set; }
        [Display(Name = "Id Documento")] public int iddocumento { get; set; }
        [Display(Name = "Numero Documento")] public string numerodocumento { get; set; }
        [Display(Name = "Nombre Cliente")] public string nombrecliente { get; set; }
        [Display(Name = "Apellido Paterno Cliente")] public string apellidopaternocliente { get; set; }
        [Display(Name = "Apellido Materno Cliente")] public string apellidomaternocliente { get; set; }
        [Display(Name = "Correo")] public string correo { get; set; }
        [Display(Name = "Telefono")] public string telefono { get; set; }
        [Display(Name = "Foto")] public string foto { get; set; }
    }
}