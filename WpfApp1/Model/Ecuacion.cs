using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfApp1.Model
{
    public class Ecuacion
    {
        public double[] Coeficientes { get; set; }
        public double[] CoefBoxMiMa { get; set; }

        public List<double> ValoresX { get; private set; } = new List<double>();  // creo una lista de valores X
        public List<double> Resultados { get; private set; } = new List<double>(); 

        public Ecuacion(double[] coeficientes, double[] coefBoxMiMa)
        {
            Coeficientes = coeficientes;
            CoefBoxMiMa = coefBoxMiMa;
        }

        public void Calcular() 
        {
            ValoresX.Clear(); // limpio la lista de valores X
            Resultados.Clear();

            double xMin = CoefBoxMiMa[0], xMax = CoefBoxMiMa[1];
            double yMin = CoefBoxMiMa[2], yMax = CoefBoxMiMa[3];
            double paso = 0.5;

            if (xMin >= xMax || yMin >= yMax)
            {
                MessageBox.Show("Los valores mínimos deben ser menores que los valores máximos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            for (double x = xMin; x <= xMax; x += paso)
            {
                for (double y = yMin; y <= yMax; y += paso)
                {
                    ValoresX.Add(x); // añado el resultado de x en la lista de valoresX

                    double ecu1 = Math.Cos(Coeficientes[0] * Math.Pow(x, 3));
                    double ecu2 = Math.Sin(Math.Pow(x, 4) / Coeficientes[1]);
                    double ecu3 = Coeficientes[2] * Math.Cos((Coeficientes[3] * x) + Math.Sin(Coeficientes[4] * y));
                    double ecu4 = Math.Sqrt((Math.Pow(x, 2) + Math.Pow(y, 2)) / (5 * x));
                    double ecu5 = Math.Sqrt((Coeficientes[5] * x) / y + Coeficientes[6]);

                    double resultado = ecu1 - ecu2 * ecu3 + ecu4 - ecu5;
                    Resultados.Add(resultado);
                }
            }
        }
    }
}
