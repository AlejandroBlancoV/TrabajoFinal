using Prueba1.Backend.BBDD;
using Prueba1.Backend.Gestion;
using Prueba1.Backend.Jugadores;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Prueba1
{
    /// <summary>
    /// Lógica de interacción para MenuInGamePage.xaml
    /// </summary>
    public partial class MenuInGamePage : Page
    {
        private readonly MiContexto _contexto;
        public MenuInGamePage(MiContexto contexto)
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
            Delantero prueba = gestionJugadores.GeneraDelantero();
            MessageBox.Show(prueba.ToString());
        }

        

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnPlantilla_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PlantillaPage(_contexto));
        }
    }
}
