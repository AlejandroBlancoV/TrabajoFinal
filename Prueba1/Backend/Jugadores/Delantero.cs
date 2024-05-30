namespace Prueba1.Backend.Jugadores
{

    internal class Delantero : Jugador
    {
        private static int media;

        public Delantero() { }
        public Delantero(int idJugador, int idEquipo, string nombre, int edad, int defensa, int pase, int fisico, int regate, int disparo, int paradas)
            : base(idJugador, idEquipo, nombre, edad, Posicion.Delantero, media, defensa, pase, fisico, regate, disparo, paradas)
        {
            media = CalculaMedia(defensa, pase, fisico, regate, disparo);
            Valor = CalculaValor(media, edad);
            Media = media;
            Salario = CalculaSalario(Valor, Media);
        }
        public Delantero(string nombre, int edad, int defensa, int pase, int fisico, int regate, int disparo, int paradas)
        : base(nombre, edad, Posicion.Delantero, media, defensa, pase, fisico, regate, disparo, paradas)
        {
            media = CalculaMedia(defensa, pase, fisico, regate, disparo);
            Valor = CalculaValor(media, edad);
            Media = media;
            Salario = CalculaSalario(Valor, Media);
        }




        private int CalculaMedia(int defensa, int pase, int fisico, int regate, int disparo)
        {
            int cuarenta = disparo * 40 / 100;
            int treinta = regate * 30 / 100;
            int resto = (fisico + pase) / 2;
            int veinte= resto * 20 / 100;
            int diez = defensa * 10 / 100;
            return cuarenta + treinta + veinte + diez;

        }
    }
}
