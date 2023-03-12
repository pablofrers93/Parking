using PARKING.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARKING.Datos.REPOSITORIOS
{
    public class LugaresRepositorio
    {
        private SqlConnection cn;

        public LugaresRepositorio(SqlConnection cn)
        {
            this.cn = cn;
        }

        public List<Lugar> GetLista()
        {
            List<Lugar> lista = new List<Lugar>();
            try
            {
                var cadenaComando =
                    "select LugarId, Numero, PlantaId, RowVersion from Lugares order by Numero";
                var comando = new SqlCommand(cadenaComando, cn);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Lugar lugar = ConstruirLugar(reader);
                        lista.Add(lugar);
                    }
                }
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private Lugar ConstruirLugar(SqlDataReader reader)
        {
            return new Lugar()
            {
                LugarId = reader.GetInt32(0),
                Numero = reader.GetInt32(1),
                PlantaId = reader.GetInt32(2),
                RowVersion = (byte[])reader[3]
            };
        }

        public List<Lugar> GetLista(Planta planta)
        {
            List<Lugar> lista = new List<Lugar>();
            try
            {
                StringBuilder sb =
                    new StringBuilder("SELECT LugarId, Numero, PlantaId, RowVersion FROM Lugares ");
                if (planta != null)
                {
                sb.Append("WHERE PlantaId=@planta ORDER BY Numero");
                }
                else
                {
                    sb.Append(" ORDER BY Numero");
                }

                var cadenaComando = sb.ToString();
                var comando = new SqlCommand(cadenaComando, cn);
                if (planta != null)
                {

                    comando.Parameters.AddWithValue("@planta", planta.PlantaId);
                }
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Lugar lugar = ConstruirLugar(reader);
                        lista.Add(lugar);
                    }
                }
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<Lugar> GetListaLugaresDisponibles(Planta planta)
        {
            List<Lugar> lista = new List<Lugar>();
            try
            {
                StringBuilder sb =
                    new StringBuilder("select * from lugares where LugarId in (select LugarId from Lugares where LugarId not in (select LugarId from Ingresos) union select LugarId from ingresos I inner join Egresos E on I.IngresoID = E.IngresoID )  ");
                if (planta != null)
                {
                    sb.Append(" and PlantaId=@planta ");
                }

                var cadenaComando = sb.ToString();
                var comando = new SqlCommand(cadenaComando, cn);
                if (planta != null)
                {

                    comando.Parameters.AddWithValue("@planta", planta.PlantaId);
                }
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Lugar lugar = ConstruirLugar(reader);
                        lista.Add(lugar);
                    }
                }
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Agregar(Lugar lugar)
        {
            int registrosAfectados = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into Lugares (Numero, PlantaId, ");
                sb.Append(" values (@num, @plantaId)");

                var cadenaComando = sb.ToString();
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@num", lugar.Numero);
                comando.Parameters.AddWithValue("@plantaId", lugar.PlantaId);

                registrosAfectados = comando.ExecuteNonQuery();
                if (registrosAfectados == 0)
                {
                    throw new Exception("No se agregaron registros");
                }
                else
                {
                    cadenaComando = "select @@identity";
                    comando = new SqlCommand(cadenaComando, cn);
                    lugar.LugarId = (int)(decimal)comando.ExecuteScalar();

                    cadenaComando = "select RowVersion from Lugares where LugarId=@id";
                    comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", lugar.LugarId);
                    lugar.RowVersion = (byte[])comando.ExecuteScalar();
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Borrar(Lugar lugar)
        {
            int registrosAfectados = 0;
            try
            {
                var cadenaComando = "delete from Lugares where LugarId=@id and RowVersion=@r";
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@id", lugar.LugarId);
                comando.Parameters.AddWithValue("@r", lugar.RowVersion);
                registrosAfectados = comando.ExecuteNonQuery();

                return registrosAfectados;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Editar(Lugar lugar)
        {
            int registrosAfectados = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("update Lugares set Numero=@num, PlantaId=@plantaId ");
                sb.Append(" where LugarId=@id");

                var cadenaComando = sb.ToString();
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@num", lugar.Numero);
                comando.Parameters.AddWithValue("@plantaId", lugar.PlantaId);
                comando.Parameters.AddWithValue("@id", lugar.LugarId);
                registrosAfectados = comando.ExecuteNonQuery();
                if (registrosAfectados == 0)
                {
                    throw new Exception("No se editaron registros");
                }
                else
                {
                    cadenaComando = "select RowVersion from Lugares where LugarId=@id";
                    comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", lugar.LugarId);
                    lugar.RowVersion = (byte[])comando.ExecuteScalar();
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Lugar GetLugarPorId(int id)
        {
            Lugar lugar = null;
            try
            {
                var cadenaComando = "select LugarId, Numero, PlantaId, RowVersion from Lugares where LugarId=@id";
                using (var comando = new SqlCommand(cadenaComando, cn))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            lugar = ConstruirLugar(reader);
                        }
                    }
                }
                return lugar;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool Existe(Lugar lugar)
        {
            try
            {
                var cadenaComando = "select count(*) from Lugares where Numero = @num and PlantaId = plantaId";
                if (lugar.LugarId != 0)
                {
                    cadenaComando += " and LugarId<>@lugarId";
                }
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@num", lugar.Numero);
                comando.Parameters.AddWithValue("@plantaId", lugar.PlantaId);
                if (lugar.LugarId != 0)
                {
                    comando.Parameters.AddWithValue("@lugarId", lugar.LugarId);
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
