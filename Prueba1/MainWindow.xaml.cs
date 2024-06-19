using System.Windows;
using System.Windows.Input;
using Prueba1.Backend.BBDD; 

namespace Prueba1
{
    public partial class MainWindow : Window
    {
        
        public static MiContexto Contexto { get; } = new MiContexto();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Frame_Loaded(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new MenuPage(Contexto));
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
            
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            
            Width = screenWidth;
            Height = screenHeight;
        }
    }
}
