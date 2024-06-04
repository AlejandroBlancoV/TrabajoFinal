using Prueba1.Backend.BBDD;
using Prueba1.Backend.Gestion;
using Prueba1.Backend.Jugadores;
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
    /// Lógica de interacción para PlantillaPage.xaml
    /// </summary>
    public partial class PlantillaPage : Page
    {
        private readonly MiContexto _contexto;
        public PlantillaPage(Backend.BBDD.MiContexto _contexto)
        {
            InitializeComponent();
            this._contexto = _contexto;
            GestionJugadores gestionJugadores = new GestionJugadores();
            Delantero delantero = gestionJugadores.GeneraDelantero();
            lvJugadores.Items.Add(delantero);
            Medio medio = gestionJugadores.GeneraMedio();
            lvJugadores.Items.Add(medio);
            Defensor defensor = gestionJugadores.GeneraDefensa();
            lvJugadores.Items.Add(defensor);
            Portero portero = gestionJugadores.GeneraPortero();
            lvJugadores.Items.Add(portero);
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

    }
}
