using PARKING.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARKING.Datos.REPOSITORIOS
{
    public class ClientesRepositorio
    {
        private SqlConnection cn;

        public ClientesRepositorio(SqlConnection cn)
        {
            this.cn = cn;
        }

        public List<Cliente> GetLista()
        {
            List<Cliente> lista = new List<Cliente>();
            try
            {
                var cadenaComando =
                    "select ClienteId, Apellido, Nombre, telefono, RowVersion from Clientes order by Apellido";
                var comando = new SqlCommand (cadenaComando, cn);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cliente cliente = ConstruirCliente(reader);
                        lista.Add(cliente);
                    }
                }
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private Cliente ConstruirCliente(SqlDataReader reader)
        {
            return new Cliente()
            {
                ClienteId = reader.GetInt32(0),
                Apellido = reader.GetString(1),
                Nombre = reader.GetString(2),
                Telefono = reader.GetString(3),
                RowVersion = (byte[])reader[4]
            };
        }
        public int Agregar(Cliente cliente)
        {
            int registrosAfectados = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into Clientes (Apellido, Nombre, telefono, ");
                sb.Append(" values (@ape, @nom, @tel)");

                var cadenaComando = sb.ToString();
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@ape", cliente.Apellido);
                comando.Parameters.AddWithValue("@nom", cliente.Nombre);
                comando.Parameters.AddWithValue("@tel", cliente.Telefono);

                registrosAfectados = comando.ExecuteNonQuery();
                if (registrosAfectados==0)
                {
                    throw new Exception("No se agregaron registros");
                }
                else
                {
                    cadenaComando = "select @@identity";
                    comando = new SqlCommand(cadenaComando, cn);
                    cliente.ClienteId = (int)(decimal)comando.ExecuteScalar();

                    cadenaComando = "select RowVersion from Clientes where ClienteId=@id";
                    comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", cliente.ClienteId);
                    cliente.RowVersion = (byte[])comando.ExecuteScalar();
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Borrar(Cliente cliente)
        {
            int registrosAfectados = 0;
            try
            {
                var cadenaComando = "delete from Clientes where ClienteId=@id and RowVersion=@r";
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@id", cliente.ClienteId);
                comando.Parameters.AddWithValue("@r", cliente.RowVersion);
                registrosAfectados = comando.ExecuteNonQuery();

                return registrosAfectados;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Editar (Cliente cliente)
        {
            int registrosAfectados = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("update Clientes set Apellido=@ape, Nombre=@nom, Telefono=@tel ");
                sb.Append(" where ClienteId=@id");

                var cadenaComando = sb.ToString();
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@ape", cliente.Apellido);
                comando.Parameters.AddWithValue("@nom", cliente.Nombre);
                comando.Parameters.AddWithValue("@tel", cliente.Telefono);
                if (string.IsNullOrEmpty(cliente.Telefono))
                {
                    comando.Parameters.AddWithValue("@tel", DBNull.Value);
                }
                comando.Parameters.AddWithValue("@id", cliente.ClienteId);
                registrosAfectados = comando.ExecuteNonQuery();
                if (registrosAfectados == 0)
                {
                    throw new Exception("No se editaron registros");
                }
                else
                {
                    cadenaComando = "select RowVersion from Clientes where ClienteId=@id";
                    comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", cliente.ClienteId);
                    cliente.RowVersion = (byte[])comando.ExecuteScalar(); 
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cliente GetClientePorId(int id)
        {
            Cliente cliente = null;
            try
            {
                var cadenaComando = "select ClienteId, Apellido, Nombre, Telefono, RowVersion from Clientes where ClienteId=@id";
                using (var comando = new SqlCommand(cadenaComando, cn))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            cliente = ConstruirCliente(reader);
                        }
                    }
                }
                return cliente;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool Existe(Cliente cliente)
        {
            try
            {
                var cadenaComando = "select count(*) from Clientes where Nombre = @nom";
                if (cliente.ClienteId != 0)
                {
                    cadenaComando += " and ClienteId<>@clienteId";
                }
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@nom", cliente.Nombre);
                if (cliente.ClienteId != 0)
                {
                    comando.Parameters.AddWithValue("@clienteId", cliente.ClienteId);
                }
                return (int)comando.ExecuteScalar() > 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
