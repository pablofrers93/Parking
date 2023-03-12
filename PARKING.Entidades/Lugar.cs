using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARKING.Entidades
{
    public class Lugar
    {
        public int LugarId { get; set; }
        public int Numero { get; set; }
        public int PlantaId { get; set; }
        public byte[] RowVersion { get; set; }

        public Planta Planta;

        public override string ToString()
        {
            return "" + this.Numero;
        }
    }
}
