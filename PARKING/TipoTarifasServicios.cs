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
    public class TipoDeTarifasServicios
    {
        private TipoDeTarifasRepositorio repositorio;

        public TipoDeTarifasServicios() { }

        public List<TipoDeTarifa> GetLista()
        {
            try
            {
                List<TipoDeTarifa> lista = null;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new TipoDeTarifasRepositorio(cn);
                    lista = new List<TipoDeTarifa>();
                    lista = repositorio.GetLista();

                    return lista;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool Existe(TipoDeTarifa tipoDeTarifa)
        {
            try
            {
                bool existe = true;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new TipoDeTarifasRepositorio(cn);
                    existe = repositorio.Existe(tipoDeTarifa);
                }

                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Agregar(TipoDeTarifa tipoDeTarifa)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new TipoDeTarifasRepositorio(cn);
                    registros = repositorio.Agregar(tipoDeTarifa);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Borrar(TipoDeTarifa tipoDeTarifa)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new TipoDeTarifasRepositorio(cn);
                    registros = repositorio.Borrar(tipoDeTarifa);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Editar(TipoDeTarifa tipoDeTarifa)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new TipoDeTarifasRepositorio(cn);
                    registros = repositorio.Editar(tipoDeTarifa);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public TipoDeTarifa GetTipoDeTarifaPorId(int id)
        {
            try
            {
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new TipoDeTarifasRepositorio(cn);
                    return repositorio.GetTipoDeTarifaPorId(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public object GetTipoDeTarifaIdPorTipoVehiculoId(object obj)
        {
            try
            {
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new TipoDeTarifasRepositorio(cn);
                    return repositorio.GetTipoDeTarifaIdPorVehiculoId(obj);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
