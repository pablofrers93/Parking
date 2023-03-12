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
    public class LugaresServicios
    {
        private LugaresRepositorio repositorio;
        private PlantasRepositorio repoPlantas;
        public LugaresServicios() { }

        public List<Lugar> GetLista()
        {
            try
            {
                List<Lugar> lista = null;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new LugaresRepositorio(cn);
                    lista = new List<Lugar>();
                    lista = repositorio.GetLista();

                    return lista;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<Lugar> GetLista(Planta planta)
        {
            try
            {
                List<Lugar> lista;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new LugaresRepositorio(cn);
                    repoPlantas = new PlantasRepositorio(cn);
                    lista = repositorio.GetListaLugaresDisponibles(planta);
                    foreach (var lugar in lista)
                    {
                        lugar.Planta = repoPlantas.GetPlantaPorId(lugar.PlantaId);
                    }
                }

                return lista;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public bool Existe(Lugar lugar)
        {
            try
            {
                bool existe = true;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new LugaresRepositorio(cn);
                    existe = repositorio.Existe(lugar);
                }

                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Agregar(Lugar lugar)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new LugaresRepositorio(cn);
                    registros = repositorio.Agregar(lugar);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Borrar(Lugar lugar)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new LugaresRepositorio(cn);
                    registros = repositorio.Borrar(lugar);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Editar(Lugar lugar)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new LugaresRepositorio(cn);
                    registros = repositorio.Editar(lugar);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Lugar GetLugarPorId(int id)
        {
            try
            {
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new LugaresRepositorio(cn);
                    return repositorio.GetLugarPorId(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
