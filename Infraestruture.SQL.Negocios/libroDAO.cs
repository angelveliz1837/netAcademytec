using Domain.Entity;
using Domain.Repository;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestruture.SQL.Negocios
{
    public class libroDAO : ILibro
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
                    SqlCommand cmd = new SqlCommand("usp_elimina_libro", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idlibro", id);
                    //ejecutar executeNonQuery(sentencia/procedure), donde retorna la cantidad de reg afectados
                    int i = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha eliminado {i} registros";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public IEnumerable<Libro> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Libro> getAll()
        {
            List<Libro> temporal = new List<Libro>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_libro", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Libro()
                    {
                        idlibro = dr.GetInt32(0),
                        nombrelibro = dr.GetString(1),
                        descripcionlibro = dr.GetString(2),
                        preciolibro = dr.GetDecimal(3),
                        stock = dr.GetInt32(4),
                        paginas = dr.GetInt32(5),
                        idarea = dr.GetInt32(6),
                        idimpresion = dr.GetInt32(7),
                        idautor = dr.GetInt32(8),
                        idempleado = dr.GetInt32(9),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Libro reg)
        {
            string mensaje = "";
            //este proceso ejecuta el procedure de insercion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_inserta_libro", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idlibro", reg.idlibro);
                    cmd.Parameters.AddWithValue("@nombrelibro", reg.nombrelibro);
                    cmd.Parameters.AddWithValue("@descripcionlibro", reg.descripcionlibro);
                    cmd.Parameters.AddWithValue("@preciolibro", reg.preciolibro);
                    cmd.Parameters.AddWithValue("@stock", reg.stock);
                    cmd.Parameters.AddWithValue("@paginas", reg.paginas);
                    cmd.Parameters.AddWithValue("@idarea", reg.idarea);
                    cmd.Parameters.AddWithValue("@idimpresion", reg.idimpresion);
                    cmd.Parameters.AddWithValue("@idautor", reg.idautor);
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

        public Libro search(int id)
        {
            //retorna el registro de almacen filtrado por su idalmacen
            return getAll().Where(m => m.idlibro == id).FirstOrDefault();
        }

        public string update(Libro reg)
        {
            string mensaje = "";
            //este proceso ejecuta el procedure de inserccion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_actualiza_libro", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idlibro", reg.idlibro);
                    cmd.Parameters.AddWithValue("@nombrelibro", reg.nombrelibro);
                    cmd.Parameters.AddWithValue("@descripcionlibro", reg.descripcionlibro);
                    cmd.Parameters.AddWithValue("@preciolibro", reg.preciolibro);
                    cmd.Parameters.AddWithValue("@stock", reg.stock);
                    cmd.Parameters.AddWithValue("@paginas", reg.paginas);
                    cmd.Parameters.AddWithValue("@idarea", reg.idarea);
                    cmd.Parameters.AddWithValue("@idimpresion", reg.idimpresion);
                    cmd.Parameters.AddWithValue("@idautor", reg.idautor);
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

