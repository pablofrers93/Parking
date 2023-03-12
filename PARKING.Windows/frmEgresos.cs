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
    public partial class frmEgresos : Form
    {
        private EgresosServicios servicio;
        private IngresosServicios servicioIngresos;
        private VehiculosServicios servicioVehiculos;
        private List<Egreso> lista;
        public frmEgresos()
        {
            InitializeComponent();
        }

        private void frmEgresos_Load(object sender, EventArgs e)
        {
            servicio = new EgresosServicios();

            RecargarGrilla();
        }
        private void RecargarGrilla()
        {
            try
            {
                lista = servicio.GetLista();
                HelperForm.MostrarDatosEnGrilla(DatosDataGridView, lista);
            }
            catch (Exception ex)
            {
                HelperMessage.Mensaje(TipoMensaje.Error, ex.Message, "Error");
            }
        }

        private void NuevoIconButton_Click(object sender, EventArgs e)
        {
            frmEgresosAE frm = new frmEgresosAE() { Text = "Salida de vehiculo" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                Egreso egreso = frm.GetEgreso();

                    if (!servicio.Existe(egreso))
                    {
                        int registrosAfectados = servicio.Agregar(egreso);
                        if (registrosAfectados == 0)
                        {
                            HelperMessage.Mensaje(TipoMensaje.Warning, "No se pudo dar la salida", "Advertencia");
                            RecargarGrilla();
                        }
                        else
                        {
                            RecargarGrilla();

                            HelperMessage.Mensaje(TipoMensaje.OK, "Salida exitosa", "Mensaje");
                        }

                    }
                    else
                    {
                        HelperMessage.Mensaje(TipoMensaje.Error, " Ya se dió salida para ese vehiculo", "Error");

                    }
            }
            catch (Exception exception)
            {
                HelperMessage.Mensaje(TipoMensaje.Error, exception.Message, "Error");
            }
        }
    }
}
