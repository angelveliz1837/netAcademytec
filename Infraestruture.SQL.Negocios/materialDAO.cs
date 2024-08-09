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
    public class materialDAO : IMaterial
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
                    SqlCommand cmd = new SqlCommand("usp_elimina_material", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idmaterial", id);
                    //ejecutar executeNonQuery(sentencia/procedure), donde retorna la cantidad de reg afectados
                    int i = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha eliminado {i} registros";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public IEnumerable<Material> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Material> getAll()
        {
            List<Material> temporal = new List<Material>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_material", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Material()
                    {
                        idmaterial = dr.GetInt32(0),
                        nombrematerial = dr.GetString(1),
                        preciomaterial = dr.GetDecimal(2),
                        idrecibo = dr.GetInt32(3),
                        numerorecibo = dr.GetString(4),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Material reg)
        {
            string mensaje = "";
            //este proceso ejecuta el procedure de insercion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_inserta_material", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idmaterial", reg.idmaterial);
                    cmd.Parameters.AddWithValue("@nombrematerial", reg.nombrematerial);
                    cmd.Parameters.AddWithValue("@preciomaterial", reg.preciomaterial);
                    cmd.Parameters.AddWithValue("@idrecibo", reg.idrecibo);
                    cmd.Parameters.AddWithValue("@numerorecibo", reg.numerorecibo);
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

        public Material search(int id)
        {
            //retorna el registro de material filtrado por su idmaterial
            return getAll().Where(m => m.idmaterial == id).FirstOrDefault();
        }

        public string update(Material reg)
        {
            string mensaje = "";
            //este proceso ejecuta el procedure de inserccion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_actualiza_material", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idmaterial", reg.idmaterial);
                    cmd.Parameters.AddWithValue("@nombrematerial", reg.nombrematerial);
                    cmd.Parameters.AddWithValue("@preciomaterial", reg.preciomaterial);
                    cmd.Parameters.AddWithValue("@idrecibo", reg.idrecibo);
                    cmd.Parameters.AddWithValue("@numerorecibo", reg.numerorecibo);
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

