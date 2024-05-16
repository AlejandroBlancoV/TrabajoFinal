using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Controls;

namespace Prueba1.Backend
{
     class Portero : Jugador
    {
        public static int media;

        public Portero(int idJugador, int idEquipo, string nombre, string apellido, int edad, int defensa, int pase, int fisico, int regate, int disparo, int paradas)
            : base( idJugador,  idEquipo,  nombre,  apellido,  edad,  Posicion.Portero,  media,  defensa,  pase,  fisico,  regate,  disparo,  paradas)
        {
            media = CalculaMedia(defensa, pase, fisico, regate, disparo, paradas);
            Valor = CalculaValor(media, edad);
            Media= media;
        }

        private int CalculaMedia(int defensa, int pase, int fisico, int regate, int disparo, int paradas)
        {
            int noventa = (paradas * 90) / 100;
            int resto = (defensa + pase + fisico + regate + disparo) / 5;
            int diez = (resto * 10) / 100;
            return noventa + diez;

        }
    }
}

