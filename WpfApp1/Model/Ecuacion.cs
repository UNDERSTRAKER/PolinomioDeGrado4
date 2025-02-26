using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Ecuacion
    {
        public double[] Coeficientes { get; set; }

        public Ecuacion(double[] coeficientes)
        {
            Coeficientes = coeficientes;
        }

        public double Calcular()
        {
            int x = 1;
            int y = 1;

            double ecu1 = Math.Cos(Coeficientes[0] * Math.Pow(x, 3));
            double ecu2 = Math.Sin(Math.Pow(y, 4) / Coeficientes[1]);
            double ecu3 = Coeficientes[2] * Math.Cos((Coeficientes[3] * x) + Math.Sin(Coeficientes[4] * y));
            double ecu4 = Math.Sqrt((Math.Pow(x, 2) + Math.Pow(y, 2)) / (5 * x));
            double ecu5 = Math.Sqrt((Coeficientes[5] * x) / (y + Coeficientes[6]));
            return ecu1 - ecu2 * ecu3 + ecu4 - ecu5;
        }
    }
}
