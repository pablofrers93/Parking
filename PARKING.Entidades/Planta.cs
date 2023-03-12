using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARKING.Entidades
{
    public class Planta
    {
        public int PlantaId { get; set; }
        public string NombrePlanta { get; set; }
        public byte[] RowVersion { get; set; }
        public int CantidadLugares { get; set; }
        public int LugaresDisponibles { get; set; }

        public override string ToString()
        {
            return this.NombrePlanta;
        }
    }
}
