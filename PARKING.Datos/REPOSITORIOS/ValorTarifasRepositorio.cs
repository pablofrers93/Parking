using PARKING.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARKING.Datos.REPOSITORIOS
{
    public class ValorTarifasRepositorio
    {
        private SqlConnection cn;

        public ValorTarifasRepositorio(SqlConnection cn)
        {
            this.cn = cn;
        }

        public List<ValorTarifa> GetLista()
        {
            List<ValorTarifa> lista = new List<ValorTarifa>();
            try
            {
                var cadenaComando =
                    "select TarifaId, TipoVehiculoId, FechaDesde, FechaHasta, Valor, TipoTarifaI,  RowVersion from ValorTarifa ";
                var comando = new SqlCommand(cadenaComando, cn);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ValorTarifa valorTarifa = ConstruirValorTarifa(reader);
                        lista.Add(valorTarifa);
                    }
                }
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private ValorTarifa ConstruirValorTarifa(SqlDataReader reader)
        {
            return new ValorTarifa()
            {
                TarifaId = reader.GetInt32(0),
                TipoVehiculoId = reader.GetInt32(1),
                FechaDesde = reader.GetDateTime(2),
                FechaHasta = reader.GetDateTime(3),
                Valor = reader.GetInt32(4),
                TipoTarifaId = reader.GetInt32(5),
                RowVersion = (byte[])reader[6]
            };
        }
        public int Agregar(ValorTarifa valorTarifa)
        {
            int registrosAfectados = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into ValorTarifa (TipoVehiculoId, FechaDesde, FechaHasta, Valor, TipoTarifaId ");
                sb.Append(" values (@tipoVehiculoId, @fechaDesde, @fechaHasta, @valor, @tipoTarifaId)");

                var cadenaComando = sb.ToString();
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@tipoVehiculoId", valorTarifa.TipoVehiculoId);
                comando.Parameters.AddWithValue("@fechaDesde", valorTarifa.FechaDesde);
                comando.Parameters.AddWithValue("@fechaHasta", valorTarifa.FechaHasta);
                comando.Parameters.AddWithValue("@valor", valorTarifa.Valor);
                comando.Parameters.AddWithValue("@tipoTarifaId", valorTarifa.TipoTarifaId);

                registrosAfectados = comando.ExecuteNonQuery();
                if (registrosAfectados == 0)
                {
                    throw new Exception("No se agregaron registros");
                }
                else
                {
                    cadenaComando = "select @@identity";
                    comando = new SqlCommand(cadenaComando, cn);
                    valorTarifa.TarifaId = (int)(decimal)comando.ExecuteScalar();

                    cadenaComando = "select RowVersion from ValorTarifa where TarifaId=@id";
                    comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", valorTarifa.TarifaId);
                    valorTarifa.RowVersion = (byte[])comando.ExecuteScalar();
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Borrar(ValorTarifa valorTarifa)
        {
            int registrosAfectados = 0;
            try
            {
                var cadenaComando = "delete from ValorTarifa where TarifaId=@id and RowVersion=@r";
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@id", valorTarifa.TarifaId);
                comando.Parameters.AddWithValue("@r", valorTarifa.RowVersion);
                registrosAfectados = comando.ExecuteNonQuery();

                return registrosAfectados;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Editar(ValorTarifa valorTarifa)
        {
            int registrosAfectados = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("update ValorTarifa set TipoVehiculoId=@tipoVehiculoId, FechaDesde=@fechaDesde, FechaHasta=@fechaHasta, Valor=@valor, TipoTarifaId=@tipoTarifaId ");
                sb.Append(" where TarifaId=@id");

                var cadenaComando = sb.ToString();
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@tipoVehiculoId", valorTarifa.TipoVehiculoId);
                comando.Parameters.AddWithValue("@fechaDesde", valorTarifa.FechaDesde);
                comando.Parameters.AddWithValue("@fechaHasta", valorTarifa.FechaHasta);
                comando.Parameters.AddWithValue("@valor", valorTarifa.Valor);
                comando.Parameters.AddWithValue("@tipoTarifaId", valorTarifa.TipoTarifaId);
                //if (string.IsNullOrEmpty(valorTarifa.Valor))
                //{
                //    comando.Parameters.AddWithValue("@tel", DBNull.Value);
                //}
                comando.Parameters.AddWithValue("@id", valorTarifa.TarifaId);
                registrosAfectados = comando.ExecuteNonQuery();
                if (registrosAfectados == 0)
                {
                    throw new Exception("No se editaron registros");
                }
                else
                {
                    cadenaComando = "select RowVersion from ValorTarifa where TarifaId=@id";
                    comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", valorTarifa.TarifaId);
                    valorTarifa.RowVersion = (byte[])comando.ExecuteScalar();
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ValorTarifa GetValorTarifaPorId(int id)
        {
            ValorTarifa valorTarifa = null;
            try
            {
                var cadenaComando = "select ValorTarifaId, TipoVehiculoId, FechaDesde, FechaHasta, Valor, TipoTarifaId, RowVersion from ValorTarifa where TarifaId=@id";
                using (var comando = new SqlCommand(cadenaComando, cn))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            valorTarifa = ConstruirValorTarifa(reader);
                        }
                    }
                }
                return valorTarifa;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool Existe(ValorTarifa valorTarifa)
        {
            try
            {
                var cadenaComando = "select count(*) from ValorTarifa where TipoVehiculoId = @tipoVehiculoId and TipoTarifaId = tipoTarifaId" ;
                if (valorTarifa.TarifaId != 0)
                {
                    cadenaComando += " and TarifaId<>@TarifaId";
                }
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@tipoVehiculoId", valorTarifa.TipoVehiculoId);
                comando.Parameters.AddWithValue("@tipoTarifaId", valorTarifa.TipoTarifaId);
                if (valorTarifa.TarifaId != 0)
                {
                    comando.Parameters.AddWithValue("@TarifaId", valorTarifa.TarifaId);
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
