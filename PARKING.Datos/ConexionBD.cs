using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PARKING.Datos
{
    public class ConexionBD
    {
        private readonly string cadenaConexion;
        private SqlConnection cn;

        public static ConexionBD instancia = null;

        public static ConexionBD GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new ConexionBD();
            }

            return instancia;
        }
        private ConexionBD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

        }

        public SqlConnection AbrirConexion()
        {
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cn.Open();
                return cn;
            }
            catch (Exception e)
            {
                throw new Exception("No se estableció la conexión");
            }
        }

        public void CerrarConexion()
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
    }
}
