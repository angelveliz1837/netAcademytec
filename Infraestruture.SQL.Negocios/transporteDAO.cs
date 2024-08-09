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
    public class transporteDAO : ITransporte
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
                    SqlCommand cmd = new SqlCommand("usp_elimina_transporte", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idtransporte", id);
                    //ejecutar executeNonQuery(sentencia/procedure), donde retorna la cantidad de reg afectados
                    int i = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha eliminado {i} registros";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
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
                SqlCommand cmd = new SqlCommand("usp_transporte", cn);
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
            string mensaje = "";
            //este proceso ejecuta el procedure de insercion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_inserta_transporte", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idtransporte", reg.idtransporte);
                    cmd.Parameters.AddWithValue("@direccionpartida", reg.direccionpartida);
                    cmd.Parameters.AddWithValue("@direccionllegada", reg.direccionllegada);
                    cmd.Parameters.AddWithValue("@idempleado", reg.idempleado);
                    cmd.Parameters.AddWithValue("@idalmacen", reg.idalmacen);
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

        public Transporte search(int id)
        {
            //retorna el registro de transporte filtrado por su idtransporte
            return getAll().Where(m => m.idtransporte == id).FirstOrDefault();
        }

        public string update(Transporte reg)
        {
            string mensaje = "";
            //este proceso ejecuta el procedure de inserccion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_actualiza_transporte", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idtransporte", reg.idtransporte);
                    cmd.Parameters.AddWithValue("@direccionpartida", reg.direccionpartida);
                    cmd.Parameters.AddWithValue("@direccionllegada", reg.direccionllegada);
                    cmd.Parameters.AddWithValue("@idempleado", reg.idempleado);
                    cmd.Parameters.AddWithValue("@idalmacen", reg.idalmacen);
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