using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//importar las librerias
using Domain.Domain;
using Domain.Entity;

namespace Domain.Repository
{
    public interface IDetalle_Factura:ISelect<Detalle_Factura>, ICrud<Detalle_Factura>
    {
    }
}
