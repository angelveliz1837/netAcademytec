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
    public class libroDAO : ILibro
    {
        public string delete(Libro reg)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Libro> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Libro> getAll()
        {
            List<Libro> temporal = new List<Libro>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tb_libro", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Libro()
                    {
                        idlibro = dr.GetInt32(0),
                        nombrelibro = dr.GetString(1),
                        descripcionlibro = dr.GetString(2),
                        preciolibro = dr.GetDecimal(3),
                        stock = dr.GetInt32(4),
                        paginas = dr.GetInt32(5),
                        idarea = dr.GetInt32(6),
                        idimpresion = dr.GetInt32(7),
                        idautor = dr.GetInt32(8),
                        idempleado = dr.GetInt32(9),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Libro reg)
        {
            throw new NotImplementedException();
        }

        public Libro search(Libro reg)
        {
            throw new NotImplementedException();
        }

        public string update(Libro reg)
        {
            throw new NotImplementedException();
        }
    }
}

