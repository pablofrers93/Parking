using PARKING.Entidades;
using PARKING.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PARKING.Windows
{
    public partial class frmIngresosAE : Form
    {
        private Ingreso ingreso;
        private Planta planta;
        private Vehiculo vehiculo;

        public frmIngresosAE()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public Ingreso GetIngreso()
        {
            return ingreso;
        }
        public void SetIngreso(Ingreso ingreso)
        {
            this.ingreso = ingreso;
        }
        public void SetVehiculo(Vehiculo vehiculo)
        {
            this.vehiculo = vehiculo;
        }
        public Vehiculo GetVehiculo()
        {
            return vehiculo;
        }
        private void frmIngresosAE_Load(object sender, EventArgs e)
        {
            HelperCombos.CargarDatosComboTipoVehiculos(ref TipoVehiculoComboBox);
            HelperCombos.CargarDatosComboPlantas(ref PlantaComboBox);
        }
        
        private void PlantaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PlantaComboBox.SelectedIndex > 0)
            {
                planta = (Planta)PlantaComboBox.SelectedItem;
                HelperCombos.CargarDatosComboLugares(ref NumeroLugarComboBox, planta);
            }
            else
            {
                NumeroLugarComboBox.DataSource = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (ingreso == null)
                {
                    ingreso = new Ingreso();
                    vehiculo = new Vehiculo();
                }
                vehiculo.Patente = PatenteTextBox.Text;
                vehiculo.TipoVehiculoId = (int)TipoVehiculoComboBox.SelectedIndex;
                ingreso.Vehiculo = vehiculo;
                ingreso.AbonoVigente = CheckBox.Checked;
                ingreso.LugarId = (int)NumeroLugarComboBox.SelectedValue;
                ingreso.Lugar = (Lugar)NumeroLugarComboBox.SelectedItem;
                ingreso.Lugar.Planta = (Planta)PlantaComboBox.SelectedItem;
                ingreso.FechaIngreso = DateTimePicker.Value;

                DialogResult = DialogResult.OK;
                //if ((int)PlantaComboBox.SelectedIndex == 1)
                //{
                //    ingreso.LugarId = (int)NumeroLugarComboBox.SelectedValue;
                //    ingreso.Lugar = (Lugar)NumeroLugarComboBox.SelectedItem;
                //}
                //else if ((int)PlantaComboBox.SelectedIndex == 2)
                //{
                //    ingreso.LugarId = (int)NumeroLugarComboBox.SelectedValue;
                //    ingreso.Lugar = (Lugar)NumeroLugarComboBox.SelectedItem;
                //}
                //else if ((int)PlantaComboBox.SelectedIndex == 3)
                //{
                //    ingreso.LugarId = NumeroLugarComboBox.SelectedIndex + 120;
                //    ingreso.Lugar = (Lugar)NumeroLugarComboBox.SelectedItem;
                //}
                //else if ((int)PlantaComboBox.SelectedIndex == 4)
                //{
                //    ingreso.LugarId = NumeroLugarComboBox.SelectedIndex + 140;
                //    ingreso.Lugar = (Lugar)NumeroLugarComboBox.SelectedItem;
                //}
                //else if ((int)PlantaComboBox.SelectedIndex == 5)
                //{
                //    ingreso.LugarId = NumeroLugarComboBox.SelectedIndex + 160;
                //    ingreso.Lugar = (Lugar)NumeroLugarComboBox.SelectedItem;
                //}

            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(PatenteTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(PatenteTextBox, "La patente es requerida");
            }

            if (TipoVehiculoComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(TipoVehiculoComboBox, "El tipo de vehiculo es obligatorio");
            }

            if (PlantaComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(PlantaComboBox, "Debe seleccionar una planta");
            }

            if (NumeroLugarComboBox.SelectedIndex == -1)
            {
                valido = false;
                errorProvider1.SetError(NumeroLugarComboBox, "Debe seleccionar un lugar");
            }

            return valido;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
