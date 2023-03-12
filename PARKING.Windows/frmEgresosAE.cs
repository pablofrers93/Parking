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
    public partial class frmEgresosAE : Form
    {
        private Egreso egreso;
        private Vehiculo vehiculo;
        private Lugar lugar;
        private IngresosServicios servicioIngresos;
        private VehiculosServicios servicioVehiculos;
        private ValorTarifa valorTarifa;
        private TipoDeTarifa tipoDeTarifa;

        public frmEgresosAE()
        {
            InitializeComponent();
        }

        private void frmEgresosAE_Load(object sender, EventArgs e)
        {
            HelperCombos.CargarDatosComboPatentes(ref PatentesComboBox);
            servicioIngresos = new IngresosServicios();
            servicioVehiculos = new VehiculosServicios();

        }
        
        public Egreso GetEgreso()
        {
            return egreso;
        }
        public void SetEgreso(Egreso egreso)
        {
            this.egreso = egreso;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (egreso == null)
                {
                    egreso = new Egreso();
                    
                }
                vehiculo = new Vehiculo();
                lugar = new Lugar();
                vehiculo.Patente = ((Ingreso)(PatentesComboBox.SelectedItem)).Vehiculo.Patente;
                vehiculo.TipoVehiculoId = ((Ingreso)(PatentesComboBox.SelectedItem)).Vehiculo.TipoVehiculoId;
                lugar = ((Ingreso)(PatentesComboBox.SelectedItem)).Lugar;
                egreso.IngresoId = servicioIngresos.GetIngresoPorVehiculoId(PatentesComboBox.SelectedItem).IngresoId;
                egreso.FechaEgreso = DateTimePicker.Value;
                egreso.FechaIngreso = servicioIngresos.GetIngresoPorVehiculoId(PatentesComboBox.SelectedItem).FechaIngreso;
                egreso.Vehiculo = vehiculo;
                egreso.Lugar = lugar;
                //egreso.ValorTarifa = valorTarifa;
                egreso.ImporteAbonado = CalcularTarifa(egreso.Vehiculo.TipoVehiculoId).Valor;


                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (PatentesComboBox.SelectedIndex < 0)
            {
                valido = false;
                errorProvider1.SetError(PatentesComboBox, "Debe seleccionar un vehiculo");
            }

            return valido;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private ValorTarifa CalcularTarifa(int tipoVehiculo)
        {
            int valor = 0;
            valorTarifa = new ValorTarifa();
            tipoDeTarifa = new TipoDeTarifa();

            switch(tipoVehiculo)
            {
                case 1: //auto
                    if (egreso.FechaEgreso.Day == egreso.FechaIngreso.Day && // Comprueba que el ingreso y egreso sea durante el dia
                        egreso.FechaEgreso.Month == egreso.FechaIngreso.Month &&
                        egreso.FechaEgreso.Year == egreso.FechaIngreso.Year)
                    {
                        if ((egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) >= 6)
                        {
                            if (egreso.FechaEgreso.Hour < 23)
                            {
                                valor = 2400;
                                valorTarifa.TipoVehiculoId = tipoVehiculo;
                                valorTarifa.FechaDesde = egreso.FechaIngreso;
                                valorTarifa.FechaHasta = egreso.FechaEgreso;
                                valorTarifa.Valor = 2400;
                                valorTarifa.TipoTarifaId = 3;

                            }
                            else
                            {
                                valor = 2400+300;// valor de la estadia mas una hora.
                                valorTarifa.TipoVehiculoId = tipoVehiculo;
                                valorTarifa.FechaDesde = egreso.FechaIngreso;
                                valorTarifa.FechaHasta = egreso.FechaEgreso;
                                valorTarifa.Valor = 2400 + 300;
                                valorTarifa.TipoTarifaId = 3;
                            }
                        }
                        else if (((egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) >= 4) &&
                            (egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) < 6)
                        {
                            valor = 1200;
                            valorTarifa.TipoVehiculoId = tipoVehiculo;
                            valorTarifa.FechaDesde = egreso.FechaIngreso;
                            valorTarifa.FechaHasta = egreso.FechaEgreso;
                            valorTarifa.Valor = 1200;
                            valorTarifa.TipoTarifaId = 2;
                        }
                        else
                        {
                            if ((egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) == 3)
                            {
                                if ((egreso.FechaEgreso.Minute - egreso.FechaIngreso.Minute) > 15)
                                {
                                    valor = 300 * 3 + 300; // valor de 3 horas + 1 hora por demora de mas de 15min
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 300 * 3 + 300;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                                else
                                {
                                    valor = 300 * 3; // valor de 3 horas 
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 300 * 3;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                            }
                            else if ((egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) == 2)
                            {
                                if ((egreso.FechaEgreso.Minute - egreso.FechaIngreso.Minute) > 15)
                                {
                                    valor = 300 * 2 + 300; // valor de 2 horas + 1 hora por demora de mas de 15min
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 300 * 2 + 300;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                                else
                                {
                                    valor = 300 * 2; // valor de 2 horas 
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 300 * 2;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                            }
                            else
                            {
                                if ((egreso.FechaEgreso.Minute - egreso.FechaIngreso.Minute) > 15)
                                {
                                    valor = 300 + 300; // valor de 1 hora + 1 hora por demora de mas de 15min
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 300 + 300;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                                else
                                {
                                    valor = 300; // valor de 1 hora
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 300;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                            }
                        }

                    }
                    else if ((egreso.FechaEgreso.Day - egreso.FechaIngreso.Day) == 1) // comprueba si se queda una noche
                    {
                        if ((egreso.FechaIngreso.Hour >= 20) && (egreso.FechaEgreso.Hour <= 8)) // escenario de tarifa noche 
                        {
                            valor = 2000;
                            valorTarifa.TipoVehiculoId = tipoVehiculo;
                            valorTarifa.FechaDesde = egreso.FechaIngreso;
                            valorTarifa.FechaHasta = egreso.FechaEgreso;
                            valorTarifa.Valor = 2000;
                            valorTarifa.TipoTarifaId = 4;
                        }
                        else if ((egreso.FechaIngreso.Hour < 20) && (egreso.FechaEgreso.Hour <= 8)) // escenario tarifa noche ingresando antes de las 20hs
                        {
                            int diferencia_horas = 20 - egreso.FechaIngreso.Hour;
                            int tarifa_extra = 300 * diferencia_horas;
                            valor = 2000 + tarifa_extra;
                            valorTarifa.TipoVehiculoId = tipoVehiculo;
                            valorTarifa.FechaDesde = egreso.FechaIngreso;
                            valorTarifa.FechaHasta = egreso.FechaEgreso;
                            valorTarifa.Valor = 2000 + tarifa_extra;
                            valorTarifa.TipoTarifaId = 4;
                        }
                        else // escenario de entrada antes de las 20hs y salida después de las 8:00hs
                        {
                            int diferencia_horas_ingreso = 20 - egreso.FechaIngreso.Hour;
                            int tarifa_extra_ingreso = 300 * diferencia_horas_ingreso;
                            int diferencia_horas_egreso = egreso.FechaEgreso.Hour - 8;
                            int tarifa_extra_egreso = 300 * diferencia_horas_egreso;
                            int tarifa_extra = tarifa_extra_ingreso + tarifa_extra_egreso;

                            valor = 2000 + tarifa_extra;
                            valorTarifa.TipoVehiculoId = tipoVehiculo;
                            valorTarifa.FechaDesde = egreso.FechaIngreso;
                            valorTarifa.FechaHasta = egreso.FechaEgreso;
                            valorTarifa.Valor = 2000 + tarifa_extra;
                            valorTarifa.TipoTarifaId = 4;
                        }
                    }
                    
                    else valor = 0;
                    break;
                case 2: //camioneta
                    if (egreso.FechaEgreso.Day == egreso.FechaIngreso.Day && // Comprueba que el ingreso y egreso sea durante el dia
                        egreso.FechaEgreso.Month == egreso.FechaIngreso.Month &&
                        egreso.FechaEgreso.Year == egreso.FechaIngreso.Year)
                    {
                        if ((egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) >= 6)
                        {
                            if (egreso.FechaEgreso.Hour < 23)
                            {
                                valor = 2200;
                                valorTarifa.TipoVehiculoId = tipoVehiculo;
                                valorTarifa.FechaDesde = egreso.FechaIngreso;
                                valorTarifa.FechaHasta = egreso.FechaEgreso;
                                valorTarifa.Valor = 2200;
                                valorTarifa.TipoTarifaId = 3;
                            }
                            else
                            {
                                valor = 2400 + 350; // valor de la estadia mas una hora.
                                valorTarifa.TipoVehiculoId = tipoVehiculo;
                                valorTarifa.FechaDesde = egreso.FechaIngreso;
                                valorTarifa.FechaHasta = egreso.FechaEgreso;
                                valorTarifa.Valor = 2400 + 350;
                                valorTarifa.TipoTarifaId = 3;
                            }
                        }
                        else if (((egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) >= 4) &&
                            (egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) < 6)
                        {
                            valor = 1400;
                            valorTarifa.TipoVehiculoId = tipoVehiculo;
                            valorTarifa.FechaDesde = egreso.FechaIngreso;
                            valorTarifa.FechaHasta = egreso.FechaEgreso;
                            valorTarifa.Valor = 1400;
                            valorTarifa.TipoTarifaId = 2;
                        }
                        else
                        {
                            if ((egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) == 3)
                            {
                                if ((egreso.FechaEgreso.Minute - egreso.FechaIngreso.Minute) > 15)
                                {
                                    valor = 350 * 3 + 350; // valor de 3 horas + 1 hora por demora de mas de 15min
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 350 * 3 + 350;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                                else
                                {
                                    valor = 350 * 3; // valor de 3 horas 
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 350 * 3;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                            }
                            else if ((egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) == 2)
                            {
                                if ((egreso.FechaEgreso.Minute - egreso.FechaIngreso.Minute) > 15)
                                {
                                    valor = 350 * 2 + 350; // valor de 2 horas + 1 hora por demora de mas de 15min
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 350 * 2 + 350;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                                else
                                {
                                    valor = 350 * 2; // valor de 2 horas 
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 350 * 2;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                            }
                            else
                            {
                                if ((egreso.FechaEgreso.Minute - egreso.FechaIngreso.Minute) > 15)
                                {
                                    valor = 350 + 350; // valor de 1 hora + 1 hora por demora de mas de 15min
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 350 + 350;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                                else
                                {
                                    valor = 350; // valor de 1 hora
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 350;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                            }
                        }

                    }
                    else if ((egreso.FechaEgreso.Day - egreso.FechaIngreso.Day) == 1) // comprueba si se queda una noche
                    {
                        if ((egreso.FechaIngreso.Hour >= 20) && (egreso.FechaEgreso.Hour <= 8)) // escenario de tarifa noche 
                        {
                            valor = 1800;
                            valorTarifa.TipoVehiculoId = tipoVehiculo;
                            valorTarifa.FechaDesde = egreso.FechaIngreso;
                            valorTarifa.FechaHasta = egreso.FechaEgreso;
                            valorTarifa.Valor = 1800;
                            valorTarifa.TipoTarifaId = 4;
                        }
                        else if ((egreso.FechaIngreso.Hour < 20) && (egreso.FechaEgreso.Hour <= 8)) // escenario tarifa noche ingresando antes de las 20hs
                        {
                            int diferencia_horas = 20 - egreso.FechaIngreso.Hour;
                            int tarifa_extra = 350 * diferencia_horas;
                            valor = 1800 + tarifa_extra;
                            valorTarifa.TipoVehiculoId = tipoVehiculo;
                            valorTarifa.FechaDesde = egreso.FechaIngreso;
                            valorTarifa.FechaHasta = egreso.FechaEgreso;
                            valorTarifa.Valor = 1800 + tarifa_extra;
                            valorTarifa.TipoTarifaId = 4;
                        }
                        else // escenario de entrada antes de las 20hs y salida después de las 8:00hs
                        {
                            int diferencia_horas_ingreso = 20 - egreso.FechaIngreso.Hour;
                            int tarifa_extra_ingreso = 350 * diferencia_horas_ingreso;
                            int diferencia_horas_egreso = egreso.FechaEgreso.Hour - 8;
                            int tarifa_extra_egreso = 350 * diferencia_horas_egreso;
                            int tarifa_extra = tarifa_extra_ingreso + tarifa_extra_egreso;

                            valor = 1800 + tarifa_extra;
                            valorTarifa.TipoVehiculoId = tipoVehiculo;
                            valorTarifa.FechaDesde = egreso.FechaIngreso;
                            valorTarifa.FechaHasta = egreso.FechaEgreso;
                            valorTarifa.Valor = 1800 + tarifa_extra;
                            valorTarifa.TipoTarifaId = 4;
                        }
                    }

                    else valor = 0;
                    break;
                case 3: //Combi
                    if (egreso.FechaEgreso.Day == egreso.FechaIngreso.Day && // Comprueba que el ingreso y egreso sea durante el dia
                        egreso.FechaEgreso.Month == egreso.FechaIngreso.Month &&
                        egreso.FechaEgreso.Year == egreso.FechaIngreso.Year)
                    {
                        if ((egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) >= 6)
                        {
                            if (egreso.FechaEgreso.Hour < 23)
                            {
                                valor = 2400;
                                valorTarifa.TipoVehiculoId = tipoVehiculo;
                                valorTarifa.FechaDesde = egreso.FechaIngreso;
                                valorTarifa.FechaHasta = egreso.FechaEgreso;
                                valorTarifa.Valor = 2400;
                                valorTarifa.TipoTarifaId = 3;
                            }
                            else
                            {
                                valor = 2400 + 400; // valor de la estadia mas una hora.
                                valorTarifa.TipoVehiculoId = tipoVehiculo;
                                valorTarifa.FechaDesde = egreso.FechaIngreso;
                                valorTarifa.FechaHasta = egreso.FechaEgreso;
                                valorTarifa.Valor = 2400 + 400;
                                valorTarifa.TipoTarifaId = 3;
                            }
                        }
                        else if (((egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) >= 4) &&
                            (egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) < 6)
                        {
                            valor = 1600;
                            valorTarifa.TipoVehiculoId = tipoVehiculo;
                            valorTarifa.FechaDesde = egreso.FechaIngreso;
                            valorTarifa.FechaHasta = egreso.FechaEgreso;
                            valorTarifa.Valor = 1600;
                            valorTarifa.TipoTarifaId = 2;
                        }
                        else
                        {
                            if ((egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) == 3)
                            {
                                if ((egreso.FechaEgreso.Minute - egreso.FechaIngreso.Minute) > 15)
                                {
                                    valor = 400 * 3 + 400; // valor de 3 horas + 1 hora por demora de mas de 15min
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 400 * 3 + 400;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                                else
                                {
                                    valor = 400 * 3; // valor de 3 horas 
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 400 * 3;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                            }
                            else if ((egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) == 2)
                            {
                                if ((egreso.FechaEgreso.Minute - egreso.FechaIngreso.Minute) > 15)
                                {
                                    valor = 400 * 2 + 400; // valor de 2 horas + 1 hora por demora de mas de 15min
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 400 * 2 + 400;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                                else
                                {
                                    valor = 400 * 2; // valor de 2 horas 
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 400 * 2;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                            }
                            else
                            {
                                if ((egreso.FechaEgreso.Minute - egreso.FechaIngreso.Minute) > 15)
                                {
                                    valor = 400 + 400; // valor de 1 hora + 1 hora por demora de mas de 15min
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 400 + 400;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                                else
                                {
                                    valor = 400; // valor de 1 hora
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 400;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                            }
                        }

                    }
                    else if ((egreso.FechaEgreso.Day - egreso.FechaIngreso.Day) == 1) // comprueba si se queda una noche
                    {
                        if ((egreso.FechaIngreso.Hour >= 20) && (egreso.FechaEgreso.Hour <= 8)) // escenario de tarifa noche 
                        {
                            valor = 2000;
                            valorTarifa.TipoVehiculoId = tipoVehiculo;
                            valorTarifa.FechaDesde = egreso.FechaIngreso;
                            valorTarifa.FechaHasta = egreso.FechaEgreso;
                            valorTarifa.Valor = 2000;
                            valorTarifa.TipoTarifaId = 4;
                        }
                        else if ((egreso.FechaIngreso.Hour < 20) && (egreso.FechaEgreso.Hour <= 8)) // escenario tarifa noche ingresando antes de las 20hs
                        {
                            int diferencia_horas = 20 - egreso.FechaIngreso.Hour;
                            int tarifa_extra = 400 * diferencia_horas;
                            valor = 2000 + tarifa_extra;
                            valorTarifa.TipoVehiculoId = tipoVehiculo;
                            valorTarifa.FechaDesde = egreso.FechaIngreso;
                            valorTarifa.FechaHasta = egreso.FechaEgreso;
                            valorTarifa.Valor = 2000 + tarifa_extra;
                            valorTarifa.TipoTarifaId = 4;
                        }
                        else // escenario de entrada antes de las 20hs y salida después de las 8:00hs
                        {
                            int diferencia_horas_ingreso = 20 - egreso.FechaIngreso.Hour;
                            int tarifa_extra_ingreso = 400 * diferencia_horas_ingreso;
                            int diferencia_horas_egreso = egreso.FechaEgreso.Hour - 8;
                            int tarifa_extra_egreso = 400 * diferencia_horas_egreso;
                            int tarifa_extra = tarifa_extra_ingreso + tarifa_extra_egreso;

                            valor = 2000 + tarifa_extra;
                            valorTarifa.TipoVehiculoId = tipoVehiculo;
                            valorTarifa.FechaDesde = egreso.FechaIngreso;
                            valorTarifa.FechaHasta = egreso.FechaEgreso;
                            valorTarifa.Valor = 2000 + tarifa_extra;
                            valorTarifa.TipoTarifaId = 4;
                        }
                    }

                    else valor = 0;
                    break;
                case 4: //Moto
                    if (egreso.FechaEgreso.Day == egreso.FechaIngreso.Day && // Comprueba que el ingreso y egreso sea durante el dia
                        egreso.FechaEgreso.Month == egreso.FechaIngreso.Month &&
                        egreso.FechaEgreso.Year == egreso.FechaIngreso.Year)
                    {
                        if ((egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) >= 6)
                        {
                            if (egreso.FechaEgreso.Hour < 23)
                            {
                                valor = 2000;
                                valorTarifa.TipoVehiculoId = tipoVehiculo;
                                valorTarifa.FechaDesde = egreso.FechaIngreso;
                                valorTarifa.FechaHasta = egreso.FechaEgreso;
                                valorTarifa.Valor = 2000;
                                valorTarifa.TipoTarifaId = 3;
                            }
                            else
                            {
                                valor = 2000 + 300; // valor de la estadia mas una hora.
                                valorTarifa.TipoVehiculoId = tipoVehiculo;
                                valorTarifa.FechaDesde = egreso.FechaIngreso;
                                valorTarifa.FechaHasta = egreso.FechaEgreso;
                                valorTarifa.Valor = 2000 + 300;
                                valorTarifa.TipoTarifaId = 3;
                            }
                        }
                        else if (((egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) >= 4) &&
                            (egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) < 6)
                        {
                            valor = 1200;
                            valorTarifa.TipoVehiculoId = tipoVehiculo;
                            valorTarifa.FechaDesde = egreso.FechaIngreso;
                            valorTarifa.FechaHasta = egreso.FechaEgreso;
                            valorTarifa.Valor = 1200;
                            valorTarifa.TipoTarifaId = 2;
                        }
                        else
                        {
                            if ((egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) == 3)
                            {
                                if ((egreso.FechaEgreso.Minute - egreso.FechaIngreso.Minute) > 15)
                                {
                                    valor = 300 * 3 + 300; // valor de 3 horas + 1 hora por demora de mas de 15min
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 300 * 3 + 300;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                                else
                                {
                                    valor = 300 * 3; // valor de 3 horas 
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 300 * 3;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                            }
                            else if ((egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) == 2)
                            {
                                if ((egreso.FechaEgreso.Minute - egreso.FechaIngreso.Minute) > 15)
                                {
                                    valor = 300 * 2 + 300; // valor de 2 horas + 1 hora por demora de mas de 15min
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 300 * 2 + 300;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                                else
                                {
                                    valor = 300 * 2; // valor de 2 horas 
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 300 * 2;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                            }
                            else
                            {
                                if ((egreso.FechaEgreso.Minute - egreso.FechaIngreso.Minute) > 15)
                                {
                                    valor = 300 + 300; // valor de 1 hora + 1 hora por demora de mas de 15min
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 300 + 300;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                                else
                                {
                                    valor = 300; // valor de 1 hora
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 300;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                            }
                        }

                    }
                    else if ((egreso.FechaEgreso.Day - egreso.FechaIngreso.Day) == 1) // comprueba si se queda una noche
                    {
                        if ((egreso.FechaIngreso.Hour >= 20) && (egreso.FechaEgreso.Hour <= 8)) // escenario de tarifa noche 
                        {
                            valor = 1500;
                            valorTarifa.TipoVehiculoId = tipoVehiculo;
                            valorTarifa.FechaDesde = egreso.FechaIngreso;
                            valorTarifa.FechaHasta = egreso.FechaEgreso;
                            valorTarifa.Valor = 1500;
                            valorTarifa.TipoTarifaId = 4;
                        }
                        else if ((egreso.FechaIngreso.Hour < 20) && (egreso.FechaEgreso.Hour <= 8)) // escenario tarifa noche ingresando antes de las 20hs
                        {
                            int diferencia_horas = 20 - egreso.FechaIngreso.Hour;
                            int tarifa_extra = 300 * diferencia_horas;
                            valor = 1500 + tarifa_extra;
                            valorTarifa.TipoVehiculoId = tipoVehiculo;
                            valorTarifa.FechaDesde = egreso.FechaIngreso;
                            valorTarifa.FechaHasta = egreso.FechaEgreso;
                            valorTarifa.Valor = 1500 + tarifa_extra;
                            valorTarifa.TipoTarifaId = 4;
                        }
                        else // escenario de entrada antes de las 20hs y salida después de las 8:00hs
                        {
                            int diferencia_horas_ingreso = 20 - egreso.FechaIngreso.Hour;
                            int tarifa_extra_ingreso = 300 * diferencia_horas_ingreso;
                            int diferencia_horas_egreso = egreso.FechaEgreso.Hour - 8;
                            int tarifa_extra_egreso = 300 * diferencia_horas_egreso;
                            int tarifa_extra = tarifa_extra_ingreso + tarifa_extra_egreso;

                            valor = 1500 + tarifa_extra;
                            valorTarifa.TipoVehiculoId = tipoVehiculo;
                            valorTarifa.FechaDesde = egreso.FechaIngreso;
                            valorTarifa.FechaHasta = egreso.FechaEgreso;
                            valorTarifa.Valor = 1500 + tarifa_extra;
                            valorTarifa.TipoTarifaId = 4;
                        }
                    }

                    else valor = 0;
                    break;
                case 5: //Moto c/sidecar
                    if (egreso.FechaEgreso.Day == egreso.FechaIngreso.Day && // Comprueba que el ingreso y egreso sea durante el dia
                        egreso.FechaEgreso.Month == egreso.FechaIngreso.Month &&
                        egreso.FechaEgreso.Year == egreso.FechaIngreso.Year)
                    {
                        if ((egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) >= 6)
                        {
                            if (egreso.FechaEgreso.Hour < 23)
                            {
                                valor = 2400;
                                valorTarifa.TipoVehiculoId = tipoVehiculo;
                                valorTarifa.FechaDesde = egreso.FechaIngreso;
                                valorTarifa.FechaHasta = egreso.FechaEgreso;
                                valorTarifa.Valor = 2400;
                                valorTarifa.TipoTarifaId = 3;
                            }
                            else
                            {
                                valor = 2400 + 400; // valor de la estadia mas una hora.
                                valorTarifa.TipoVehiculoId = tipoVehiculo;
                                valorTarifa.FechaDesde = egreso.FechaIngreso;
                                valorTarifa.FechaHasta = egreso.FechaEgreso;
                                valorTarifa.Valor = 2400 + 400;
                                valorTarifa.TipoTarifaId = 3;
                            }
                        }
                        else if (((egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) >= 4) &&
                            (egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) < 6)
                        {
                            valor = 1600;
                            valorTarifa.TipoVehiculoId = tipoVehiculo;
                            valorTarifa.FechaDesde = egreso.FechaIngreso;
                            valorTarifa.FechaHasta = egreso.FechaEgreso;
                            valorTarifa.Valor = 1600;
                            valorTarifa.TipoTarifaId = 2;
                        }
                        else
                        {
                            if ((egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) == 3)
                            {
                                if ((egreso.FechaEgreso.Minute - egreso.FechaIngreso.Minute) > 15)
                                {
                                    valor = 400 * 3 + 400; // valor de 3 horas + 1 hora por demora de mas de 15min
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 400 * 3 + 400;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                                else
                                {
                                    valor = 400 * 3; // valor de 3 horas 
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 400 * 3;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                            }
                            else if ((egreso.FechaEgreso.Hour - egreso.FechaIngreso.Hour) == 2)
                            {
                                if ((egreso.FechaEgreso.Minute - egreso.FechaIngreso.Minute) > 15)
                                {
                                    valor = 400 * 2 + 400; // valor de 2 horas + 1 hora por demora de mas de 15min
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 400 * 2 + 400;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                                else
                                {
                                    valor = 400 * 2; // valor de 2 horas 
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 400 * 2;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                            }
                            else
                            {
                                if ((egreso.FechaEgreso.Minute - egreso.FechaIngreso.Minute) > 15)
                                {
                                    valor = 400 + 400; // valor de 1 hora + 1 hora por demora de mas de 15min
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 400 + 400;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                                else
                                {
                                    valor = 400; // valor de 1 hora
                                    valorTarifa.TipoVehiculoId = tipoVehiculo;
                                    valorTarifa.FechaDesde = egreso.FechaIngreso;
                                    valorTarifa.FechaHasta = egreso.FechaEgreso;
                                    valorTarifa.Valor = 400;
                                    valorTarifa.TipoTarifaId = 1;
                                }
                            }
                        }

                    }
                    else if ((egreso.FechaEgreso.Day - egreso.FechaIngreso.Day) == 1) // comprueba si se queda una noche
                    {
                        if ((egreso.FechaIngreso.Hour >= 20) && (egreso.FechaEgreso.Hour <= 8)) // escenario de tarifa noche 
                        {
                            valor = 1800;
                            valorTarifa.TipoVehiculoId = tipoVehiculo;
                            valorTarifa.FechaDesde = egreso.FechaIngreso;
                            valorTarifa.FechaHasta = egreso.FechaEgreso;
                            valorTarifa.Valor = 1800;
                            valorTarifa.TipoTarifaId = 4;
                        }
                        else if ((egreso.FechaIngreso.Hour < 20) && (egreso.FechaEgreso.Hour <= 8)) // escenario tarifa noche ingresando antes de las 20hs
                        {
                            int diferencia_horas = 20 - egreso.FechaIngreso.Hour;
                            int tarifa_extra = 400 * diferencia_horas;
                            valor = 1800 + tarifa_extra;
                            valorTarifa.TipoVehiculoId = tipoVehiculo;
                            valorTarifa.FechaDesde = egreso.FechaIngreso;
                            valorTarifa.FechaHasta = egreso.FechaEgreso;
                            valorTarifa.Valor = 1800 + tarifa_extra;
                            valorTarifa.TipoTarifaId = 4;
                        }
                        else // escenario de entrada antes de las 20hs y salida después de las 8:00hs
                        {
                            int diferencia_horas_ingreso = 20 - egreso.FechaIngreso.Hour;
                            int tarifa_extra_ingreso = 400 * diferencia_horas_ingreso;
                            int diferencia_horas_egreso = egreso.FechaEgreso.Hour - 8;
                            int tarifa_extra_egreso = 400 * diferencia_horas_egreso;
                            int tarifa_extra = tarifa_extra_ingreso + tarifa_extra_egreso;

                            valor = 1800 + tarifa_extra;
                            valorTarifa.TipoVehiculoId = tipoVehiculo;
                            valorTarifa.FechaDesde = egreso.FechaIngreso;
                            valorTarifa.FechaHasta = egreso.FechaEgreso;
                            valorTarifa.Valor = 1800 + tarifa_extra;
                            valorTarifa.TipoTarifaId = 4;
                        }
                    }

                    else valor = 0;
                    break;
            }
            return valorTarifa;
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (egreso == null)
                {
                    egreso = new Egreso();
                }
                egreso.IngresoId = servicioIngresos.GetIngresoPorVehiculoId(PatentesComboBox.SelectedItem).IngresoId;
                egreso.FechaEgreso = DateTimePicker.Value;
                egreso.ImporteAbonado = 0;
                egreso.FechaIngreso = servicioIngresos.GetIngresoPorVehiculoId(PatentesComboBox.SelectedItem).FechaIngreso;
                egreso.Vehiculo = servicioIngresos.GetIngresoPorVehiculoId(PatentesComboBox.SelectedItem).Vehiculo;
                egreso.Lugar = servicioIngresos.GetIngresoPorVehiculoId(PatentesComboBox.SelectedItem).Lugar;
            }
        }

        private void ImporteTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime fechaIngreso;
            DateTime fechaEgreso;
            int tipoVehiculo;

            fechaIngreso = servicioIngresos.GetIngresoPorVehiculoId(PatentesComboBox.SelectedItem).FechaIngreso;
            fechaEgreso = DateTimePicker.Value;
            tipoVehiculo = servicioVehiculos.GetVehiculoPorId(PatentesComboBox.SelectedItem).TipoVehiculoId;

            ImporteTextBox.Text = Convert.ToString((CalcularTarifa(tipoVehiculo).Valor));
        }
    }
}
