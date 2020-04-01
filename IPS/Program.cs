using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Entity;

namespace IpsProg

{
    class Program
    {
        static int op;
        static Liquidacion liquidacion;
        static LiquidacionCuotaModeradoraService liquidacionService;
        static List<Liquidacion> liquidaciones;
        static void Main(string[] args)
        {
            do
            {
                Menu();
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:Registrar();
                        break;
                    case 2:ListaDePaciente();
                        break;
                    case 3: Eliminar();
                        break;
                    case 4:BuscarPaciente();
                        break;
                    case 5: 
                        break;
                    case 6: op = 6;
                        break;
                    default: Console.WriteLine("NO tomo ninguna opcion disponible vuelva a intentarlo plis");
                        break;
                        
                }

            } while (op!=6);
            Console.ReadKey();
        }


        static public void Menu()
        {
            Console.Clear();
            Console.WriteLine("1-> Ingresar  datos del Paciente");
            Console.WriteLine("2-> Listado de pacientes");
            Console.WriteLine("3-> Eliminar a un Paciente");
            Console.WriteLine("4-> Buscar Un paciente");
            Console.WriteLine("5-> Modificar Datos DEl paciente");
            Console.WriteLine("6-> Salir");

            
        }

        static public void Guardar( Liquidacion liquidacion,string id)
        {
            liquidaciones = liquidacionService.LeerLista();
            liquidacion.Identificacion = id;
            Console.WriteLine("Nombre Del Paciente : ");
            liquidacion.Nombre = Console.ReadLine();
            Console.WriteLine("Salario Del Paciente: ");
            liquidacion.Salario = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Valor Del servicio:");
            liquidacion.ValorServicio = Convert.ToInt32(Console.ReadLine());
            liquidacionService.CalcularCoutaModeradora(liquidacion);
            liquidacionService.AñadirPaciente(liquidacion);
            Console.WriteLine("se ha resgistrado con exito");
            Console.ReadKey();
        }

        static public void Registrar()
        {
            string identificacion;
            liquidacion = new Liquidacion();
            Console.Clear();
            Console.WriteLine("Identificacion del paciente: ");
            identificacion = Console.ReadLine();
            Console.WriteLine("ingrese que tipo de afilacion es subsidiado --- contributivo");
            liquidacion.TipoDeAfilacion = Console.ReadLine().ToUpper();
            if (liquidacion.TipoDeAfilacion.Equals("SUBSIDIADO")) { 
                liquidacionService = new SubsidiadoService();
            }
            else if (liquidacion.TipoDeAfilacion.Equals("CONTRIBUTIVO")) { 
                liquidacionService = new ContributivoService();
            }
            if  ((liquidacionService.Buscar(identificacion)) == null) { 
                Guardar(liquidacion, identificacion);
            }
            else
            {
                Console.WriteLine("ya se encuentra registrado");
                Console.ReadKey();
            }

        }


        static public void Eliminar()
        {
            liquidacion = new Liquidacion();
            Console.Clear();
            Console.WriteLine("Ingresar la Identificacion del paciente que desea eliminar:");
            liquidacionService = new SubsidiadoService();
            liquidacion = liquidacionService.Buscar(Console.ReadLine());
            if (liquidacion != null)
            {
                liquidacionService.Eliminar(liquidacion);
                Console.WriteLine("se ha eliminado con exito");

            }
            else
            {
                Console.WriteLine("no se encuentra el paciente indicado");
                Console.ReadKey();
            }
        }


        static public void ListaDePaciente()
        {
            liquidacionService = new SubsidiadoService();
            liquidaciones = liquidacionService.LeerLista();
            Console.Clear();
            Console.WriteLine(" Lista De Pacientes  ");
            foreach(var item in liquidaciones)
            {
                Console.WriteLine($"Nombre :{item.Nombre}");
                Console.WriteLine($"Identificacion:{item.Identificacion}");
                Console.WriteLine($"Salario:{item.Salario}");
                Console.WriteLine($"Tipo de afiliacion:{item.Salario}");
                Console.WriteLine($"Numero de Liquidacion:{item.NoLiquidacion}");
                Console.WriteLine($"Valor de Servicio:{item.ValorServicio}");
                Console.WriteLine($"Cuota moderadora:{item.CuotaModerada}");
                Console.WriteLine("--------------//--------------------------//");
            }
            Console.ReadKey();
        }

       

        static public void BuscarPaciente()
        {
            string id;
            liquidacionService = new SubsidiadoService();
            liquidaciones = liquidacionService.LeerLista();
            Console.Clear();
            Console.WriteLine("digite la identificacion del paciente que desea buscar: ");
            id = Console.ReadLine();
            foreach(var item in liquidaciones)
            {
                if (item.Identificacion.Equals(id))
                {
                    Console.WriteLine($"Nombre :{item.Nombre}");
                    Console.WriteLine($"Identificacion:{item.Identificacion}");
                    Console.WriteLine($"Salario:{item.Salario}");
                    Console.WriteLine($"Tipo DE Afiliacion:{item.Salario}");
                    Console.WriteLine($"Numero de Liquidacion:{item.NoLiquidacion}");
                    Console.WriteLine($"Valor de Servicio:{item.ValorServicio}");
                    Console.WriteLine($"Cuota moderadora:{item.CuotaModerada}");
                }
                Console.ReadKey();
            }

        }



        


       
    }
}
