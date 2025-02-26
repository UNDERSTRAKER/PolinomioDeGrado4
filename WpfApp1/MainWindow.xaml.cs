using System.Windows;
using System.Windows.Controls;
using WpfApp1.Model;

namespace Parcialnumero1
{
    public partial class MainWindow : Window
    {


        public class ResultData
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }
        }


        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {

            

            TextBox[] coefBox = { txtM, txtN, txtP, txtQ, txtR, txtS, txtT };
            double[] coeficientes = new double[7];
            TextBox[] coefBoxMiMa = { txtXMin, txtXMax, txtYMin, txtYMax };
            i = 8;
            
            for (int i = 0; i < coefBox.Length; i++)
            {
                if (!double.TryParse(coefBox[i].Text, out coeficientes[i]))
                {
                    MessageBox.Show("Ingrese valores numéricos válidos en todos los campos.");
                    return;
                }
            }

            Ecuacion ecuacion = new Ecuacion(coeficientes);

            MessageBox.Show($"El resultado de la ecuación es: {ecuacion.Calcular()}");
        }

    }

}
