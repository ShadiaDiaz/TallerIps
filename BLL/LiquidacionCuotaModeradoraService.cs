using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;



namespace BLL
{
    public   abstract class LiquidacionCuotaModeradoraService
    {
        LiquidacionCuotaModeradoraRepository liquidacionRepository;
        Liquidacion liquidacion;
        List<Liquidacion> liquidaciones;

        public LiquidacionCuotaModeradoraService()
        {
            liquidacionRepository = new LiquidacionCuotaModeradoraRepository();
            LeerLista();
        }

        public Liquidacion Buscar(string id)
        {
            liquidacion = new Liquidacion();
            liquidacion = liquidacionRepository.Buscar(id);
            if (liquidacion == null)
            {
                return null;
            }
            return liquidacion;

        }


        public List<Liquidacion> LeerLista()
        {
            liquidaciones = liquidacionRepository.Consultar();
            return liquidaciones;
        }



        public void AñadirPaciente(Liquidacion liquidacion)
        {
            liquidaciones.Add(liquidacion);
            liquidacionRepository.Guardar(liquidaciones);
        }

        //public static string Modificar( Paciente paciente) 
        //{
        //    if (LiquidacionCuotaModeradoraRepository.Buscar(paciente) == null)
        //    {

        //        return $"La persona con identificacion no se encuentra registrada";

        //    }
        //    else
        //    {
        //        LiquidacionCuotaModeradoraRepository.Modificar(paciente);
        //        return $"La persona {paciente.Identificacion} fue Modificada";
        //    }

        //}
        
        public void Eliminar(Liquidacion liquidacion)
        {
            liquidacionRepository.Eliminar(liquidacion);
        }

        public abstract double CalcularCoutaModeradora(Liquidacion liquidacion);
    }
}
