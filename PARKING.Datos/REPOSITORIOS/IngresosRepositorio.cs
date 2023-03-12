using PARKING.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARKING.Datos.REPOSITORIOS
{
    public class IngresosRepositorio
    {
        private SqlConnection cn;

        public IngresosRepositorio(SqlConnection cn)
        {
            this.cn = cn;
        }

        public List<Ingreso> GetLista()
        {
            List<Ingreso> lista = new List<Ingreso>();
            try
            {
                var cadenaComando =
                    "select IngresoId, VehiculoId, FechaIngreso, AbonoVigente, LugarId, RowVersion from Ingresos order by FechaIngreso";
                var comando = new SqlCommand (cadenaComando, cn);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ingreso ingreso = ConstruirIngreso(reader);
                        lista.Add(ingreso);
                    }
                }
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //public List<Ingreso> GetListaPorVehiculo(Vehiculo vehiculo)
        //{
        //    List<Ingreso> lista = new List<Ingreso>();
        //    try
        //    {
        //        var cadenaComando =
        //            "select * from ingresos where VehiculoID in (select VehiculoId from Vehiculos where Patente = @patente) ";
        //        var comando = new SqlCommand(cadenaComando, cn);
        //        comando.Parameters.AddWithValue("@patente", patente);
        //        using (var reader = comando.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                Ingreso ingreso = ConstruirIngreso(reader);
        //                lista.Add(ingreso);
        //            }
        //        }
        //        return lista;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}
        private Ingreso ConstruirIngreso(SqlDataReader reader)
        {
            return new Ingreso()
            {
                IngresoId = reader.GetInt32(0),
                VehiculoId = reader.GetInt32(1),
                FechaIngreso = reader.GetDateTime(2),
                AbonoVigente = reader.GetBoolean(3),
                LugarId = reader.GetInt32(4),
                RowVersion = (byte[])reader[5],
            };
        }
        public int Agregar(Ingreso ingreso)
        {
            int registrosAfectados = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into Ingresos (VehiculoId, FechaIngreso, AbonoVigente, LugarId) ");
                sb.Append(" values (@vehiculoId, @fechaIng, @abonoVig, @lugarId)");

                var cadenaComando = sb.ToString();
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@vehiculoId", ingreso.VehiculoId);
                comando.Parameters.AddWithValue("@fechaIng", ingreso.FechaIngreso);
                comando.Parameters.AddWithValue("@abonoVig", ingreso.AbonoVigente);
                comando.Parameters.AddWithValue("@lugarId", ingreso.LugarId);

                registrosAfectados = comando.ExecuteNonQuery();
                if (registrosAfectados==0)
                {
                    throw new Exception("No se agregaron registros");
                }
                else
                {
                    cadenaComando = "select @@identity";
                    comando = new SqlCommand(cadenaComando, cn);
                    ingreso.IngresoId = (int)(decimal)comando.ExecuteScalar();

                    cadenaComando = "select RowVersion from Ingresos where IngresoId=@id";
                    comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", ingreso.IngresoId);
                    ingreso.RowVersion = (byte[])comando.ExecuteScalar();
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Borrar(Ingreso ingreso)
        {
            int registrosAfectados = 0;
            try
            {
                var cadenaComando = "delete from Ingresos where IngresoId=@id and RowVersion=@r";
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@id", ingreso.IngresoId);
                comando.Parameters.AddWithValue("@r", ingreso.RowVersion);
                registrosAfectados = comando.ExecuteNonQuery();

                return registrosAfectados;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Editar (Ingreso ingreso)
        {
            int registrosAfectados = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("update Ingresos set VehiculoId=@vehiculoId, FechaIngreso=@fechaIng, AbonoVigente=@abonoVig, LugarId=@lugarId ");
                sb.Append(" where IngresoId=@id");

                var cadenaComando = sb.ToString();
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@vehiculoId", ingreso.VehiculoId);
                comando.Parameters.AddWithValue("@fechaIng", ingreso.FechaIngreso);
                comando.Parameters.AddWithValue("@abonoVig", ingreso.AbonoVigente);
                comando.Parameters.AddWithValue("@lugarId", ingreso.LugarId);
                
                comando.Parameters.AddWithValue("@id", ingreso.IngresoId);
                registrosAfectados = comando.ExecuteNonQuery();
                if (registrosAfectados == 0)
                {
                    throw new Exception("No se editaron registros");
                }
                else
                {
                    cadenaComando = "select RowVersion from Ingresos where IngresoId=@id";
                    comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", ingreso.IngresoId);
                    ingreso.RowVersion = (byte[])comando.ExecuteScalar(); 
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Ingreso GetIngresoPorId(int id)
        {
            Ingreso ingreso = null;
            try
            {
                var cadenaComando = "select IngresoId, VehiculoId, FechaIngreso, AbonoVigente, LugarId, RowVersion from Ingresos where IngresoId=@id";
                using (var comando = new SqlCommand(cadenaComando, cn))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            ingreso = ConstruirIngreso(reader);
                        }
                    }
                }
                return ingreso;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Ingreso GetIngresoPorVehiculoId(Object obj)
        {
            Ingreso ingreso = null;
            try
            {
                var cadenaComando = "select * from ingresos where VehiculoId = @vehiculoId ";
                using (var comando = new SqlCommand(cadenaComando, cn))
                {
                    if (obj is Ingreso)
                    {
                        comando.Parameters.AddWithValue("@vehiculoId", ((Ingreso)obj).VehiculoId);
                        using (var reader = comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                ingreso = ConstruirIngreso(reader);
                            }
                        }
                    }
                }
                return ingreso;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool Existe(Ingreso ingreso)
        {
            try
            {
                var cadenaComando = "select count(*) from Ingresos where VehiculoId = @vehiculoId";
                if (ingreso.IngresoId != 0)
                {
                    cadenaComando += " and IngresoId<>@ingresoId";
                }
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@vehiculoId", ingreso.VehiculoId);
                if (ingreso.IngresoId != 0)
                {
                    comando.Parameters.AddWithValue("@ingresoId", ingreso.IngresoId);
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
