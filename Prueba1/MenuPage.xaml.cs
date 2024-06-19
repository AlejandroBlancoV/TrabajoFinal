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
        GestionPartidas gestionPartidas;
        public MenuPage(MiContexto contexto)
        {
            InitializeComponent();
            _contexto = contexto;
            gestionPartidas = new GestionPartidas(_contexto);
            
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
            this.NavigationService.Navigate(new MenuInGamePage(_contexto));
        }

        private void btnNuevaPartida_Click(object sender, RoutedEventArgs e)
        {

            LimpiarDatos(_contexto);
            gestionPartidas.crearPartida();
            _contexto.SaveChanges();
            this.NavigationService.Navigate(new EscogeEquipo(_contexto));
        }

        private void btnConfiguracion_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        public void LimpiarDatos(MiContexto contexto)
        {
            contexto.Jugadas.RemoveRange(contexto.Jugadas);
            contexto.Resultados.RemoveRange(contexto.Resultados);
            contexto.Partidos.RemoveRange(contexto.Partidos);
            contexto.Jornadas.RemoveRange(contexto.Jornadas);
            contexto.Calendarios.RemoveRange(contexto.Calendarios);
            contexto.Ligas.RemoveRange(contexto.Ligas);

            
            
            contexto.Jugadores.RemoveRange(contexto.Jugadores);
            contexto.Plantillas.RemoveRange(contexto.Plantillas); 
            contexto.Equipos.RemoveRange(contexto.Equipos);
            contexto.Alineaciones.RemoveRange(contexto.Alineaciones); 

            contexto.SaveChanges();
        }


    }
}
