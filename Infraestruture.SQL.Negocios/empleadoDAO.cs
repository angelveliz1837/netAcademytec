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
    public class empleadoDAO : IEmpleado
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
                    SqlCommand cmd = new SqlCommand("usp_elimina_empleado", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idempleado", id);
                    //ejecutar executeNonQuery(sentencia/procedure), donde retorna la cantidad de reg afectados
                    int i = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha eliminado {i} registros";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public IEnumerable<Empleado> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Empleado> getAll()
        {
            List<Empleado> temporal = new List<Empleado>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tb_empleado", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Empleado()
                    {
                        idempleado = dr.GetInt32(0),
                        iddocumento = dr.GetInt32(1),
                        numerodocumento = dr.GetString(2),
                        nombreempleado = dr.GetString(3),
                        apellidopaternoempleado = dr.GetString(4),
                        apellidomaternoempleado = dr.GetString(5),
                        correo = dr.GetString(6),
                        telefono = dr.GetString(7),
                        cargo = dr.GetString(8),
                        foto = dr.GetString(9),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Empleado reg)
        {
            string mensaje = "";
            //este proceso ejecuta el procedure de insercion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_inserta_empleado", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idempleado", reg.idempleado);
                    cmd.Parameters.AddWithValue("@iddocumento", reg.iddocumento);
                    cmd.Parameters.AddWithValue("@numerodocumento", reg.numerodocumento);
                    cmd.Parameters.AddWithValue("@nombreempleado", reg.nombreempleado);
                    cmd.Parameters.AddWithValue("@apellidopaternoempleado", reg.apellidopaternoempleado);
                    cmd.Parameters.AddWithValue("@apellidomaternoempleado", reg.apellidomaternoempleado);
                    cmd.Parameters.AddWithValue("@correo", reg.correo);
                    cmd.Parameters.AddWithValue("@telefono", reg.telefono);
                    cmd.Parameters.AddWithValue("@cargo", reg.cargo);
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

        public Empleado search(int id)
        {
            //retorna el registro de almacen filtrado por su idalmacen
            return getAll().Where(m => m.idempleado == id).FirstOrDefault();
        }

        public string update(Empleado reg)
        {
            string mensaje = "";
            //este proceso ejecuta el procedure de inserccion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_actualiza_empleado", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idempleado", reg.idempleado);
                    cmd.Parameters.AddWithValue("@iddocumento", reg.iddocumento);
                    cmd.Parameters.AddWithValue("@numerodocumento", reg.numerodocumento);
                    cmd.Parameters.AddWithValue("@nombreempleado", reg.nombreempleado);
                    cmd.Parameters.AddWithValue("@apellidopaternoempleado", reg.apellidopaternoempleado);
                    cmd.Parameters.AddWithValue("@apellidomaternoempleado", reg.apellidomaternoempleado);
                    cmd.Parameters.AddWithValue("@correo", reg.correo);
                    cmd.Parameters.AddWithValue("@telefono", reg.telefono);
                    cmd.Parameters.AddWithValue("@cargo", reg.cargo);
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
