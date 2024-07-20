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
    public class detalle_listaDAO : IDetalle_Lista
    {
        public string delete(Detalle_Lista reg)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Detalle_Lista> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Detalle_Lista> getAll()
        {
            List<Detalle_Lista> temporal = new List<Detalle_Lista>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tb_detalle_lista", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Detalle_Lista()
                    {
                        iddetallelista = dr.GetInt32(0),
                        idlista = dr.GetInt32(1),
                        idmaterial = dr.GetInt32(2),
                        cantidad = dr.GetInt32(3),
                        preciocosto = dr.GetDecimal(4),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Detalle_Lista reg)
        {
            throw new NotImplementedException();
        }

        public Detalle_Lista search(Detalle_Lista reg)
        {
            throw new NotImplementedException();
        }

        public string update(Detalle_Lista reg)
        {
            throw new NotImplementedException();
        }
    }
}

