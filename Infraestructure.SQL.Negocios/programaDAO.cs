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
    public class programaDAO : IPrograma
    {
        public string delete(Programa reg)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Programa> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Programa> getAll()
        {
            List<Programa> temporal = new List<Programa>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tb_programa", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Programa()
                    {
                        idprograma = dr.GetInt32(0),
                        titulo = dr.GetString(1),
                        descripcion = dr.GetString(2),
                        idlibro = dr.GetInt32(3),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Programa reg)
        {
            throw new NotImplementedException();
        }

        public Programa search(Programa reg)
        {
            throw new NotImplementedException();
        }

        public string update(Programa reg)
        {
            throw new NotImplementedException();
        }
    }
}
