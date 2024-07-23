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
    public class programaDAO : IPrograma
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
                    SqlCommand cmd = new SqlCommand("usp_elimina_programa", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idprograma", id);
                    //ejecutar executeNonQuery(sentencia/procedure), donde retorna la cantidad de reg afectados
                    int i = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha eliminado {i} registros";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public IEnumerable<Programa> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Programa> getAll()
        {
            List<Programa> temporal = new List<Programa>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tb_programa", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Programa()
                    {
                        idprograma = dr.GetInt32(0),
                        titulo = dr.GetString(1),
                        descripcion = dr.GetString(2),
                        idlibro = dr.GetInt32(3),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Programa reg)
        {
            string mensaje = "";
            //este proceso ejecuta el procedure de insercion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_inserta_programa", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idprograma", reg.idprograma);
                    cmd.Parameters.AddWithValue("@titulo", reg.titulo);
                    cmd.Parameters.AddWithValue("@descripcion", reg.descripcion);
                    cmd.Parameters.AddWithValue("@idlibro", reg.idlibro);
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

        public Programa search(int id)
        {
            //retorna el registro de programa filtrado por su idprograma
            return getAll().Where(m => m.idprograma == id).FirstOrDefault();
        }

        public string update(Programa reg)
        {
            string mensaje = "";
            //este proceso ejecuta el procedure de inserccion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_actualiza_programa", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idprograma", reg.idprograma);
                    cmd.Parameters.AddWithValue("@titulo", reg.titulo);
                    cmd.Parameters.AddWithValue("@descripcion", reg.descripcion);
                    cmd.Parameters.AddWithValue("@idlibro", reg.idlibro);
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

