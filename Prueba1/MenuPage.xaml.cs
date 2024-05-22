using Prueba1.Backend.CSV;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Prueba1
{
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void Page_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Window.GetWindow(this).DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnContinuar_Click(object sender, RoutedEventArgs e)
        {
            GestionNombres gestionNombres = new GestionNombres();
            String nombre = gestionNombres.GenerarNombreAleatorio();
            MessageBox.Show(nombre);
        }

        private void btnNuevaPartida_Click(object sender, RoutedEventArgs e)
        {
            // Acción para nueva partida
        }

        private void btnConfiguracion_Click(object sender, RoutedEventArgs e)
        {
            // Acción para configuración
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
