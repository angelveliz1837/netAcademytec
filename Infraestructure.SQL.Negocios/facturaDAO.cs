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
    public class facturaDAO : IFactura
    {
        public string delete(Factura reg)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Factura> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Factura> getAll()
        {
            List<Factura> temporal = new List<Factura>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tb_factura", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Factura()
                    {
                        idfactura = dr.GetInt32(0),
                        fecha = dr.GetDateTime(1),
                        idempresa = dr.GetInt32(2),
                        idcliente = dr.GetInt32(3),
                        idempleado = dr.GetInt32(4),
                    });
                }    
                dr.Close();
            }
            return temporal;
        }

        public string insert(Factura reg)
        {
            throw new NotImplementedException();
        }

        public Factura search(Factura reg)
        {
            throw new NotImplementedException();
        }

        public string update(Factura reg)
        {
            throw new NotImplementedException();
        }
    }
}
