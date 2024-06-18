using Microsoft.EntityFrameworkCore;
using Prueba1.Backend.BBDD;
using Prueba1.Backend.Competiciones;
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
        private Partido partidoActual;

        public MenuInGamePage(MiContexto contexto)
        {
            InitializeComponent();
            _contexto = contexto;
            CargarDatosPartido();
        }

        private void CargarDatosPartido()
        {
            var liga = _contexto.Ligas.Include(l => l.Equipos).ThenInclude(e => e.Partidos).FirstOrDefault();
            if (liga != null)
            {
                var jornadaActual = liga.EncontrarJornadaEquipoUsuario();
                if (jornadaActual != null)
                {
                    partidoActual = jornadaActual.Partidos.FirstOrDefault(p => p.Local.ControladoPorUsuario || p.Visitante.ControladoPorUsuario);
                    MostrarDatosPartido();
                }
            }
        }
        private void MostrarDatosPartido()
        {
            if (partidoActual != null)
            {
                // Asumiendo que tienes TextBlocks con los nombres x:Name="txtNombreLocal", "txtPosicionLocal", "txtValoracionLocal",
                // "txtNombreVisitante", "txtPosicionVisitante", "txtValoracionVisitante" en tu XAML
                // Aquí asignarías los valores. Por ejemplo:
                var equipoLocal = partidoActual.Local;
                var equipoVisitante = partidoActual.Visitante;

                // Encuentra los controles en el XAML y asigna los valores
                var txtNombreLocal = (TextBlock)this.FindName("txtNombreLocal");
                var txtPosicionLocal = (TextBlock)this.FindName("txtPosicionLocal");
                var txtValoracionLocal = (TextBlock)this.FindName("txtValoracionLocal");

                var txtNombreVisitante = (TextBlock)this.FindName("txtNombreVisitante");
                var txtPosicionVisitante = (TextBlock)this.FindName("txtPosicionVisitante");
                var txtValoracionVisitante = (TextBlock)this.FindName("txtValoracionVisitante");

                if (txtNombreLocal != null && txtPosicionLocal != null && txtValoracionLocal != null &&
                    txtNombreVisitante != null && txtPosicionVisitante != null && txtValoracionVisitante != null)
                {
                    txtNombreLocal.Text = equipoLocal.Nombre;
                    txtPosicionLocal.Text = $"Posición en la liga: {equipoLocal.Posicion}";
                    txtValoracionLocal.Text = $"Valoración media: {equipoLocal.ObtenerMediaMediaPlantilla}";

                    txtNombreVisitante.Text = equipoVisitante.Nombre;
                    txtPosicionVisitante.Text = $"Posición en la liga: {equipoVisitante.Posicion}";
                    txtValoracionVisitante.Text = $"Valoración media: {equipoVisitante.ObtenerMediaMediaPlantilla}";
                }
            }
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
          /*  GestionJugadores gestionJugadores = new GestionJugadores();
            Delantero prueba = gestionJugadores.GeneraDelantero();
            MessageBox.Show(prueba.ToString());*/
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
