

using Prueba1.Backend.Equipos;
using System.Windows.Media.Imaging;

namespace Prueba1.Backend.Gestion
{
    internal class GestionEquipos
    {
        GestionJugadores gestionJugadores = new GestionJugadores();

        public Equipo CrearEquipo(String nombre, BitmapImage image, int presupuesto, bool controladoPorUsuario)
        {
            Plantilla plantilla = gestionJugadores.GenerarPlantillaPorDefecto();
            Alineacion alineacion = gestionJugadores.OrdenarAlineacion(plantilla);
            Equipo equipo = new Equipo(nombre, Utilidades.ImageUtils.ConvertirImagenAEscudo(image), alineacion, plantilla, presupuesto, controladoPorUsuario);
            return equipo;
        }
    }
}
