using PARKING.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARKING.Datos.REPOSITORIOS
{
    public class VehiculosRepositorio
    {
        private SqlConnection cn;

        public VehiculosRepositorio(SqlConnection cn)
        {
            this.cn = cn;
        }

        public List<Vehiculo> GetLista()
        {
            List<Vehiculo> lista = new List<Vehiculo>();
            try
            {
                var cadenaComando = "select Patente from Vehiculos order by Patente";
                var comando = new SqlCommand(cadenaComando, cn);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Vehiculo vehiculo = ConstruirVehiculo(reader);
                        lista.Add(vehiculo);
                    }
                }
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private Vehiculo ConstruirVehiculo(SqlDataReader reader)
        {
            return new Vehiculo()
            {
                VehiculoId = reader.GetInt32(0),
                Patente = reader.GetString(1),
                TipoVehiculoId = reader.GetInt32(2),
                RowVersion = (byte[])reader[3]
            };
        }
        public int Agregar(Vehiculo vehiculo)
        {
            int registrosAfectados = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into Vehiculos (Patente, TipoVehiculoId)");
                sb.Append(" values (@patente, @tipoVehiculoId)");

                var cadenaComando = sb.ToString();
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@patente", vehiculo.Patente );
                comando.Parameters.AddWithValue("@tipoVehiculoId", vehiculo.TipoVehiculoId);

                registrosAfectados = comando.ExecuteNonQuery();
                if (registrosAfectados == 0)
                {
                    throw new Exception("No se agregaron registros");
                }
                else
                {
                    cadenaComando = "select @@identity";
                    comando = new SqlCommand(cadenaComando, cn);
                    vehiculo.VehiculoId = (int)(decimal)comando.ExecuteScalar();

                    cadenaComando = "select RowVersion from Vehiculos where VehiculoId=@id";
                    comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", vehiculo.VehiculoId);
                    vehiculo.RowVersion = (byte[])comando.ExecuteScalar();
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Borrar(Vehiculo vehiculo)
        {
            int registrosAfectados = 0;
            try
            {
                var cadenaComando = "delete from Vehiculos where VehiculoId=@id and RowVersion=@r";
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@id", vehiculo.VehiculoId);
                comando.Parameters.AddWithValue("@r", vehiculo.RowVersion);
                registrosAfectados = comando.ExecuteNonQuery();

                return registrosAfectados;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Editar(Vehiculo vehiculo)
        {
            int registrosAfectados = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("update Vehiculos set Patente=@patente ");
                sb.Append(" where VehiculoId=@id");

                var cadenaComando = sb.ToString();
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@patente", vehiculo.Patente);

                comando.Parameters.AddWithValue("@id", vehiculo.VehiculoId);
                registrosAfectados = comando.ExecuteNonQuery();
                if (registrosAfectados == 0)
                {
                    throw new Exception("No se editaron registros");
                }
                else
                {
                    cadenaComando = "select RowVersion from Vehiculos where VehiculoId=@id";
                    comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", vehiculo.VehiculoId);
                    vehiculo.RowVersion = (byte[])comando.ExecuteScalar();
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Vehiculo GetVehiculoPorId(object obj)
        {
            Vehiculo vehiculo = null;
            try
            {
                var cadenaComando = "select VehiculoId, Patente, TipoVehiculoId, RowVersion from Vehiculos where VehiculoId=@id";
                using (var comando = new SqlCommand(cadenaComando, cn))
                {
                    if (obj is Ingreso)
                    {
                        comando.Parameters.AddWithValue("@id", ((Ingreso)obj).VehiculoId);
                    }
                    else
                    comando.Parameters.AddWithValue("@id", obj);

                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            vehiculo = ConstruirVehiculo(reader);
                        }
                    }
                }
                return vehiculo;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool Existe(Vehiculo vehiculo)
        {
            try
            {
                var cadenaComando = "select count(*) from Vehiculos where patente = @patente";
                if (vehiculo.VehiculoId != 0)
                {
                    cadenaComando += " and VehiculoId<>@vehiculoId";
                }
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@patente", vehiculo.Patente);
                if (vehiculo.VehiculoId != 0)
                {
                    comando.Parameters.AddWithValue("@vehiculoId", vehiculo.VehiculoId);
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
