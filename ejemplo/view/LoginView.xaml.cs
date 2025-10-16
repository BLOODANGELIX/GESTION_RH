using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ejemplo.view
{

    /// <summary>
    /// Lógica de interacción para LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {

        public LoginView()
        {
            InitializeComponent();
        }

        private void btn_Minimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btn_cerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el elemento seleccionado
            ComboBoxItem selectedItem = (ComboBoxItem)dept.SelectedItem;

            if (selectedItem != null && selectedItem.ToString().Equals("amin"))
            {

                // Obtener el texto visible (Content)
                string contentValue = selectedItem.Content.ToString();
                MessageBox.Show($"{contentValue}");
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún departamento.");
            }
        }
    }
}
