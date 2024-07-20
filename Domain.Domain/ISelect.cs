using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain
{
    public interface ISelect<T> where T : class
    {
        IEnumerable<T> getAll();
        IEnumerable<T> get(string nombrecliente);
    }
}
