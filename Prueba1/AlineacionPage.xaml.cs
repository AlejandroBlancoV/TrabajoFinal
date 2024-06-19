using Microsoft.EntityFrameworkCore;
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
using Prueba1.Backend.Equipos;
namespace Prueba1
{
    /// <summary>
    /// Lógica de interacción para AlineacionPage.xaml
    /// </summary>
    public partial class AlineacionPage : Page
    {
        private readonly MiContexto _contexto;
        public AlineacionPage(MiContexto contexto)
        {
            InitializeComponent();
            this._contexto = contexto;
            CargarDatosAlineacion();
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
            _contexto.SaveChanges();
            this.NavigationService.Navigate(new MenuInGamePage(_contexto));

        }

        private void CargarDatosPlantilla()
        {
            var equipoUsuario = _contexto.Equipos.FirstOrDefault(e => e.ControladoPorUsuario);
            
            if (equipoUsuario != null)
            {
                // Asumiendo que equipoUsuario.Jugadores ya contiene la lista completa de jugadores del equipo
                var jugadoresNoEnAlineacion = equipoUsuario.Jugadores
                                                           .Where(j => equipoUsuario.Alineacion == null || !equipoUsuario.Alineacion.Jugadores.Contains(j))
                                                           .ToList();

                // Asignar la lista filtrada al ListView de la plantilla
                lvPlantilla.ItemsSource = jugadoresNoEnAlineacion;
            }
        }

        private void CargarDatosAlineacion()
        {
            var equipoUsuario = _contexto.Equipos.FirstOrDefault(e => e.ControladoPorUsuario);
            var txtEscudo = (Image)this.FindName("imgEscudo");
            txtEscudo.Source = ImageUtils.ConvertirEscudoAImagen(equipoUsuario.Escudo);
            if (equipoUsuario != null)
            {
                // Convertir el array a List<Jugador> y luego a Jugador[]
                Jugador[] arrayJugadores = equipoUsuario.Jugadores.ToArray();

                // Crear un nuevo objeto Plantilla con el array de jugadores
                Plantilla plantillaConJugadores = new Plantilla(arrayJugadores);

                // Llamar al método OrdenarAlineacion, que ahora realiza la asignación internamente
                equipoUsuario.OrdenarAlineacion(plantillaConJugadores);

                if (equipoUsuario.Alineacion != null)
                {
                    // Asignar los jugadores de la alineación al ListView de la alineación
                    lvAlineacion.ItemsSource = equipoUsuario.Alineacion.Jugadores;
                }
            }
        }

        private void btnCambiar_Click(object sender, RoutedEventArgs e)
        {
            var equipoUsuario = _contexto.Equipos.FirstOrDefault(e => e.ControladoPorUsuario);
            if (equipoUsuario == null) return;

            Jugador jugadorPlantilla = lvPlantilla.SelectedItem as Jugador;
            Jugador jugadorAlineacion = lvAlineacion.SelectedItem as Jugador;

            if (jugadorPlantilla == null || jugadorAlineacion == null)
            {
                MessageBox.Show("Debes seleccionar un jugador de la plantilla y uno de la alineación para realizar el cambio.");
                return;
            }

            try
            {
                // Quitar el jugador de la alineación y agregar el nuevo jugador
                equipoUsuario.Alineacion.Jugadores.Remove(jugadorAlineacion);
                equipoUsuario.Alineacion.Jugadores.Add(jugadorPlantilla);

                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar el cambio: {ex.Message}");
                return;
            }

            // Ordenar los jugadores de la alineación por posición
            var jugadoresAlineacionOrdenados = equipoUsuario.Alineacion.Jugadores
                                                              .OrderBy(j => j.Posicion)
                                                              .ToList();

            // Ordenar los jugadores de la plantilla por posición
            var jugadoresNoEnAlineacionOrdenados = equipoUsuario.Jugadores
                                                                .Where(j => equipoUsuario.Alineacion == null || !equipoUsuario.Alineacion.Jugadores.Contains(j))
                                                                .OrderBy(j => j.Posicion)
                                                                .ToList();

            // Actualizar las vistas para reflejar los cambios y el ordenamiento
            lvAlineacion.ItemsSource = jugadoresAlineacionOrdenados;
            lvPlantilla.ItemsSource = jugadoresNoEnAlineacionOrdenados;
        }


    }
}

