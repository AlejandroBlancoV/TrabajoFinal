using Prueba1.Backend.Competiciones;
using Prueba1.Backend.Equipos;

namespace Prueba1.Backend.Gestion
{
    internal class GestionLigas
    {
        GestionEquipos gestionEquipos = new GestionEquipos();

        public Liga CrearLiga()
        {
            List<Equipo> equipos = gestionEquipos.GenerarEquiposLiga();
            Liga liga = new Liga("La Liga", equipos);
            return liga;
        }
    }
}
