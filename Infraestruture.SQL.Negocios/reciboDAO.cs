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
    public class reciboDAO : IRecibo
    {
        public string delete(Recibo reg)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recibo> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recibo> getAll()
        {
            List<Recibo> temporal = new List<Recibo>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tb_recibo", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Recibo()
                    {
                        idrecibo = dr.GetInt32(0),
                        nombrerecibo = dr.GetString(1),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Recibo reg)
        {
            throw new NotImplementedException();
        }

        public Recibo search(Recibo reg)
        {
            throw new NotImplementedException();
        }

        public string update(Recibo reg)
        {
            throw new NotImplementedException();
        }
    }
}