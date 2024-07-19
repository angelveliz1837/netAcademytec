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
    public class transporteDAO : ITransporte
    {
        public string delete(Transporte reg)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transporte> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transporte> getAll()
        {
            List<Transporte> temporal = new List<Transporte>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tb_transporte", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Transporte()
                    {
                        idtransporte = dr.GetInt32(0),
                        direccionllegada = dr.GetString(1),
                        direccionpartida = dr.GetString(2),
                        idempleado = dr.GetInt32(3),
                        idalmacen = dr.GetInt32(4),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Transporte reg)
        {
            throw new NotImplementedException();
        }

        public Transporte search(Transporte reg)
        {
            throw new NotImplementedException();
        }

        public string update(Transporte reg)
        {
            throw new NotImplementedException();
        }
    }
}
