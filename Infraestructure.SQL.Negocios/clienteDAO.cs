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
    public class clienteDAO : ICliente
    {
        public string delete(Cliente reg)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> get(string nombrecliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> getAll()
        {
            List<Cliente> temporal = new List<Cliente>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-AM5J2P7; database=Academytec; uid=sa; pwd=123456"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tb_cliente", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Cliente()
                    {
                        idcliente = dr.GetInt32(0),
                        iddocumento = dr.GetInt32(1),
                        numerodocumento = dr.GetString(2),
                        nombrecliente = dr.GetString(3),
                        apellidopaternocliente = dr.GetString(4),
                        apellidomaternocliente = dr.GetString(5),
                        correo = dr.GetString(6),
                        telefono = dr.GetString(7),
                        foto = dr.GetString(8),
                    });
                } 
                dr.Close();
            }
            return temporal;
        }

        public string insert(Cliente reg)
        {
            throw new NotImplementedException();
        }

        public Cliente search(Cliente reg)
        {
            throw new NotImplementedException();
        }

        public string update(Cliente reg)
        {
            throw new NotImplementedException();
        }
    }
}
