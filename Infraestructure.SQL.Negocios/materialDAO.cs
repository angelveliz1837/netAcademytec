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
    public class materialDAO : IMaterial
    {
        public string delete(Material reg)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Material> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Material> getAll()
        {
            List<Material> temporal = new List<Material>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tb_material", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Material()
                    {
                        idmaterial = dr.GetInt32(0),
                        nombrematerial = dr.GetString(1),
                        preciomaterial = dr.GetDecimal(2),
                        idrecibo = dr.GetInt32(3),
                        numerorecibo = dr.GetString(4),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Material reg)
        {
            throw new NotImplementedException();
        }

        public Material search(Material reg)
        {
            throw new NotImplementedException();
        }

        public string update(Material reg)
        {
            throw new NotImplementedException();
        }
    }
}
