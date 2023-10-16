using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1._1.B
{
    class Sistema
    {
        public string Nombre { get; set; }
        public List<Asteroide> Asteroides { get; set; }
       
        private Random randy = new Random();        
        private Array pesosAsteroides = Enum.GetValues(typeof(TamañoAsteroides));

        public Sistema(int cantidadAsteroides, int largoNombre)
        {          
            Nombre = GenerarNombreSistema(largoNombre);
            Asteroides = AñadirAsteroidesSistemas(cantidadAsteroides);
        }

        private List<Asteroide> AñadirAsteroidesSistemas(int cantAsteroides)
        {
            List<Asteroide> listaAsteroides = new List<Asteroide>();

            for (int i = 0; i < cantAsteroides; i++)
            {
                int peso = DeterminarPesoMaximoAsteroide();
                Asteroide asteroide = new Asteroide(peso);
                listaAsteroides.Add(asteroide);
            }

            return listaAsteroides;
        }

        private int DeterminarPesoMaximoAsteroide()
        {
            int index = randy.Next(0, pesosAsteroides.Length);
            return (int)pesosAsteroides.GetValue(index);
        }

        private string GenerarNombreSistema(int largoNombre)
        {            
            string nombre = "";
            string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";

            for (int i = 0; i < largoNombre; i++)
            {
                nombre += caracteres[this.randy.Next(0, caracteres.Length)];
            }

            return nombre;
        }

        public void GenerarReporteSistema()
        {
            int pesoTotal = 0;
            int[] totalMetalesMinados = new int[Enum.GetValues(typeof(TipoMetales)).Length];

            Console.WriteLine();
            Console.WriteLine($"En el sistema {Nombre} se minaron {Asteroides.Count} asteroides");
            Console.WriteLine();           

            foreach (Asteroide asteroide in Asteroides)
            {
                pesoTotal += asteroide.Peso;

                for (int i = 0; i < asteroide.Metales.Length; i++)
                {
                    totalMetalesMinados[i] += asteroide.Metales[i];
                }
            }

            for (int i = 0; i < totalMetalesMinados.Length; i++)
            {
                string metal = Enum.GetName(typeof(TipoMetales), i);
                Console.WriteLine($"{metal}: {totalMetalesMinados[i]} kg");
            }

            Console.WriteLine($"Peso total minado: {pesoTotal} kg");
            Console.WriteLine();
        }
    }
}
