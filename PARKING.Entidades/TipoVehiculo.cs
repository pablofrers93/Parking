using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARKING.Entidades
{
    public class TipoVehiculo
    {
        public int TipoId { get; set; }
        public string NombreTipoVehiculo { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
