using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace academytec_Net.Models
{
    public class Transporte
    {
        [Display (Name ="Id Transporte")] public int idtransporte {  get; set; }
        [Display(Name = "Direccion Partida")] public string direccionpartida { get; set; }
        [Display(Name = "Direccion Llegada")] public string direccionllegada{ get; set; }
        [Display(Name = "Id Empleado")] public int idempleado { get; set; }
        [Display(Name = "Id Almacen")] public int idalmacen { get; set; }
    }
}