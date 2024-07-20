using Domain.Entity;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestruture.SQL.Negocios
{
    public class impresionDAO : IImpresion
    {
        public string delete(Impresion reg)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Impresion> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Impresion> getAll()
        {
            List<Impresion> temporal = new List<Impresion>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tb_impresion", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Impresion()
                    {
                        idimpresion = dr.GetInt32(0),
                        descripcion = dr.GetString(1),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Impresion reg)
        {
            throw new NotImplementedException();
        }

        public Impresion search(Impresion reg)
        {
            throw new NotImplementedException();
        }

        public string update(Impresion reg)
        {
            throw new NotImplementedException();
        }
    }
}
