using PARKING.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARKING.Datos.REPOSITORIOS
{
    public class TipoDeTarifasRepositorio
    {
        private SqlConnection cn;

        public TipoDeTarifasRepositorio(SqlConnection cn)
        {
            this.cn = cn;
        }

        public List<TipoDeTarifa> GetLista()
        {
            List<TipoDeTarifa> lista = new List<TipoDeTarifa>();
            try
            {
                var cadenaComando =
                    "select TipoTarifaID, TipoTarifa, RowVersion from TipoDeTarifa ";
                var comando = new SqlCommand(cadenaComando, cn);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TipoDeTarifa tipoDeTarifa = ConstruirTipoDeTarifa(reader);
                        lista.Add(tipoDeTarifa);
                    }
                }
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public TipoDeTarifa GetTipoTarifaPorId(int tipoTarifaId)
        {
            TipoDeTarifa tipoDeTarifa = null;
            try
            {
                var cadenaComando = "select TipoTarifaId, TipoTarifa, RowVersion from TipoDeTarifa where TipoTarifaId=@id";
                using (var comando = new SqlCommand(cadenaComando, cn))
                {
                    comando.Parameters.AddWithValue("@id", tipoTarifaId);
                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            tipoDeTarifa = ConstruirTipoDeTarifa(reader);
                        }
                    }
                }
                return tipoDeTarifa;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private TipoDeTarifa ConstruirTipoDeTarifa(SqlDataReader reader)
        {
            return new TipoDeTarifa()
            {
                TipoTarifa = reader.GetString(0),
                RowVersion = (byte[])reader[1]
            };
        }
        public int Agregar(TipoDeTarifa tipoDeTarifa)
        {
            int registrosAfectados = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into TipoDeTarifa (TipoTarifa) ");
                sb.Append(" values (@tipoTarifa)");

                var cadenaComando = sb.ToString();
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@tipoTarifa", tipoDeTarifa.TipoTarifa);

                registrosAfectados = comando.ExecuteNonQuery();
                if (registrosAfectados == 0)
                {
                    throw new Exception("No se agregaron registros");
                }
                else
                {
                    cadenaComando = "select @@identity";
                    comando = new SqlCommand(cadenaComando, cn);
                    tipoDeTarifa.TipoTarifaId = (int)(decimal)comando.ExecuteScalar();

                    cadenaComando = "select RowVersion from TipoDeTarifa where TipoTarifaId=@id";
                    comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", tipoDeTarifa.TipoTarifaId);
                    tipoDeTarifa.RowVersion = (byte[])comando.ExecuteScalar();
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Borrar(TipoDeTarifa tipoDeTarifa)
        {
            int registrosAfectados = 0;
            try
            {
                var cadenaComando = "delete from TipoDeTarifa where TipoTarifaId=@id and RowVersion=@r";
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@id", tipoDeTarifa.TipoTarifaId);
                comando.Parameters.AddWithValue("@r", tipoDeTarifa.RowVersion);
                registrosAfectados = comando.ExecuteNonQuery();

                return registrosAfectados;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Editar(TipoDeTarifa tipoDeTarifa)
        {
            int registrosAfectados = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("update TipoDeTarifa set TipoTarifa=@tipoTarifa ");
                sb.Append(" where TipoTarifaId=@id");

                var cadenaComando = sb.ToString();
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@tipoTarifa", tipoDeTarifa.TipoTarifa);
                comando.Parameters.AddWithValue("@id", tipoDeTarifa.TipoTarifaId);
                registrosAfectados = comando.ExecuteNonQuery();
                if (registrosAfectados == 0)
                {
                    throw new Exception("No se editaron registros");
                }
                else
                {
                    cadenaComando = "select RowVersion from TipoDeTarifa where TipoTarifaId=@id";
                    comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", tipoDeTarifa.TipoTarifaId);
                    tipoDeTarifa.RowVersion = (byte[])comando.ExecuteScalar();
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetTipoDeTarifaIdPorVehiculoId(object obj)
        {
            TipoDeTarifa tipoDeTarifa = null;
            try
            {
                var cadenaComando = "select * from TipoDeTarifa where TipoTarifaID = @tipoTarifaId ";
                using (var comando = new SqlCommand(cadenaComando, cn))
                {
                    if (obj is TipoDeTarifa)
                    {
                        comando.Parameters.AddWithValue("@tipoTarifaId", ((TipoDeTarifa)obj).TipoTarifaId);
                            using (var reader = comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                tipoDeTarifa = ConstruirTipoDeTarifa(reader);
                            }
                        }
                    }
                }
                return tipoDeTarifa;

            }
            catch (Exception e)
            {
                throw e;
            }
            
        }


        public TipoDeTarifa GetTipoDeTarifaPorId(object obj)
        {
            TipoDeTarifa tipoDeTarifa = null;
            try
            {
                var cadenaComando = "select TipoTarifa, RowVersion from TipoDeTarifa where TipoTarifaID=@id";
                using (var comando = new SqlCommand(cadenaComando, cn))
                {
                    comando.Parameters.AddWithValue("@id", ((TipoDeTarifa)obj).TipoTarifaId);
                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            tipoDeTarifa = ConstruirTipoDeTarifa(reader);
                        }
                    }
                }
                return tipoDeTarifa;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool Existe(TipoDeTarifa tipoDeTarifa)
        {
            try
            {
                var cadenaComando = "select count(*) from TipoDeTarifa where TipoTarifa = tipoTarifa";
                if (tipoDeTarifa.TipoTarifaId != 0)
                {
                    cadenaComando += " and TipoTarifaID<>@tipoTarifaID";
                }
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@tipoTarifa", tipoDeTarifa.TipoTarifa);
                if (tipoDeTarifa.TipoTarifaId != 0)
                {
                    comando.Parameters.AddWithValue("@TarifaId", tipoDeTarifa.TipoTarifaId);
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
