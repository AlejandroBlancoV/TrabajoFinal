using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba1.Backend.Gestion
{
    internal class GestionPartidas
    {
        GestionLigas gestionLigas = new GestionLigas();

        public void crearPartida()
        {
        gestionLigas.CrearLiga();
        }
    }
}
