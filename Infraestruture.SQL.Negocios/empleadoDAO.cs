using Domain.Entity;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestruture.SQL.Negocios
{
    public class empleadoDAO : IEmpleado
    {
        public string delete(Empleado reg)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Empleado search(Empleado reg)
        {
            throw new NotImplementedException();
        }

        public string update(Empleado reg)
        {
            throw new NotImplementedException();
        }
    }
}
