using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARKING.Entidades
{
    public class TipoDeTarifa
    {
        public int TipoTarifaId { get; set; }
        public string TipoTarifa { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
