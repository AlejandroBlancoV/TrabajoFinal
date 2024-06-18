using Prueba1.Backend.BBDD;
namespace Prueba1.Backend.Gestion
{
    internal class GestionPartidas
    {
        GestionLigas gestionLigas;
        MiContexto contexto;

        public GestionPartidas(MiContexto _contexto)
        {
            this.gestionLigas = new GestionLigas(_contexto);
            this.contexto = _contexto;
        }

        public void crearPartida()
        {
        gestionLigas.CrearLiga();
        }
    }
}
