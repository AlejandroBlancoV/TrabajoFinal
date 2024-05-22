using System.Windows;
using System.Windows.Input;

namespace Prueba1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Frame_Loaded(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new MenuPage());
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Obtener el tamaño de la pantalla
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            // Establecer el tamaño de la ventana
            Width = screenWidth;
            Height = screenHeight;
        }
    }
}
