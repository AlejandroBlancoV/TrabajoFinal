namespace Prueba1.Backend.Jugadores
{

    internal class Medio : Jugador
    {
        private static int media;

        public Medio(int idJugador, int idEquipo, string nombre, int edad, int defensa, int pase, int fisico, int regate, int disparo, int paradas)
            : base(idJugador, idEquipo, nombre, edad, Posicion.Medio, media, defensa, pase, fisico, regate, disparo, paradas)
        {
            media = CalculaMedia(defensa, pase, fisico, regate, disparo);
            Valor = CalculaValor(media, edad);
            Media = media;
        }
        public Medio(string nombre, int edad, int defensa, int pase, int fisico, int regate, int disparo, int paradas)
        : base(nombre, edad, Posicion.Medio, media, defensa, pase, fisico, regate, disparo, paradas)
        {
            media = CalculaMedia(defensa, pase, fisico, regate, disparo);
            Valor = CalculaValor(media, edad);
            Media = media;
        }





        private int CalculaMedia(int defensa, int pase, int fisico, int regate, int disparo)
        {
            int cuarenta = pase * 40 / 100;
            int resto = (defensa + fisico + disparo + regate) / 4;
            int sesenta = resto * 60 / 100;
            return cuarenta + sesenta;

        }
    }
}
