using PARKING.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARKING.Datos.REPOSITORIOS
{
    public class TipoVehiculosRepositorio
    {
        private SqlConnection cn;

        public TipoVehiculosRepositorio(SqlConnection cn)
        {
            this.cn = cn;
        }

        public List<TipoVehiculo> GetLista()
        {
            List<TipoVehiculo> lista = new List<TipoVehiculo>();
            try
            {
                var cadenaComando = "select TipoID, TipoVehiculo , RowVersion from TipoVehiculo order by TipoVehiculo";
                var comando = new SqlCommand(cadenaComando, cn);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TipoVehiculo tipoVehiculo = ConstruirTipoVehiculo(reader);
                        lista.Add(tipoVehiculo);
                    }
                }
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private TipoVehiculo ConstruirTipoVehiculo(SqlDataReader reader)
        {
            return new TipoVehiculo()
            {
                TipoId = reader.GetInt32(0),
                NombreTipoVehiculo = reader.GetString(1),
                RowVersion = (byte[])reader[2]
            };
        }
        public int Agregar(TipoVehiculo tipoVehiculo)
        {
            int registrosAfectados = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into TipoVehiculo (TipoVehiculo)");
                sb.Append(" values (@tipoVehiculo)");

                var cadenaComando = sb.ToString();
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@tipoVehiculo", tipoVehiculo.NombreTipoVehiculo);

                registrosAfectados = comando.ExecuteNonQuery();
                if (registrosAfectados == 0)
                {
                    throw new Exception("No se agregaron registros");
                }
                else
                {
                    cadenaComando = "select @@identity";
                    comando = new SqlCommand(cadenaComando, cn);
                    tipoVehiculo.TipoId = (int)(decimal)comando.ExecuteScalar();

                    cadenaComando = "select RowVersion from TipoVehiculo where TipoId=@id";
                    comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", tipoVehiculo.TipoId);
                    tipoVehiculo.RowVersion = (byte[])comando.ExecuteScalar();
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Borrar(TipoVehiculo tipoVehiculo)
        {
            int registrosAfectados = 0;
            try
            {
                var cadenaComando = "delete from TipoVehiculo where TipoId=@id and RowVersion=@r";
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@id", tipoVehiculo.TipoId);
                comando.Parameters.AddWithValue("@r", tipoVehiculo.RowVersion);
                registrosAfectados = comando.ExecuteNonQuery();

                return registrosAfectados;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Editar(TipoVehiculo tipoVehiculo)
        {
            int registrosAfectados = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("update TipoVehiculo set TipoVehiculo=@tipoVehiculo ");
                sb.Append(" where TipoId=@id");

                var cadenaComando = sb.ToString();
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@tipoVehiculo", tipoVehiculo.NombreTipoVehiculo);

                comando.Parameters.AddWithValue("@id", tipoVehiculo.TipoId);
                registrosAfectados = comando.ExecuteNonQuery();
                if (registrosAfectados == 0)
                {
                    throw new Exception("No se editaron registros");
                }
                else
                {
                    cadenaComando = "select RowVersion from TipoVehiculo where TipoId=@id";
                    comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", tipoVehiculo.TipoId);
                    tipoVehiculo.RowVersion = (byte[])comando.ExecuteScalar();
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TipoVehiculo GetTipoVehiculoPorId(int id)
        {
            TipoVehiculo tipoVehiculo = null;
            try
            {
                var cadenaComando = "select TipoId, TipoVehiculo, RowVersion from TipoVehiculo where TipoId=@id";
                using (var comando = new SqlCommand(cadenaComando, cn))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            tipoVehiculo = ConstruirTipoVehiculo(reader);
                        }
                    }
                }
                return tipoVehiculo;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool Existe(TipoVehiculo tipoVehiculo)
        {
            try
            {
                var cadenaComando = "select count(*) from TipoVehiculo where TipoVehiculo = @tipoVehiculo";
                if (tipoVehiculo.TipoId != 0)
                {
                    cadenaComando += " and TipoId<>@tipoId";
                }
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@tipoVehiculo", tipoVehiculo.NombreTipoVehiculo);
                if (tipoVehiculo.TipoId != 0)
                {
                    comando.Parameters.AddWithValue("@tipoId", tipoVehiculo.TipoId);
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
