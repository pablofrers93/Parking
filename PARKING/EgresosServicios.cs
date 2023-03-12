using PARKING.Datos;
using PARKING.Datos.REPOSITORIOS;
using PARKING.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARKING
{
    public class EgresosServicios
    {
        private EgresosRepositorio repositorio;
        private LugaresRepositorio repoLugares;
        private IngresosRepositorio repoIngresos;
        private VehiculosRepositorio repoVehiculos;
        private PlantasRepositorio repoPlantas;

        public EgresosServicios() { }

        public List<Egreso> GetLista()
        {
            try
            {
                List<Egreso> lista = null;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new EgresosRepositorio(cn);
                    repoIngresos = new IngresosRepositorio(cn);
                    repoLugares = new LugaresRepositorio(cn);
                    repoVehiculos = new VehiculosRepositorio(cn);
                    repoPlantas = new PlantasRepositorio(cn);
                    lista = repositorio.GetLista();
                    foreach (var egreso in lista)
                    {
                        egreso.Lugar = repoLugares.GetLugarPorId(repoIngresos.GetIngresoPorId(egreso.IngresoId).LugarId);
                        egreso.Vehiculo = repoVehiculos.GetVehiculoPorId(repoIngresos.GetIngresoPorId(egreso.IngresoId).VehiculoId);
                        egreso.FechaIngreso = repoIngresos.GetIngresoPorId(egreso.IngresoId).FechaIngreso;
                        egreso.Lugar.Planta = repoPlantas.GetPlantaPorId(egreso.Lugar.PlantaId);
                    }

                    return lista;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool ExisteVehiculo(Ingreso ingreso)
        {
            try
            {
                bool existe = true;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new EgresosRepositorio(cn);
                    existe = repositorio.ExisteVehiculo(ingreso);
                }

                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Egreso egreso)
        {
            try
            {
                bool existe = true;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new EgresosRepositorio(cn);
                    existe = repositorio.Existe(egreso);
                }

                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //public object GetEgresoPorVehiculoId(object obj)
        //{
        //    try
        //    {
        //        using (var cn = ConexionBD.GetInstancia().AbrirConexion())
        //        {
        //            repositorio = new EgresosRepositorio(cn);
        //            return repositorio.GetEgresoPorVehiculoId(obj);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        public int Agregar(Egreso egreso)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new EgresosRepositorio(cn);
                    registros = repositorio.Agregar(egreso);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Borrar(Egreso egreso)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new EgresosRepositorio(cn);
                    registros = repositorio.Borrar(egreso);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Editar(Egreso egreso)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new EgresosRepositorio(cn);
                    registros = repositorio.Editar(egreso);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Egreso GetEgresoPorId(int id)
        {
            try
            {
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new EgresosRepositorio(cn);
                    return repositorio.GetEgresoPorId(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
