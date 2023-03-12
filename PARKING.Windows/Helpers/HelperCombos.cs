using PARKING.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PARKING.Windows.Helpers
{
    public static class HelperCombos
    {
        public static void CargarDatosComboTipoVehiculos(ref ComboBox combo)
        {
            TipoVehiculosServicio servicio = new TipoVehiculosServicio();
            var lista = servicio.GetLista();
            var defaultTipoVehiculo = new TipoVehiculo()
            {
                TipoId = 0,
                NombreTipoVehiculo = "Seleccione Tipo Vehiculo"
            };
            lista.Insert(0, defaultTipoVehiculo);
            combo.DataSource = lista;
            combo.DisplayMember = "Tipo Vehiculo";
            combo.ValueMember = "NombreTipoVehiculo";
            combo.SelectedIndex = 0;
        }

        internal static void CargarDatosComboPatentes(ref ComboBox combo)
        {
            IngresosServicios servicio = new IngresosServicios();
            var lista = servicio.GetLista();
            combo.DataSource = lista;
            combo.DisplayMember = "Patente";
            combo.ValueMember = "Vehiculo";
            combo.SelectedIndex = 0;
        }

        public static void CargarDatosComboPlantas(ref ComboBox combo)
        {
            PlantasServicios servicio = new PlantasServicios();
            var lista = servicio.GetLista();
            var defaultPlanta = new Planta()
            {
                PlantaId = 0,
                NombrePlanta = "Seleccione Planta"
            };
            lista.Insert(0, defaultPlanta);
            combo.DataSource = lista;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "NombrePlanta";
            combo.SelectedIndex = 0;
        }

        public static void CargarDatosComboLugares(ref ComboBox combo, Planta planta)
        {
            LugaresServicios servicio = new LugaresServicios();
            var lista = servicio.GetLista(planta);
            combo.DataSource = lista;
            combo.DisplayMember = "Numero Lugar";
            combo.ValueMember = "Numero";
            combo.SelectedIndex = 0;
        }

    }
}
