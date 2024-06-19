using Microsoft.EntityFrameworkCore;
using Prueba1.Backend.BBDD;
using Prueba1.Backend.Competiciones;
using Prueba1.Backend.Equipos;
using Prueba1.Backend.Gestion;
using Prueba1.Backend.Jugadores;
using Prueba1.Backend.Utilidades;
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
            
            var equipoUsuario = _contexto.Equipos.FirstOrDefault(e => e.ControladoPorUsuario);
            if (equipoUsuario == null)
            {
                MessageBox.Show("No se ha encontrado el equipo del usuario.");
                return;
            }

           
            var ligaDelEquipo = _contexto.Ligas.Include(l => l.Calendario)
                                                .ThenInclude(c => c.Jornadas)
                                                .ThenInclude(j => j.Partidos)
                                                .FirstOrDefault(l => l.Equipos.Any(e => e.Id == equipoUsuario.Id));

            if (ligaDelEquipo == null || ligaDelEquipo.Calendario == null)
            {
                MessageBox.Show("No se ha encontrado una liga o calendario para el equipo del usuario.");
                return;
            }

            
            var jornadaActual = ligaDelEquipo.Calendario.Jornadas
                .FirstOrDefault(j => j.Partidos.Any(p => !p.Jugado && (p.LocalId == equipoUsuario.Id || p.VisitanteId == equipoUsuario.Id)));

            if (jornadaActual == null)
            {
                MessageBox.Show("No se ha encontrado una jornada actual para el equipo del usuario.");
                return;
            }

            
            partidoActual = jornadaActual.Partidos.FirstOrDefault(p => !p.Jugado && (p.LocalId == equipoUsuario.Id || p.VisitanteId == equipoUsuario.Id));
            if (partidoActual == null)
            {
                MessageBox.Show("No se ha encontrado un partido para el equipo del usuario en la jornada actual.");
                return;
            }

            
            MostrarDatosPartido();
        }



        private void MostrarDatosPartido()
        {
            if (partidoActual != null)
            {
               
                var equipoLocal = partidoActual.Local;
                var equipoVisitante = partidoActual.Visitante;

                
                var txtNombreLocal = (TextBlock)this.FindName("txtNombreLocal");
                var txtPosicionLocal = (TextBlock)this.FindName("txtPosicionLocal");
                var txtValoracionLocal = (TextBlock)this.FindName("txtValoracionLocal");
                var txtEscudoLocal = (Image)this.FindName("imgEscudoLocal");

                var txtNombreVisitante = (TextBlock)this.FindName("txtNombreVisitante");
                var txtPosicionVisitante = (TextBlock)this.FindName("txtPosicionVisitante");
                var txtValoracionVisitante = (TextBlock)this.FindName("txtValoracionVisitante");
                var txtEscudoVisitante = (Image)this.FindName("imgEscudoVisitante");

                if (txtNombreLocal != null && txtPosicionLocal != null && txtValoracionLocal != null &&
                    txtNombreVisitante != null && txtPosicionVisitante != null && txtValoracionVisitante != null)
                {
                    int ValoracionMediaLocal = (int)Math.Round(equipoLocal.Jugadores.Any() ? equipoLocal.Jugadores.Average(j => j.Media) : 0);
                    txtNombreLocal.Text = equipoLocal.Nombre;
                    txtPosicionLocal.Text = $"Posición en la liga: {equipoLocal.Posicion}";
                    txtValoracionLocal.Text = $"Valoración media: {ValoracionMediaLocal}";
                    txtEscudoLocal.Source = ImageUtils.ConvertirEscudoAImagen(equipoLocal.Escudo);

                    int ValoracionMediaVisitante = (int)Math.Round(equipoVisitante.Jugadores.Any() ? equipoVisitante.Jugadores.Average(j => j.Media) : 0);
                    txtNombreVisitante.Text = equipoVisitante.Nombre;
                    txtPosicionVisitante.Text = $"Posición en la liga: {equipoVisitante.Posicion}";
                    txtValoracionVisitante.Text = $"Valoración media: {ValoracionMediaVisitante}";
                    txtEscudoVisitante.Source = ImageUtils.ConvertirEscudoAImagen(equipoVisitante.Escudo);
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

        private void btnAlineacion_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AlineacionPage(_contexto));
        }

        private void btnFichajes_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new FichajesPage(_contexto));
        }

        private void btnClasificacion_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ClasificacionPage(_contexto));
        }
    }
}
