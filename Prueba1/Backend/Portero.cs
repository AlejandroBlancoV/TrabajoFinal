namespace Prueba1.Backend
{
    class Portero : Jugador
    {
        private static int media;

        public Portero(int idJugador, int idEquipo, string nombre, int edad, int defensa, int pase, int fisico, int regate, int disparo, int paradas)
            : base(idJugador, idEquipo, nombre, edad, Posicion.Portero, media, defensa, pase, fisico, regate, disparo, paradas)
        {
            media = CalculaMedia(defensa, pase, fisico, regate, disparo, paradas);
            Valor = CalculaValor(media, edad);
            Media = media;
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

