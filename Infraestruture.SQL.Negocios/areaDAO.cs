﻿using Domain.Entity;
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
    public class areaDAO : IArea
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
                    SqlCommand cmd = new SqlCommand("usp_elimina_area", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idarea", id);
                    //ejecutar executeNonQuery(sentencia/procedure), donde retorna la cantidad de reg afectados
                    int i = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha eliminado {i} registros";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public IEnumerable<Area> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Area> getAll()
        {
            List<Area> temporal = new List<Area>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_area", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Area()
                    {
                        idarea = dr.GetInt32(0),
                        nombrearea = dr.GetString(1),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Area reg)
        {
            string mensaje = "";
            //este proceso ejecuta el procedure de insercion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_inserta_area", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idarea", reg.idarea);
                    cmd.Parameters.AddWithValue("@nombrearea", reg.nombrearea);
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

        public Area search(int id)
        {
            //retorna el registro de area filtrado por su idarea
            return getAll().Where(m => m.idarea == id).FirstOrDefault();
        }

        public string update(Area reg)
        {
            string mensaje = "";
            //este proceso ejecuta el procedure de inserccion
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                //controlamos con try catch, donde mensaje recibe el resultado
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_actualiza_area", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idarea", reg.idarea);
                    cmd.Parameters.AddWithValue("@nombrearea", reg.nombrearea);
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

