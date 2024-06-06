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
            this.Loaded += (s, e) => calcularValoresPlantilla();
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
        private void calcularValoresPlantilla()
        {
            double totalPlantilla = 0;
            double totalSalarios = 0;
            int totalEdad = 0;
            int numPorteros = 0;
            int numDefensas = 0;
            int numMedios = 0;
            int numDelanteros = 0;

            foreach (Jugador jugador in lvJugadores.Items)
            {
                totalPlantilla += jugador.Valor; // Asume que la clase Jugador tiene una propiedad Valor
                totalSalarios += jugador.Salario; // Asume que la clase Jugador tiene una propiedad Salario
                totalEdad += jugador.Edad;

                switch (jugador.Posicion)
                {
                    case Posicion.Portero:
                        numPorteros++;
                        break;
                    case Posicion.Defensa:
                        numDefensas++;
                        break;
                    case Posicion.Medio:
                        numMedios++;
                        break;
                    case Posicion.Delantero:
                        numDelanteros++;
                        break;
                }
            }

            double edadMedia = totalEdad / (double)lvJugadores.Items.Count;

            txtTotalPlantilla.Text = $"Valor Plantilla: {totalPlantilla.ToString("N0")}€";
            txtTotalSalarios.Text = $"Total Salarios: {totalSalarios.ToString("N0")}€";
            txtEdadMedia.Text = $"Edad Media: {edadMedia.ToString("N1")}";
            txtNumPorteros.Text = $"Nº Porteros: {numPorteros}";
            txtNumDefensas.Text = $"Nº Defensas: {numDefensas}";
            txtNumMedios.Text = $"Nº Medios: {numMedios}";
            txtNumDelanteros.Text = $"Nº Delanteros: {numDelanteros}";
        }

    }
}
