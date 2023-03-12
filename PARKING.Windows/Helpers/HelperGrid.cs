using PARKING.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PARKING.Windows.Helpers
{
    public static class HelperGrid
    {
        public static void LimpiarGrilla(DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();

        }
        public static DataGridViewRow ConstruirFila(DataGridView dataGrid)
        {
            var r = new DataGridViewRow();
            r.CreateCells(dataGrid);
            return r;
        }

        public static void AgregarFila(DataGridView dataGrid, DataGridViewRow r)
        {
            dataGrid.Rows.Add(r);
        }

        public static void SetearFila(DataGridViewRow r, Object obj)
        {
            switch (obj)
            {
                case Abono a:
                    r.Cells[0].Value = a.Cliente.Nombre;
                    r.Cells[1].Value = a.Vehiculo.Patente;
                    r.Cells[2].Value = a.TipoTarifaAbonada;
                    r.Cells[3].Value = a.FechaDesde;

                    break;
                case Planta p:
                    r.Cells[0].Value = p.NombrePlanta;
                    r.Cells[1].Value = p.CantidadLugares;
                    r.Cells[2].Value = p.LugaresDisponibles;

                    break;

                case Cliente c:
                    r.Cells[0].Value = c.Apellido;
                    r.Cells[1].Value = c.Nombre;
                    r.Cells[2].Value = c.Telefono;

                    break;
                case Vehiculo v:
                    r.Cells[0].Value = v.Patente;

                    break;
                case Ingreso i:
                    r.Cells[0].Value = i.Vehiculo.Patente;
                    r.Cells[1].Value = i.FechaIngreso;
                    r.Cells[2].Value = i.AbonoVigente;
                    r.Cells[3].Value = i.Lugar.Numero;
                    r.Cells[4].Value = i.Lugar.Planta.NombrePlanta;

                    break;
                case Egreso e:
                    r.Cells[0].Value = e.Vehiculo.Patente;
                    r.Cells[1].Value = e.FechaIngreso;
                    r.Cells[2].Value = e.FechaEgreso;
                    r.Cells[3].Value = e.Lugar.Planta.NombrePlanta;
                    r.Cells[4].Value = e.Lugar.Numero;
                    r.Cells[5].Value = '$';
                    r.Cells[5].Value += Convert.ToString(e.ImporteAbonado);
                    //r.Cells[6].Value = e.ValorTarifa.TipoTarifa.TipoTarifa;
                    break;
                case Lugar l:
                    r.Cells[0].Value = l.Numero;
                    r.Cells[1].Value = l.Planta.NombrePlanta;
                    break;
            }

            r.Tag = obj;

        }

        public static void BorrarFila(DataGridView dataGridView, DataGridViewRow r)
        {
            dataGridView.Rows.Remove(r);
        }
    }
}
