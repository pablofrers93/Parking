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
    public class ValorTarifasServicios
    {
        private ValorTarifasRepositorio repositorio;
        private TipoDeTarifasRepositorio repoTipoTarifas;

        public ValorTarifasServicios() { }

        public List<ValorTarifa> GetLista()
        {
            try
            {
                List<ValorTarifa> lista = null;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new ValorTarifasRepositorio(cn);
                    repoTipoTarifas = new TipoDeTarifasRepositorio(cn);
                    lista = new List<ValorTarifa>();
                    lista = repositorio.GetLista();
                    foreach (var valorTarifa in lista)
                    {
                        valorTarifa.TipoTarifa = repoTipoTarifas.GetTipoTarifaPorId(valorTarifa.TipoTarifaId);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool Existe(ValorTarifa valorTarifa)
        {
            try
            {
                bool existe = true;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new ValorTarifasRepositorio(cn);
                    existe = repositorio.Existe(valorTarifa);
                }

                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Agregar(ValorTarifa valorTarifa)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new ValorTarifasRepositorio(cn);
                    registros = repositorio.Agregar(valorTarifa);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Borrar(ValorTarifa valorTarifa)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new ValorTarifasRepositorio(cn);
                    registros = repositorio.Borrar(valorTarifa);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Editar(ValorTarifa valorTarifa)
        {
            try
            {
                int registros = 0;
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new ValorTarifasRepositorio(cn);
                    registros = repositorio.Editar(valorTarifa);
                }

                return registros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public ValorTarifa GetValorTarifaPorId(int id)
        {
            try
            {
                using (var cn = ConexionBD.GetInstancia().AbrirConexion())
                {
                    repositorio = new ValorTarifasRepositorio(cn);
                    return repositorio.GetValorTarifaPorId(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
