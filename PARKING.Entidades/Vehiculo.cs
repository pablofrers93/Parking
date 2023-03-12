using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARKING.Entidades
{
    public class Vehiculo
    {
        public int VehiculoId { get; set; }
        public string Patente { get; set; }
        public int TipoVehiculoId { get; set; }
        public byte[] RowVersion { get; set; }

        public TipoVehiculo TipoVehiculo { get; set; }

        public override string ToString()
        {
            return this.Patente;
        }
    }
}
