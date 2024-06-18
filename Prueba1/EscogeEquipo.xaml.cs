using Microsoft.EntityFrameworkCore;
using Prueba1.Backend.BBDD;
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
    /// Lógica de interacción para EscogeEquipo.xaml
    /// </summary>
    public partial class EscogeEquipo : Page
    {
        private MiContexto _contexto;

        public EscogeEquipo(MiContexto contexto)
        {
            InitializeComponent();
            _contexto = contexto;
            CargarEquiposAsync();
        }

        private async void CargarEquiposAsync()
        {
            try
            {
                var equiposConMedia = await _contexto.Equipos.Include(e => e.Jugadores).Select(equipo => new
                {
                    EquipoId = equipo.Id, // Incluye el Id del equipo aquí
                    Equipo = equipo,
                    ValoracionMedia = (int)Math.Round(equipo.Jugadores.Any() ? equipo.Jugadores.Average(j => j.Media) : 0)
                }).ToListAsync();

                lvEquipos.ItemsSource = equiposConMedia;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar equipos: {ex.Message}");
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

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuInGamePage(_contexto));

        }

        private async void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            if (lvEquipos.SelectedItem != null)
            {
                dynamic equipoSeleccionado = lvEquipos.SelectedItem;
                int equipoId = equipoSeleccionado.EquipoId;
                var equipo = await _contexto.Equipos.FindAsync(equipoId);
                if (equipo != null)
                {
                    equipo.ControladoPorUsuario = true;
                    equipo.Presupuesto = 50000000;
                    await _contexto.SaveChangesAsync(); 
                    MessageBox.Show($"El equipo {equipo.Nombre} ha sido seleccionado como controlado por el usuario.");
                    this.NavigationService.Navigate(new MenuInGamePage(_contexto));
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un equipo de la lista.");
            }
        }

    }
}
