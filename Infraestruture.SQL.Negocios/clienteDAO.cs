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
    public class clienteDAO : ICliente
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
                    SqlCommand cmd = new SqlCommand("usp_elimina_cliente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idcliente", id);
                    //ejecutar executeNonQuery(sentencia/procedure), donde retorna la cantidad de reg afectados
                    int i = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha eliminado {i} registros";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public IEnumerable<Cliente> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> getAll()
        {
            List<Cliente> temporal = new List<Cliente>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_cliente", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Cliente()
                    {
                        idcliente = dr.GetInt32(0),
                        iddocumento = dr.GetInt32(1),
                        numerodocumento = dr.GetString(2),
                        nombrecliente = dr.GetString(3),
                        apellidopaternocliente = dr.GetString(4),
                        apellidomaternocliente = dr.GetString(5),
                        correo = dr.GetString(6),
                        telefono = dr.GetString(7),
                        foto = dr.GetString(8),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Cliente reg)
        {
            string mensaje = "";
            //este proceso ejecuta el procedure de insercion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_inserta_cliente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idcliente", reg.idcliente);
                    cmd.Parameters.AddWithValue("@iddocumento", reg.iddocumento);
                    cmd.Parameters.AddWithValue("@numerodocumento", reg.numerodocumento);
                    cmd.Parameters.AddWithValue("@nombrecliente", reg.nombrecliente);
                    cmd.Parameters.AddWithValue("@apellidopaternocliente", reg.apellidopaternocliente);
                    cmd.Parameters.AddWithValue("@apellidomaternocliente", reg.apellidomaternocliente);
                    cmd.Parameters.AddWithValue("@correo", reg.correo);
                    cmd.Parameters.AddWithValue("@telefono", reg.telefono);
                    cmd.Parameters.AddWithValue("@foto", reg.foto);
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

        public Cliente search(int id)
        {
            //retorna el registro de cliente filtrado por su idcliente
            return getAll().Where(m => m.idcliente == id).FirstOrDefault();
        }

        public string update(Cliente reg)
        {
            string mensaje = "";
            //este proceso ejecuta el procedure de inserccion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_actualiza_cliente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idcliente", reg.idcliente);
                    cmd.Parameters.AddWithValue("@iddocumento", reg.iddocumento);
                    cmd.Parameters.AddWithValue("@numerodocumento", reg.numerodocumento);
                    cmd.Parameters.AddWithValue("@nombrecliente", reg.nombrecliente);
                    cmd.Parameters.AddWithValue("@apellidopaternocliente", reg.apellidopaternocliente);
                    cmd.Parameters.AddWithValue("@apellidomaternocliente", reg.apellidomaternocliente);
                    cmd.Parameters.AddWithValue("@correo", reg.correo);
                    cmd.Parameters.AddWithValue("@telefono", reg.telefono);
                    cmd.Parameters.AddWithValue("@foto", reg.foto);
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
