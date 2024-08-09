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
    public class detalle_listaDAO : IDetalle_Lista
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
                    SqlCommand cmd = new SqlCommand("usp_elimina_detalle_lista", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iddetallelista", id);
                    //ejecutar executeNonQuery(sentencia/procedure), donde retorna la cantidad de reg afectados
                    int i = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha eliminado {i} registros";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public IEnumerable<Detalle_Lista> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Detalle_Lista> getAll()
        {
            List<Detalle_Lista> temporal = new List<Detalle_Lista>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_detalle_lista", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Detalle_Lista()
                    {
                        iddetallelista = dr.GetInt32(0),
                        idlista = dr.GetInt32(1),
                        idmaterial = dr.GetInt32(2),
                        cantidad = dr.GetInt32(3),
                        preciocosto = dr.GetDecimal(4),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Detalle_Lista reg)
        {
            string mensaje = "";
            //este proceso ejecuta el procedure de insercion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_inserta_detalle_lista", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iddetallelista", reg.iddetallelista);
                    cmd.Parameters.AddWithValue("@idlista", reg.idlista);
                    cmd.Parameters.AddWithValue("@idmaterial", reg.idmaterial);
                    cmd.Parameters.AddWithValue("@cantidad", reg.cantidad);
                    cmd.Parameters.AddWithValue("@preciocosto", reg.preciocosto);
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

        public Detalle_Lista search(int id)
        {
            //retorna el registro de detalle lista filtrado por su iddetallelista
            return getAll().Where(m => m.iddetallelista == id).FirstOrDefault();
        }

        public string update(Detalle_Lista reg)
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
                    cmd.Parameters.AddWithValue("@iddetallelista", reg.iddetallelista);
                    cmd.Parameters.AddWithValue("@idlista", reg.idlista);
                    cmd.Parameters.AddWithValue("@idmaterial", reg.idmaterial);
                    cmd.Parameters.AddWithValue("@cantidad", reg.cantidad);
                    cmd.Parameters.AddWithValue("@preciocosto", reg.preciocosto);
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

