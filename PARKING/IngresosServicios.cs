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
    public class IngresosServicios
    {
        private IngresosRepositorio repositorio;
        private LugaresRepositorio repoLugares;
        private PlantasRepositorio repoPlantas;
        private VehiculosRepositorio repoVehiculos;

        public IngresosServicios() { }

        public List<Ingreso> GetLista()
        {
            try
            {
                List<Ingreso> lista = null;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new IngresosRepositorio(cn);
                    repoVehiculos = new VehiculosRepositorio(cn);
                    repoLugares = new LugaresRepositorio(cn);
                    repoPlantas = new PlantasRepositorio(cn);
                    lista = repositorio.GetLista();
                    foreach (var ingreso in lista)
                    {
                        ingreso.Lugar = repoLugares.GetLugarPorId(ingreso.LugarId);
                        ingreso.Lugar.Planta = repoPlantas.GetPlantaPorId(ingreso.Lugar.PlantaId);
                        ingreso.Vehiculo = repoVehiculos.GetVehiculoPorId(ingreso.VehiculoId);
                    }

                    return lista;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Ingreso ingreso)
        {
            try
            {
                bool existe = true;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new IngresosRepositorio(cn);
                    existe = repositorio.Existe(ingreso);
                }

                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Agregar(Ingreso ingreso)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new IngresosRepositorio(cn);
                    registros = repositorio.Agregar(ingreso);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Borrar(Ingreso ingreso)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new IngresosRepositorio(cn);
                    registros = repositorio.Borrar(ingreso);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Editar(Ingreso ingreso)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new IngresosRepositorio(cn);
                    registros = repositorio.Editar(ingreso);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Ingreso GetIngresoPorId(int id)
        {
            try
            {
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new IngresosRepositorio(cn);
                    return repositorio.GetIngresoPorId(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Ingreso GetIngresoPorVehiculoId(Object obj)
        {
            try
            {
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new IngresosRepositorio(cn);
                    return repositorio.GetIngresoPorVehiculoId(obj);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
