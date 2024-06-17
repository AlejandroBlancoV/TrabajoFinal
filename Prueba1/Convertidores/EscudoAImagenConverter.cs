using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Prueba1.Backend.Utilidades;

namespace Prueba1.Convertidores
{
    public class EscudoAImagenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte[] escudo = value as byte[];
            return ImageUtils.ConvertirEscudoAImagen(escudo);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
