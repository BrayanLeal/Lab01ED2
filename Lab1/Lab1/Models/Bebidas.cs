using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Models
{
    public class Bebidas
    {
        /*
         * Nombre (único) • Sabor • Volumen • Precio • Casa productora
         */
        public String Nombre { get; set; }
        public String Sabor { get; set; }
        public int Volumen { get; set; }
        public float Precio { get; set; }
        public String Casa { get; set; }
    }
}
