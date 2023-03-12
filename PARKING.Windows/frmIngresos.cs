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
    public partial class frmIngresos : Form
    {
        public frmIngresos()
        {
            InitializeComponent();
        }

        private IngresosServicios servicio;
        private EgresosServicios servicioEgresos;
        private VehiculosServicios servicioVehiculos;
        private List<Ingreso> lista;
        private void frmIngresos_Load(object sender, EventArgs e)
        {
            servicio = new IngresosServicios();
            servicioVehiculos = new VehiculosServicios();
            servicioEgresos = new EgresosServicios();
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
            frmIngresosAE frm = new frmIngresosAE() { Text = "Agregar un ingreso" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                Ingreso ingreso = frm.GetIngreso();
                Vehiculo vehiculo = frm.GetVehiculo();
                Egreso egreso = new Egreso();
                egreso.IngresoId = ingreso.IngresoId;

                if (!servicioEgresos.ExisteVehiculo(ingreso))
                {
                    servicioVehiculos.Agregar(vehiculo);

                    if (!servicio.Existe(ingreso))
                    {
                        ingreso.VehiculoId = vehiculo.VehiculoId;
                        int registrosAfectados = servicio.Agregar(ingreso);
                        if (registrosAfectados == 0)
                        {
                            HelperMessage.Mensaje(TipoMensaje.Warning, "No se agregaron registros", "Advertencia");
                            RecargarGrilla();
                        }
                        else
                        {
                            RecargarGrilla();

                            HelperMessage.Mensaje(TipoMensaje.OK, "Registro agregado", "Mensaje");
                        }

                    }
                    else
                    {
                        HelperMessage.Mensaje(TipoMensaje.Error, "Ingreso existente!!!", "Error");

                    }
                }
                else
                {
                    HelperMessage.Mensaje(TipoMensaje.Error, "Vehiculo dentro del parking!!!", "Error");

                }
                
            }
            catch (Exception exception)
            {
                HelperMessage.Mensaje(TipoMensaje.Error, exception.Message, "Error");
            }
        }
    }
}
