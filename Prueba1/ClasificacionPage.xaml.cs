using Prueba1.Backend.BBDD;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para ClasificacionPage.xaml
    /// </summary>
    public partial class ClasificacionPage : Page
    {
        private MiContexto _contexto;

        public ClasificacionPage(MiContexto contexto)
        {
            InitializeComponent();
            _contexto = contexto;
            CargarDatosClasificacion();
        }

        private void CargarDatosClasificacion()
        {
            var equipos = _contexto.Equipos
                                   .OrderBy(e => e.Posicion) 
                                   .ToList();

            lvClasificacion.ItemsSource = equipos;
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
    }
}
