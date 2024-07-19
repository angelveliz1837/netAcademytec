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
    public class listaDAO : ILista
    {
        public string delete(Lista reg)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lista> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lista> getAll()
        {
            List<Lista> temporal = new List<Lista>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tb_lista", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Lista()
                    {
                        idlista = dr.GetInt32(0),
                        fechalista = dr.GetDateTime(1),
                        idempresa = dr.GetInt32(2),
                        idempleado = dr.GetInt32(3),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Lista reg)
        {
            throw new NotImplementedException();
        }

        public Lista search(Lista reg)
        {
            throw new NotImplementedException();
        }

        public string update(Lista reg)
        {
            throw new NotImplementedException();
        }
    }
}
