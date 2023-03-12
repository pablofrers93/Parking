using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARKING.Entidades
{
    public class ValorTarifa
    {
        public int TarifaId { get; set; }
        public int TipoVehiculoId { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public int Valor { get; set; }
        public int TipoTarifaId { get; set; }
        public byte[] RowVersion { get; set; }

        public TipoDeTarifa TipoTarifa;
        public TipoVehiculo TipoVehiculo;
    }
}
