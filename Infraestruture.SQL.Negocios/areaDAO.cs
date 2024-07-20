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
    public class areaDAO : IArea
    {
        public string delete(Area reg)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Area> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Area> getAll()
        {
            List<Area> temporal = new List<Area>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tb_area", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Area()
                    {
                        idarea = dr.GetInt32(0),
                        nombrearea = dr.GetString(1),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Area reg)
        {
            throw new NotImplementedException();
        }

        public Area search(Area reg)
        {
            throw new NotImplementedException();
        }

        public string update(Area reg)
        {
            throw new NotImplementedException();
        }
    }
}

