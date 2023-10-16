using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1._1.B
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcion = "1";
            Sistema sistema;
            Random randy = new Random();

            Console.WriteLine("Bienvenido astronauta!");

            while (opcion == "1")
            {
                sistema = new Sistema(randy.Next(1, 10), 6);
                sistema.GenerarReporteSistema();

                Console.WriteLine("Qué desea hacer? (1 Para ingresar a otro sistema, otra tecla para salir)");
                opcion = Console.ReadLine();
            }            
        }
    }
}
