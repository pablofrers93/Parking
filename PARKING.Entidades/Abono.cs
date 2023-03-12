using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARKING.Entidades
{
    public class Abono
    {
        public int AbonoId { get; set; }
        public int ClienteId { get; set; }
        public int VehiculoId { get; set; }
        public int TipoTarifaAbonada { get; set; }
        public DateTime FechaDesde { get; set; }

        public Cliente Cliente;
        public Vehiculo Vehiculo;
    }
}
