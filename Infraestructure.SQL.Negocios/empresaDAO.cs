using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Repository;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructure.SQL.Negocios
{
    public class empresaDAO : IEmpresa
    {
        public string delete(Empresa reg)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Empresa> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Empresa> getAll()
        {
            List<Empresa> temporal = new List<Empresa>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tb_empresa", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Empresa()
                    {
                        idempresa = dr.GetInt32(0),
                        ruc = dr.GetInt32(1),
                        nombre = dr.GetString(2),
                        direccion = dr.GetString(3),
                        telefono = dr.GetString(4),
                        correo = dr.GetString(5),
                        web = dr.GetString(6),
                        logo = dr.GetString(7),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string insert(Empresa reg)
        {
            throw new NotImplementedException();
        }

        public Empresa search(Empresa reg)
        {
            throw new NotImplementedException();
        }

        public string update(Empresa reg)
        {
            throw new NotImplementedException();
        }
    }
}
