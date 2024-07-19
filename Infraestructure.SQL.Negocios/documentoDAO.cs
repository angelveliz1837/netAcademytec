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
    public class documentoDAO : IDocumento
    {
        public string delete(Documento reg)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Documento> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Documento> getAll()
        {
            List<Documento> temporal = new List<Documento>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tb_documento", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Documento()
                    {
                        iddocumento = dr.GetInt32(0),
                        nombredocumento = dr.GetString(1),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Documento reg)
        {
            throw new NotImplementedException();
        }

        public Documento search(Documento reg)
        {
            throw new NotImplementedException();
        }

        public string update(Documento reg)
        {
            throw new NotImplementedException();
        }
    }
}
