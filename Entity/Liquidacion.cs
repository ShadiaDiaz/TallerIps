using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
     public class Liquidacion : Paciente
    {
        public int NoLiquidacion { get; set; }
        public double CuotaModerada { get; set; }
        public double ValorServicio { get; set; }

        public Liquidacion()
        {
        }
    }
}
