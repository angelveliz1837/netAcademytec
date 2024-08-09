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
    public class facturaDAO : IFactura
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
                    SqlCommand cmd = new SqlCommand("usp_elimina_factura", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idfactura", id);
                    //ejecutar executeNonQuery(sentencia/procedure), donde retorna la cantidad de reg afectados
                    int i = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha eliminado {i} registros";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
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
                SqlCommand cmd = new SqlCommand("usp_factura", cn);
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
            string mensaje = "";
            //este proceso ejecuta el procedure de insercion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_inserta_factura", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idfactura", reg.idfactura);
                    cmd.Parameters.AddWithValue("@fecha", reg.fecha);
                    cmd.Parameters.AddWithValue("@idempresa", reg.idempresa);
                    cmd.Parameters.AddWithValue("@idcliente", reg.idcliente);
                    cmd.Parameters.AddWithValue("@idempleado", reg.idempleado);
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

        public Factura search(int id)
        {
            //retorna el registro de factura filtrado por su idfactura
            return getAll().Where(m => m.idfactura == id).FirstOrDefault();
        }

        public string update(Factura reg)
        {
            string mensaje = "";
            //este proceso ejecuta el procedure de inserccion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_actualiza_factura", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idfactura", reg.idfactura);
                    cmd.Parameters.AddWithValue("@fecha", reg.fecha);
                    cmd.Parameters.AddWithValue("@idempresa", reg.idempresa);
                    cmd.Parameters.AddWithValue("@idcliente", reg.idcliente);
                    cmd.Parameters.AddWithValue("@idempleado", reg.idempleado);
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
