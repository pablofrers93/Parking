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
    public class TipoVehiculosServicio
    {
        private TipoVehiculosRepositorio repositorio;

        public TipoVehiculosServicio() { }

        public List<TipoVehiculo> GetLista()
        {
            try
            {
                List<TipoVehiculo> lista = null;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new TipoVehiculosRepositorio(cn);
                    lista = new List<TipoVehiculo>();
                    lista = repositorio.GetLista();

                    return lista;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool Existe(TipoVehiculo tipoVehiculo)
        {
            try
            {
                bool existe = true;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new TipoVehiculosRepositorio(cn);
                    existe = repositorio.Existe(tipoVehiculo);
                }

                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Agregar(TipoVehiculo tipoVehiculo)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new TipoVehiculosRepositorio(cn);
                    registros = repositorio.Agregar(tipoVehiculo);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Borrar(TipoVehiculo tipoVehiculo)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new TipoVehiculosRepositorio(cn);
                    registros = repositorio.Borrar(tipoVehiculo);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Editar(TipoVehiculo tipoVehiculo)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new TipoVehiculosRepositorio(cn);
                    registros = repositorio.Editar(tipoVehiculo);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public TipoVehiculo GetTipoVehiculoPorId(int id)
        {
            try
            {
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new TipoVehiculosRepositorio(cn);
                    return repositorio.GetTipoVehiculoPorId(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
