using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARKING.Entidades
{
    public class Egreso
    {
        public int EgresoId { get; set; }
        public int IngresoId { get; set; }
        public DateTime FechaEgreso { get; set; }
        public int ImporteAbonado  { get; set; }
        public byte[] RowVersion { get; set; }
        public DateTime FechaIngreso { get; set; }


        public Vehiculo Vehiculo { get; set; }
        public Lugar Lugar { get; set; }
        public ValorTarifa ValorTarifa { get; set; }
    }
}
