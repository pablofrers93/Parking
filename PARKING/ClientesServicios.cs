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
    public class ClientesServicios
    {
        private ClientesRepositorio repositorio;

        public ClientesServicios() { }

        public List<Cliente> GetLista()
        {
            try
            {
                List<Cliente> lista = null;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new ClientesRepositorio(cn);
                    lista = new List<Cliente>();
                    lista = repositorio.GetLista();

                    return lista;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool Existe(Cliente cliente)
        {
            try
            {
                bool existe = true;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new ClientesRepositorio(cn);
                    existe = repositorio.Existe(cliente);
                }

                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Agregar(Cliente cliente)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new ClientesRepositorio(cn);
                    registros = repositorio.Agregar(cliente);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Borrar(Cliente cliente)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new ClientesRepositorio(cn);
                    registros = repositorio.Borrar(cliente);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Editar(Cliente cliente)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new ClientesRepositorio(cn);
                    registros = repositorio.Editar(cliente);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Cliente GetClientePorId(int id)
        {
            try
            {
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new ClientesRepositorio(cn);
                    return repositorio.GetClientePorId(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
