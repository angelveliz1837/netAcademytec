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
    public class autorDAO : IAutor
    {
        public string delete(Autor reg)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Autor> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Autor> getAll()
        {
            List<Autor> temporal = new List<Autor>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tb_autor", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Autor()
                    {
                        idautor = dr.GetInt32(0),
                        iddocumento = dr.GetInt32(1),
                        numerodocumento = dr.GetString(2),
                        nombreautor = dr.GetString(3),
                        apellidopaternoautor = dr.GetString(4),
                        apellidomaternoautor = dr.GetString(5),
                        correo = dr.GetString(6),
                        telefono = dr.GetString(7),
                        foto = dr.GetString(8),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Autor reg)
        {
            throw new NotImplementedException();
        }

        public Autor search(Autor reg)
        {
            throw new NotImplementedException();
        }

        public string update(Autor reg)
        {
            throw new NotImplementedException();
        }
    }
}
