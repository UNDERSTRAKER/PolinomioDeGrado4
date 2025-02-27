using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Model
{
    public class Ecuacion
    {
        public double[] Coeficientes { get; set; }
        public double[] CoefBoxMiMa { get; set; }


        public Ecuacion(double[] coeficientes, double[] coefBoxMiMa1)
        {
            Coeficientes = coeficientes;
            CoefBoxMiMa = coefBoxMiMa1;

        }

        public List<double> Calcular()
        {
            List<double> resultados = new List<double>();

            double Xmin = CoefBoxMiMa[0];
            double Xmax = CoefBoxMiMa[1];
            double Ymin = CoefBoxMiMa[2];
            double Ymax = CoefBoxMiMa[3];
            double stepXY0 = 0.5;
            double stepXY1 = -0.5;
            if (Xmax > Xmin)
            {
                for (double x = Xmin; x <= Xmax; x += stepXY0)
                {
                    for (double y = Ymin; y <= Ymax; y += stepXY0)
                    {
                        double ecu1 = Math.Cos(Coeficientes[0] * Math.Pow(CoefBoxMiMa[0], 3));
                        double ecu2 = Math.Sin(Math.Pow(CoefBoxMiMa[0], 4) / Coeficientes[1]);
                        double ecu3 = Coeficientes[2] * Math.Cos((Coeficientes[3] * CoefBoxMiMa[0]) + Math.Sin(Coeficientes[4] * CoefBoxMiMa[2]));
                        double ecu4 = Math.Sqrt((Math.Pow(CoefBoxMiMa[0], 2) + Math.Pow(CoefBoxMiMa[2], 2)) / (5 * CoefBoxMiMa[0]));
                        double ecu5 = Math.Sqrt((Coeficientes[5] * CoefBoxMiMa[0]) / CoefBoxMiMa[2] + Coeficientes[6]);
                        double resultado = ecu1 - ecu2 * ecu3 + ecu4 - ecu5;
                        resultados.Add(resultado);
                    }                   
                }
                return resultados;
            }
            else
            {
                for (double x = Xmin; x >= Xmax; x += stepXY1)
                {
                    for (double y = Ymin; y >= Ymax; y += stepXY1)
                    {
                        double ecu1 = Math.Cos(Coeficientes[0] * Math.Pow(CoefBoxMiMa[0], 3));
                        double ecu2 = Math.Sin(Math.Pow(y, 4) / Coeficientes[1]);
                        double ecu3 = Coeficientes[2] * Math.Cos((Coeficientes[3] * CoefBoxMiMa[0]) + Math.Sin(Coeficientes[4] * y));
                        double ecu4 = Math.Sqrt((Math.Pow(CoefBoxMiMa[0], 2) + Math.Pow(y, 2)) / (5 * CoefBoxMiMa[0]));
                        double ecu5 = Math.Sqrt((Coeficientes[5] * CoefBoxMiMa[0]) / (y + Coeficientes[6]));
                        double resultado = ecu1 - ecu2 * ecu3 + ecu4 - ecu5;
                        resultados.Add(resultado);                      
                    }                  
                }
                return resultados;
            }

        }
    }
}        
        