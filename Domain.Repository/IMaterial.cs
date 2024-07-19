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
    public interface IMaterial:ISelect<Material>, ICrud<Material>
    {
    }
}
