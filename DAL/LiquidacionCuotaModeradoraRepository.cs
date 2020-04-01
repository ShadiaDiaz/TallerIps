using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DAL
{
    public class LiquidacionCuotaModeradoraRepository
    {
         string ruta = "ips.txt";
         List<Liquidacion> liquidaciones;
        List<Paciente> pacientes;

        public LiquidacionCuotaModeradoraRepository()
        {
            liquidaciones = new List<Liquidacion>();
        }

        public void Guardar(List<Liquidacion> ListLiquidaciones)
        {
            File.Delete(ruta);
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escribir = new StreamWriter(file);
            foreach(var item in ListLiquidaciones)
            {
                escribir.WriteLine($"{item.Nombre};{item.Identificacion};{item.Salario};{item.TipoDeAfilacion};{item.ValorServicio};{item.NoLiquidacion};{item.CuotaModerada}");
                
                    
            }


            escribir.Close();
            file.Close();
        }


        public List<Liquidacion> Consultar()
        {
            liquidaciones = new List<Liquidacion>();
            string linea = string.Empty;
            FileStream sourceStream = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(sourceStream);
            while ((linea = reader.ReadLine()) != null)
            {
                Liquidacion liquidacion = new Liquidacion();
                char delimiter = ';';
                string[] matriz = linea.Split(delimiter);
                liquidacion.Nombre = matriz[0];
                liquidacion.Identificacion = matriz[1];
                liquidacion.Salario = Convert.ToDecimal(matriz[2]);
                liquidacion.TipoDeAfilacion = matriz[3];
                liquidacion.ValorServicio = Convert.ToDouble(matriz[4]);
                liquidacion.NoLiquidacion = Convert.ToInt32(matriz[5]);
                liquidacion.CuotaModerada = Convert.ToInt32(matriz[6]);
                liquidaciones.Add(liquidacion);

            }
            reader.Close();
            sourceStream.Close();
            return liquidaciones;
        }

        public static object Buscar(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public Liquidacion Buscar(string identificacion)
        {
            liquidaciones = Consultar();
            foreach(var item in liquidaciones)
            {
                if (item.Identificacion.Equals(identificacion))
                {
                    return item;
                }
                
            }
            return null;
        }

        public  void Modificar(Paciente paciente)
        {
            FileStream SourceStream = new FileStream(ruta, FileMode.Create);
            SourceStream.Close();
            foreach (var item in pacientes)
            {

                if (paciente.Identificacion != item.Identificacion)
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(item);
                }
            }
        }

        private void Guardar(Paciente item)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Liquidacion liquidacion)
        {
            liquidaciones.Remove(liquidacion);
            Guardar(liquidaciones);
        }
    }
}
