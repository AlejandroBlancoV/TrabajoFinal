namespace Prueba1.Backend.Jugadores
{
    class Portero : Jugador
    {
        private static int media;

        public Portero() { }
        public Portero(int idJugador, int idEquipo, string nombre, int edad, int defensa, int pase, int fisico, int regate, int disparo, int paradas)
            : base(idJugador, idEquipo, nombre, edad, Posicion.Portero, media, defensa, pase, fisico, regate, disparo, paradas)
        {
            media = CalculaMedia(defensa, pase, fisico, regate, disparo, paradas);
            Valor = CalculaValor(media, edad);
            Media = media;
            Salario = CalculaSalario(Media, Valor);
        }
        public Portero(string nombre, int edad, int defensa, int pase, int fisico, int regate, int disparo, int paradas)
        : base(nombre, edad, Posicion.Portero, media, defensa, pase, fisico, regate, disparo, paradas)
        {
            media = CalculaMedia(defensa, pase, fisico, regate, disparo, paradas);
            Valor = CalculaValor(media, edad);
            Media = media;
            Salario = CalculaSalario(Valor, Media);
        }



        private int CalculaMedia(int defensa, int pase, int fisico, int regate, int disparo, int paradas)
        {
            int noventa = paradas * 90 / 100;
            int resto = (defensa + pase + fisico + regate + disparo) / 5;
            int diez = resto * 10 / 100;
            return noventa + diez;

        }
    }
}

