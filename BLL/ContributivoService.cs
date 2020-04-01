using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
     public class ContributivoService : LiquidacionCuotaModeradoraService
    {
        List<Liquidacion> liquidacones = new List<Liquidacion>();

        public override double CalcularCoutaModeradora(Liquidacion liquidacion)
        {
            if (liquidacion.Salario < (980000 * 2))
            {
                return liquidacion.CuotaModerada = liquidacion.ValorServicio * 0.15;
            }
            else if((liquidacion.Salario>=(980000*2))&&((liquidacion.Salario<=(980000*5))))
            {
                return liquidacion.CuotaModerada = liquidacion.ValorServicio * 0.2;
            }
            else
            {
                return liquidacion.CuotaModerada = liquidacion.ValorServicio * 0.25;
            }
            
        }
    }
}
