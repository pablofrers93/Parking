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
    public class VehiculosServicios
    {
        private VehiculosRepositorio repositorio;

        public VehiculosServicios() { }

        public List<Vehiculo> GetLista()
        {
            try
            {
                List<Vehiculo> lista = null;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new VehiculosRepositorio(cn);
                    lista = new List<Vehiculo>();
                    lista = repositorio.GetLista();

                    return lista;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool Existe(Vehiculo vehiculo)
        {
            try
            {
                bool existe = true;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new VehiculosRepositorio(cn);
                    existe = repositorio.Existe(vehiculo);
                }

                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Agregar(Vehiculo vehiculo)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new VehiculosRepositorio(cn);
                    registros = repositorio.Agregar(vehiculo);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Borrar(Vehiculo vehiculo)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new VehiculosRepositorio(cn);
                    registros = repositorio.Borrar(vehiculo);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Editar(Vehiculo vehiculo)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new VehiculosRepositorio(cn);
                    registros = repositorio.Editar(vehiculo);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Vehiculo GetVehiculoPorId(object obj)
        {
            try
            {
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new VehiculosRepositorio(cn);
                    return repositorio.GetVehiculoPorId(obj);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
