using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARKING.Entidades
{
    public class Ingreso
    {
        public int IngresoId { get; set; }
        public int VehiculoId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool AbonoVigente { get; set; }
        public int LugarId { get; set; }
        public byte[] RowVersion { get; set; }

        public Vehiculo Vehiculo { get; set; }
        public Lugar Lugar { get; set; }
    }
}
