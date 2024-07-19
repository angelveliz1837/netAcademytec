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
    public class detalle_facturaDAO : IDetalle_Factura
    {
        public string delete(Detalle_Factura reg)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Detalle_Factura> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Detalle_Factura> getAll()
        {
            List<Detalle_Factura> temporal = new List<Detalle_Factura>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tb_detalle_factura", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Detalle_Factura()
                    {
                        iddetallefactura = dr.GetInt32(0),
                        idfactura = dr.GetInt32(1),
                        idprograma = dr.GetInt32(2),
                        idlibro = dr.GetInt32(3),
                        cantidad = dr.GetInt32(4),
                        idtransporte = dr.GetInt32(5),
                        importe = dr.GetDecimal(6),
                        precioventa = dr.GetDecimal(7),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Detalle_Factura reg)
        {
            throw new NotImplementedException();
        }

        public Detalle_Factura search(Detalle_Factura reg)
        {
            throw new NotImplementedException();
        }

        public string update(Detalle_Factura reg)
        {
            throw new NotImplementedException();
        }
    }
}
