using PARKING.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARKING.Datos.REPOSITORIOS
{
    public class EgresosRepositorio
    {
        private SqlConnection cn;

        public EgresosRepositorio(SqlConnection cn)
        {
            this.cn = cn;
        }

        public List<Egreso> GetLista()
        {
            List<Egreso> lista = new List<Egreso>();
            try
            {
                var cadenaComando =
                    "select EgresoId, IngresoID, FechaEgreso, ImporteAbonado, RowVersion from Egresos order by FechaEgreso";
                var comando = new SqlCommand(cadenaComando, cn);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Egreso egreso = ConstruirEgreso(reader);
                        lista.Add(egreso);
                    }
                }
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private Egreso ConstruirEgreso(SqlDataReader reader)
        {
            return new Egreso()
            {
                EgresoId = reader.GetInt32(0),
                IngresoId = reader.GetInt32(1),
                FechaEgreso = reader.GetDateTime(2),
                ImporteAbonado = reader.GetInt32(3),
                RowVersion = (byte[])reader[4]
            };
        }
        public int Agregar(Egreso egreso)
        {
            int registrosAfectados = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into Egresos (IngresoId, FechaEgreso, ImporteAbonado) ");
                sb.Append(" values (@ingresoId, @fechaEgreso, @importeAbonado)");

                var cadenaComando = sb.ToString();
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@ingresoId", egreso.IngresoId);
                comando.Parameters.AddWithValue("@fechaEgreso", egreso.FechaEgreso);
                comando.Parameters.AddWithValue("@importeAbonado", egreso.ImporteAbonado);

                

                registrosAfectados = comando.ExecuteNonQuery();
                if (registrosAfectados == 0)
                {
                    throw new Exception("No se agregaron registros");
                }
                else
                {
                    cadenaComando = "select @@identity";
                    comando = new SqlCommand(cadenaComando, cn);
                    egreso.EgresoId = (int)(decimal)comando.ExecuteScalar();

                    cadenaComando = "select RowVersion from Egresos where EgresoId=@id";
                    comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", egreso.EgresoId);
                    egreso.RowVersion = (byte[])comando.ExecuteScalar();
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public object GetEgresoPorVehiculoId(object obj)
        //{
        //    Egreso egreso = null;
        //    try
        //    {
        //        var cadenaComando = "select * from egresos inner join ingresos on egresos.IngresoID=Ingresos.IngresoID where vehiculoID = @vehiculoId ";
        //        using (var comando = new SqlCommand(cadenaComando, cn))
        //        {
        //            if (obj is Ingreso)
        //            {
        //                comando.Parameters.AddWithValue("@vehiculoId", ((Egreso)obj).IngresoId.
        //                using (var reader = comando.ExecuteReader())
        //                {
        //                    if (reader.HasRows)
        //                    {
        //                        reader.Read();
        //                        egreso = ConstruirEgreso(reader);
        //                    }
        //                }
        //            }
        //        }
        //        return egreso;
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        

        public bool ExisteVehiculo(Ingreso ingreso)
        {
            try
            {
                var cadenaComando = "select COUNT(*) from ingresos full join Egresos on ingresos.IngresoID=Egresos.IngresoID inner join Vehiculos on Vehiculos.VehiculoId = Ingresos.VehiculoId where Patente = '@patente'  ";
                //if (ingreso.Vehiculo.Patente != "")
                //{
                //    cadenaComando += " and IngresoId<>@ingresoId";
                //}
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@patente", ingreso.Vehiculo.Patente);
                //if (ingreso.IngresoId != 0)
                //{
                //    comando.Parameters.AddWithValue("@egresoId", ingreso.IngresoId);
                //}
                return (int)comando.ExecuteScalar() > 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int Borrar(Egreso egreso)
        {
            int registrosAfectados = 0;
            try
            {
                var cadenaComando = "delete from Egresos where EgresoId=@id and RowVersion=@r";
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@id", egreso.EgresoId);
                comando.Parameters.AddWithValue("@r", egreso.RowVersion);
                registrosAfectados = comando.ExecuteNonQuery();

                return registrosAfectados;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Editar(Egreso egreso)
        {
            int registrosAfectados = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("update Egresos set IngresoId=@ingresoId, FechaEgreso=@fechaEgreso, ImporteAbonado=@importeAbonado ");
                sb.Append(" where EgresoId=@id");

                var cadenaComando = sb.ToString();
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@ingresoId", egreso.IngresoId);
                comando.Parameters.AddWithValue("@fechaEgreso", egreso.FechaEgreso);
                comando.Parameters.AddWithValue("@importeAbonado", egreso.ImporteAbonado);

                comando.Parameters.AddWithValue("@id", egreso.EgresoId);
                registrosAfectados = comando.ExecuteNonQuery();
                if (registrosAfectados == 0)
                {
                    throw new Exception("No se editaron registros");
                }
                else
                {
                    cadenaComando = "select RowVersion from Egresos where EgresoId=@id";
                    comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", egreso.EgresoId);
                    egreso.RowVersion = (byte[])comando.ExecuteScalar();
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Egreso GetEgresoPorId(int id)
        {
            Egreso egreso = null;
            try
            {
                var cadenaComando = "select EgresoId, IngresoId, FechaEgreso, ImporteAbonado, RowVersion from Egresos where EgresoId=@id";
                using (var comando = new SqlCommand(cadenaComando, cn))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            egreso = ConstruirEgreso(reader);
                        }
                    }
                }
                return egreso;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool Existe(Egreso egreso)
        {
            try
            {
                var cadenaComando = "select count(*) from Egresos where IngresoId = @ingresoId ";
                if (egreso.EgresoId != 0)
                {
                    cadenaComando += " and EgresoId<>@egresoId";
                }
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@ingresoId", egreso.IngresoId);
                if (egreso.EgresoId != 0)
                {
                    comando.Parameters.AddWithValue("@egresoId", egreso.EgresoId);
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
