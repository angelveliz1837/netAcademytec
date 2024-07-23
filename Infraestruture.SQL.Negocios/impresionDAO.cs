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
    public class impresionDAO : IImpresion
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
                    SqlCommand cmd = new SqlCommand("usp_elimina_impresion", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idimpresion", id);
                    //ejecutar executeNonQuery(sentencia/procedure), donde retorna la cantidad de reg afectados
                    int i = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha eliminado {i} registros";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public IEnumerable<Impresion> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Impresion> getAll()
        {
            List<Impresion> temporal = new List<Impresion>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tb_impresion", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Impresion()
                    {
                        idimpresion = dr.GetInt32(0),
                        descripcion = dr.GetString(1),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Impresion reg)
        {
            string mensaje = "";
            //este proceso ejecuta el procedure de insercion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_inserta_impresion", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idimpresion", reg.idimpresion);
                    cmd.Parameters.AddWithValue("@descripcion", reg.descripcion);
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

        public Impresion search(int id)
        {
            //retorna el registro de impresion filtrado por su idimpresion
            return getAll().Where(m => m.idimpresion == id).FirstOrDefault();
        }

        public string update(Impresion reg)
        {
            string mensaje = "";
            //este proceso ejecuta el procedure de inserccion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_actualiza_impresion", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idimpresion", reg.idimpresion);
                    cmd.Parameters.AddWithValue("@descripcion", reg.descripcion);
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
