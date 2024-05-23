﻿namespace Prueba1.Backend
{

    internal class Delantero : Jugador
    {
        private static int media;

        public Delantero(int idJugador, int idEquipo, string nombre, int edad, int defensa, int pase, int fisico, int regate, int disparo, int paradas)
            : base(idJugador, idEquipo, nombre, edad, Posicion.Delantero, media, defensa, pase, fisico, regate, disparo, paradas)
        {
            media = CalculaMedia(defensa, pase, fisico, regate, disparo);
            Valor = CalculaValor(media, edad);
            Media = media;
        }

        private int CalculaMedia(int defensa, int pase, int fisico, int regate, int disparo)
        {
            int sesenta = (disparo * 60) / 100;
            int treinta = (regate * 30) / 100;
            int resto = (defensa + fisico + pase) / 3;
            int diez = (resto * 10) / 100;
            return sesenta + treinta + diez;

        }
    }
}
