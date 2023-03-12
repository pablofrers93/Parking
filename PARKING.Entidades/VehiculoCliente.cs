using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARKING.Entidades
{
    public class VehiculoCliente
    {
        public int ClienteId { get; set; }
        public int VehiculoId { get; set; }
        public int ModeloId { get; set; }
        public int ColorId { get; set; }

        public Cliente Cliente;
        public Vehiculo Vehiculo;
        public Modelo Modelo;
        public Color Color;
    }
}
