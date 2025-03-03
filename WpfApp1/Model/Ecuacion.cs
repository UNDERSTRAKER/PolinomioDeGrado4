using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfApp1.Model
{
    public class Ecuacion
    {
        public double[] Coeficientes { get; set; }
        public double[] CoefBoxMiMa { get; set; }

        public List<double> ValoresX { get; private set; } = new List<double>();
        public List<double> ValoresY { get; private set; } = new List<double>();

        public List<double> Resultados { get; private set; } = new List<double>();

        public Ecuacion(double[] coeficientes, double[] coefBoxMiMa)
        {
            Coeficientes = coeficientes;
            CoefBoxMiMa = coefBoxMiMa;
        }

        public List<double> Calcular()
        {
            ValoresY.Clear();
            ValoresX.Clear();
            Resultados.Clear();

            double xMin = CoefBoxMiMa[0], xMax = CoefBoxMiMa[1];
            double yMin = CoefBoxMiMa[2], yMax = CoefBoxMiMa[3];
            double paso = 0.5;

            if (xMin >= xMax || yMin >= yMax)
            {
                MessageBox.Show("Los valores mínimos deben ser menores que los valores máximos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return Resultados;
            }

            for (double x = xMin; x <= xMax; x += paso)
            {
                for (double y = yMin; y <= yMax; y += paso)
                {
                    ValoresX.Add(x);
                    ValoresY.Add(y);

                    double ecu1 = Math.Cos(Coeficientes[0] * Math.Pow(x, 3));
                    double ecu2 = Math.Sin(Math.Pow(x, 4) / Coeficientes[1]);
                    double ecu3 = Coeficientes[2] * Math.Cos((Coeficientes[3] * x) + Math.Sin(Coeficientes[4] * y));
                    double ecu4 = (5 * x) > 0 ? Math.Sqrt((Math.Pow(x, 2) + Math.Pow(y, 2)) / (5 * x)) : 0;
                    double ecu5 = ((Coeficientes[5] * x) / y + Coeficientes[6]) >= 0 ?
                                  Math.Sqrt((Coeficientes[5] * x) / y + Coeficientes[6]) : 0;

                    double resultado = ecu1 - ecu2 * ecu3 + ecu4 - ecu5;
                    Resultados.Add(resultado);
                }
            }
            return Resultados;
        }
    }
}
