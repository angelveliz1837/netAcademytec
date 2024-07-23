using Domain.Entity;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestruture.SQL.Negocios
{
    public class detalle_facturaDAO : IDetalle_Factura
    {
        public string delete(int id)
        {
            string mensaje = "";
            //este proceso ejecuta el procedure de insercion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_elimina_detalle_factura", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iddetallefactura", id);
                    //ejecutar executeNonQuery(sentencia/procedure), donde retorna la cantidad de reg afectados
                    int i = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha eliminado {i} registros";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
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
            string mensaje = "";
            //este proceso ejecuta el procedure de insercion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_inserta_detalle_factura", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iddetallefactura", reg.iddetallefactura);
                    cmd.Parameters.AddWithValue("@idfactura", reg.idfactura);
                    cmd.Parameters.AddWithValue("@idprograma", reg.idprograma);
                    cmd.Parameters.AddWithValue("@idlibro", reg.idlibro);
                    cmd.Parameters.AddWithValue("@cantidad", reg.cantidad);
                    cmd.Parameters.AddWithValue("@idtransporte", reg.idtransporte);
                    cmd.Parameters.AddWithValue("@importe", reg.importe);
                    cmd.Parameters.AddWithValue("@precioventa", reg.precioventa);
                    //ejecutar executeNonQuery(sentencia/procedure), donde retorna la cantidad de reg afectados
                    int i = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha insertado {i} registros";
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public Detalle_Factura search(int id)
        {
            //retorna el registro de detalle factura filtrado por su iddetallefactura
            return getAll().Where(m => m.iddetallefactura == id).FirstOrDefault();
        }

        public string update(Detalle_Factura reg)
        {
            string mensaje = "";
            //este proceso ejecuta el procedure de inserccion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_actualiza_detalle_lista", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iddetallefactura", reg.iddetallefactura);
                    cmd.Parameters.AddWithValue("@idfactura", reg.idfactura);
                    cmd.Parameters.AddWithValue("@idprograma", reg.idprograma);
                    cmd.Parameters.AddWithValue("@idlibro", reg.idlibro);
                    cmd.Parameters.AddWithValue("@cantidad", reg.cantidad);
                    cmd.Parameters.AddWithValue("@idtransporte", reg.idtransporte);
                    cmd.Parameters.AddWithValue("@importe", reg.importe);
                    cmd.Parameters.AddWithValue("@precioventa", reg.precioventa);
                    //ejecutar executeNonQuery(sentencia/procedure), donde retorna la cantidad de reg afectados
                    int i = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha actualizado {i} registros";
                }
                catch (Exception ex)
                { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }
    }
}
