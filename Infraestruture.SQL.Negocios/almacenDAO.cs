using Domain.Entity;
using Domain.Repository;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestruture.SQL.Negocios
{
    public class almacenDAO : IAlmacen
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
                    SqlCommand cmd = new SqlCommand("usp_elimina_almacen", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idalmacen", id);
                    //ejecutar executeNonQuery(sentencia/procedure), donde retorna la cantidad de reg afectados
                    int i = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha eliminado {i} registros";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public IEnumerable<Almacen> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Almacen> getAll()
        {
            List<Almacen> temporal = new List<Almacen>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tb_almacen", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Almacen()
                    {
                        idalmacen = dr.GetInt32(0),
                        idlibro = dr.GetInt32(1),
                        cantidad = dr.GetInt32(2),
                        idempleado = dr.GetInt32(3),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Almacen reg)
        {
            string mensaje = "";
            //este proceso ejecuta el procedure de insercion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_inserta_almacen", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idalmacen", reg.idalmacen);
                    cmd.Parameters.AddWithValue("@idlibro", reg.idlibro);
                    cmd.Parameters.AddWithValue("@cantidad", reg.cantidad);
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

        public Almacen search(int id)
        {
            //retorna el registro de almacen filtrado por su idalmacen
            return getAll().Where(m => m.idalmacen == id).FirstOrDefault();
        }

        public string update(Almacen reg)
        {
            string mensaje = "";
            //este proceso ejecuta el procedure de inserccion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_actualiza_almacen", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idalmacen", reg.idalmacen);
                    cmd.Parameters.AddWithValue("@idlibro", reg.idlibro);
                    cmd.Parameters.AddWithValue("@cantidad", reg.cantidad);
                    cmd.Parameters.AddWithValue("@idempleado", reg.idempleado);
                    //ejecutar executeNonQuery(sentencia/procedure), donde retorna la cantidad de reg afectados
                    int i = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha actualizado {i} registros";
                }
                catch (Exception ex)
                { mensaje = ex.Message;}
                finally { cn.Close(); }
            }
            return mensaje;
        }
    }
}
