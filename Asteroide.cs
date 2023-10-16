using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1._1.B
{
    class Asteroide
    {
        public int Peso { get; set; }
        public int[] Metales { get; set; }

        private int cantMetales = Enum.GetValues(typeof(TipoMetales)).Length;
        private Random randy = new Random();

        public Asteroide(int peso)
        {
            Peso = peso;
            AñadirMetales(cantMetales);
        }     

        private void AñadirMetales(int cantMetales)
        {
            Metales = new int[cantMetales];
            int pesoMax = Peso;
            int pesoAsteroide;

            for (int i = 0; i < cantMetales; i++)
            {
                pesoAsteroide = CalcularPesoMetalAsteroide(pesoMax);
                Metales[i] = pesoAsteroide;

                if (i == (cantMetales - 1))
                    Metales[i] = pesoMax;

                pesoMax -= pesoAsteroide;
            }
        }

        private int CalcularPesoMetalAsteroide(int pesoMax)
        {
            return randy.Next(1, pesoMax);
        }
    }
}
