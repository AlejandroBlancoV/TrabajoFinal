using Prueba1.Backend.BBDD;
using Prueba1.Backend.Competiciones;
using Prueba1.Backend.Equipos;

namespace Prueba1.Backend.Gestion
{
    internal class GestionLigas
    {
        GestionEquipos gestionEquipos;
        MiContexto contexto;
        public GestionLigas(MiContexto _contexto)
        {
            this.gestionEquipos = new GestionEquipos(_contexto);
            this.contexto = _contexto;
        }

        public Liga CrearLiga()
        {
            Liga liga = new Liga();
            liga.Nombre = "La Liga";
            List<Equipo> equipos = gestionEquipos.GenerarEquiposLiga();
            liga.Equipos = equipos;
            return liga;
        }
    }
}
