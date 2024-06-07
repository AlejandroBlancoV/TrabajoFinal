using System.IO;
using System.Windows.Media.Imaging;

namespace Prueba1.Backend.Utilidades
{
    public static class ImageUtils
    {
        public static BitmapImage ConvertirEscudoAImagen(byte[] escudo)
        {
            if (escudo == null || escudo.Length == 0) return null;

            var image = new BitmapImage();
            using (var mem = new MemoryStream(escudo))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }

}
