using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain
{
    public interface ICrud<T> where T : class
    {
        string insert(T reg); //T es la estructura de datos
        string update(T reg);
        string delete(T reg);
        T search(T reg);
    }
}
