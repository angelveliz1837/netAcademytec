using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Repository;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructure.SQL.Negocios
{
    public class almacenDAO : IAlmacen
    {
        public string delete(Almacen reg)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Almacen> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Almacen> getAll()
        {
            List<Almacen> temporal = new List<Almacen>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tb_almacen", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Almacen()
                    {
                        idalmacen = dr.GetInt32(0),
                        idlibro = dr.GetInt32(1),
                        cantidad = dr.GetInt32(2),
                        idempleado = dr.GetInt32(3),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Almacen reg)
        {
            throw new NotImplementedException();
        }

        public Almacen search(Almacen reg)
        {
            throw new NotImplementedException();
        }

        public string update(Almacen reg)
        {
            throw new NotImplementedException();
        }
    }
}
