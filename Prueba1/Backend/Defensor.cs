﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba1.Backend
{
    class Defensor : Jugador
    {
        private static int media;

        public Defensor(int idJugador, int idEquipo, string nombre, string apellido, int edad, int defensa, int pase, int fisico, int regate, int disparo, int paradas)
            : base(idJugador, idEquipo, nombre, apellido, edad, Posicion.Defensa, media, defensa, pase, fisico, regate, disparo, paradas)
        {
            media = CalculaMedia(defensa, pase, fisico, regate, disparo);
            Valor = CalculaValor(media, edad);
            Media = media;
        }

        private int CalculaMedia(int defensa, int pase, int fisico, int regate, int disparo)
        {
            int sesenta = (defensa * 60)/ 100;
            int treinta = (fisico * 30) / 100;
            int resto = (pase + regate + disparo) / 3;
            int diez = (resto * 10) / 100;
            return sesenta + treinta + diez;

        }
    }
}
