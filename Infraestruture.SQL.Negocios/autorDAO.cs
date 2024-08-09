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
    public class autorDAO : IAutor
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
                    SqlCommand cmd = new SqlCommand("usp_elimina_autor", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idautor", id);
                    //ejecutar executeNonQuery(sentencia/procedure), donde retorna la cantidad de reg afectados
                    int i = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha eliminado {i} registros";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public IEnumerable<Autor> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Autor> getAll()
        {
            List<Autor> temporal = new List<Autor>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_autor", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Autor()
                    {
                        idautor = dr.GetInt32(0),
                        iddocumento = dr.GetInt32(1),
                        numerodocumento = dr.GetString(2),
                        nombreautor = dr.GetString(3),
                        apellidopaternoautor = dr.GetString(4),
                        apellidomaternoautor = dr.GetString(5),
                        correo = dr.GetString(6),
                        telefono = dr.GetString(7),
                        foto = dr.GetString(8),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Autor reg)
        {
            string mensaje = "";
            //este proceso ejecuta el procedure de insercion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_inserta_autor", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idautor", reg.idautor);
                    cmd.Parameters.AddWithValue("@iddocumento", reg.iddocumento);
                    cmd.Parameters.AddWithValue("@numerodocumento", reg.numerodocumento);
                    cmd.Parameters.AddWithValue("@nombreautor", reg.nombreautor);
                    cmd.Parameters.AddWithValue("@apellidopaternoautor", reg.apellidopaternoautor);
                    cmd.Parameters.AddWithValue("@apellidomaternoautor", reg.apellidomaternoautor);
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

        public Autor search(int id)
        {
            //retorna el registro de autor filtrado por su idautor
            return getAll().Where(m => m.idautor == id).FirstOrDefault();
        }

        public string update(Autor reg)
        {
            string mensaje = "";
            //este proceso ejecuta el procedure de inserccion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_actualiza_autor", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idautor", reg.idautor);
                    cmd.Parameters.AddWithValue("@iddocumento", reg.iddocumento);
                    cmd.Parameters.AddWithValue("@numerodocumento", reg.numerodocumento);
                    cmd.Parameters.AddWithValue("@nombreautor", reg.nombreautor);
                    cmd.Parameters.AddWithValue("@apellidopaternoautor", reg.apellidopaternoautor);
                    cmd.Parameters.AddWithValue("@apellidomaternoautor", reg.apellidomaternoautor);
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
