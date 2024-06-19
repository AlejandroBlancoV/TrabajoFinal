using Prueba1.Backend.BBDD;
using Prueba1.Backend.Jugadores;
using Prueba1.Backend.Utilidades;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prueba1
{
    /// <summary>
    /// Lógica de interacción para FichajesPage.xaml
    /// </summary>
    public partial class FichajesPage : Page
    {
        private readonly MiContexto _contexto;
        public FichajesPage(MiContexto contexto)
        {
            InitializeComponent();
            this._contexto = contexto;
            CargarDatosPlantilla();
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

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuInGamePage(_contexto));

        }

        private void CargarDatosPlantilla()
        {
            // Suponiendo que tienes un método en _contexto que te devuelve la lista de jugadores del equipo del usuario
            var equipoUsuario = _contexto.Equipos.FirstOrDefault(e => e.ControladoPorUsuario);
            var txtEscudo = (Image)this.FindName("imgEscudo");
            txtEscudo.Source = ImageUtils.ConvertirEscudoAImagen(equipoUsuario.Escudo);

            
            var jugadoresDisponibles = _contexto.Jugadores
                                                .Where(j => j.EquipoId != equipoUsuario.Id)
                                                .OrderBy(j => j.Posicion)
                                                .ThenByDescending(j => j.Media)
                                                .ToList();

            // Actualizar el ListView con los jugadores disponibles
            lvJugadores.ItemsSource = jugadoresDisponibles;
        }

      
    }
}
