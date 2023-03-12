using PARKING.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARKING.Datos.REPOSITORIOS
{
    public class PlantasRepositorio
    {
        private SqlConnection cn;

        public PlantasRepositorio(SqlConnection cn)
        {
            this.cn = cn;
        }

        public List<Planta> GetLista()
        {
            List<Planta> lista = new List<Planta>();
            try
            {
                var cadenaComando =
                    "select PlantaId, NombrePlanta, CantidadLugares, LugaresDisponibles, Rowversion from Plantas order by PlantaId";
                var comando = new SqlCommand(cadenaComando, cn);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Planta planta = ConstruirPlanta(reader);
                        lista.Add(planta);
                    }
                }
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private Planta ConstruirPlanta(SqlDataReader reader)
        {
            return new Planta()
            {
                PlantaId = reader.GetInt32(0),
                NombrePlanta = reader.GetString(1),
                CantidadLugares = reader.GetInt32(2),
                LugaresDisponibles = reader.GetInt32(3),
                RowVersion = (byte[])reader[4]
            };
        }   
        public int Agregar(Planta planta)
        {
            int registrosAfectados = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into Plantas (NombrePlanta, ");
                sb.Append(" values (@nombrePlanta)");

                var cadenaComando = sb.ToString();
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@nombrePlanta", planta.NombrePlanta);

                registrosAfectados = comando.ExecuteNonQuery();
                if (registrosAfectados == 0)
                {
                    throw new Exception("No se agregaron registros");
                }
                else
                {
                    cadenaComando = "select @@identity";
                    comando = new SqlCommand(cadenaComando, cn);
                    planta.PlantaId = (int)(decimal)comando.ExecuteScalar();

                    cadenaComando = "select RowVersion from Plantas where PlantaId=@id";
                    comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", planta.PlantaId);
                    planta.RowVersion = (byte[])comando.ExecuteScalar();
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Borrar(Planta planta)
        {
            int registrosAfectados = 0;
            try
            {
                var cadenaComando = "delete from Plantas where PlantaId=@id and RowVersion=@r";
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@id", planta.PlantaId);
                comando.Parameters.AddWithValue("@r", planta.RowVersion);
                registrosAfectados = comando.ExecuteNonQuery();

                return registrosAfectados;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Editar(Planta planta)
        {
            int registrosAfectados = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("update Plantas set NombrePlanta=@nombrePlanta ");
                sb.Append(" where PlantaId=@id");

                var cadenaComando = sb.ToString();
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@nombrePlanta", planta.NombrePlanta);
                registrosAfectados = comando.ExecuteNonQuery();
                if (registrosAfectados == 0)
                {
                    throw new Exception("No se editaron registros");
                }
                else
                {
                    cadenaComando = "select RowVersion from Plantas where PlantaId=@id";
                    comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", planta.PlantaId);
                    planta.RowVersion = (byte[])comando.ExecuteScalar();
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Planta GetPlantaPorId(int id)
        {
            Planta planta = null;
            try
            {
                var cadenaComando = "select PlantaId, NombrePlanta, CantidadLugares, LugaresDisponibles, RowVersion from Plantas where PlantaId=@id";
                using (var comando = new SqlCommand(cadenaComando, cn))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            planta = ConstruirPlanta(reader);
                        }
                    }
                }
                return planta;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool Existe(Planta planta)
        {
            try
            {
                var cadenaComando = "select count(*) from Plantas where NombrePlanta = @nombrePlantas";
                if (planta.PlantaId != 0)
                {
                    cadenaComando += " and PlantaId<>@plantaId";
                }
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@nombrePlanta", planta.NombrePlanta);
                if (planta.PlantaId != 0)
                {
                    comando.Parameters.AddWithValue("@plantaId", planta.PlantaId);
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
