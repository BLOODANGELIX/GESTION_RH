using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ejemplo.view;

namespace ejemplo
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    ///
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var LoginView = new LoginView();
            LoginView.Show(); //show para mostrar la ventana
            LoginView.IsVisibleChanged += (s, ev) =>
            {
                if (LoginView.IsVisible == false && LoginView.IsLoaded)
                {
                    var mainView = new MainWindow();
                    mainView.Show();
                    LoginView.Close();
                }
            };
        }
    }
}
