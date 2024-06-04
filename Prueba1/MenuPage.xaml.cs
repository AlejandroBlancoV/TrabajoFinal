using Prueba1.Backend.Gestion;
using Prueba1.Backend.Jugadores;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Prueba1.Backend.BBDD;

namespace Prueba1
{
    public partial class MenuPage : Page
    {
        private readonly MiContexto _contexto;
        public MenuPage(MiContexto contexto)
        {
            InitializeComponent();
            _contexto = contexto;
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
            GestionJugadores gestionJugadores = new GestionJugadores();
            Delantero prueba= gestionJugadores.GeneraDelantero();
            MessageBox.Show(prueba.ToString());
        }

        private void btnNuevaPartida_Click(object sender, RoutedEventArgs e)
        {
            // Navega a la página MenuInGamePage
            this.NavigationService.Navigate(new MenuInGamePage(_contexto));
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
