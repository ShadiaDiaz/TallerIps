using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BLL
{
     public class SubsidiadoService : LiquidacionCuotaModeradoraService
    {

        List<Liquidacion> liquidaciones = new List<Liquidacion>();

        public override double CalcularCoutaModeradora(Liquidacion liquidacion)
        {
             if(liquidacion.ValorServicio*0.5 >200000)
            {
             
                return liquidacion.CuotaModerada = 200000;
            }
            else
            {
                return liquidacion.CuotaModerada = liquidacion.ValorServicio * 0.05;
            }
        }
    }
}
