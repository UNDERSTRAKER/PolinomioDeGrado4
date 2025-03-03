using System.Windows;
using System.Windows.Controls;
using WpfApp1.Model;

namespace Parcialnumero1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show("Bienvenido al programa de cálculo de ecuaciones.");
            MessageBox.Show("Proyecto realizado por Luis Felipe Padilla, Daniel Felipe Celis, Danny Camacho", "Bienvenida", MessageBoxButton.OK);
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            double[] coeficientes = new double[7];
            double[] coefBoxMiMa1 = new double[4];

            TextBox[] coefBoxes = { txtM, txtN, txtP, txtQ, txtR, txtS, txtT };
            TextBox[] coefBoxMiMa = { txtXMin, txtXMax, txtYMin, txtYMax };

            for (int i = 0; i < coefBoxes.Length; i++)
            {
                if (!double.TryParse(coefBoxes[i].Text, out coeficientes[i]))
                {
                    MessageBox.Show("Ingrese valores numéricos válidos en los coeficientes.");
                    return;
                }
            }
            for (int i = 0; i < coefBoxMiMa.Length; i++)
            {
                if (!double.TryParse(coefBoxMiMa[i].Text, out coefBoxMiMa1[i]))
                {
                    MessageBox.Show("Ingrese valores numéricos válidos en los rangos.");
                    return;
                }
            }

            Ecuacion ecuacion = new Ecuacion(coeficientes, coefBoxMiMa1);
            ecuacion.Calcular();


            dataGrid.ItemsSource = ecuacion.Resultados.Select((z, i) => new {

                X = ecuacion.ValoresX[i],
                Y = ecuacion.ValoresY[i],
                Z = z

            }).ToList();

            MessageBox.Show("Los cálculos han sido completados. Revisar la pestaña de Resultados");
        }
    }
}

