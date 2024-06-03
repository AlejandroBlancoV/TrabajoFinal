using Prueba1.Backend.Equipos;
using Prueba1.Backend.Jugadores;
public class Jugada
{
    public enum ZonaCampo { Defensa, Medio, Delantera }
    public int Id { get; set; }
    public ZonaCampo Zona { get; set; }
    public Equipo Atacante { get; set; }
    public Equipo Defensor { get; set; }



    public Jugada(ZonaCampo zona, Equipo atacante, Equipo defensor)
    {
        Zona = zona;
        Atacante = atacante;
        Defensor = defensor;
    }

    public Jugada(Equipo atacante, Equipo defensor)
    {
        Atacante = atacante;
        Defensor = defensor;
    }

    public static Jugada GenerarJugada(Equipo atacante, Equipo defensor)
    {
        Random rnd = new Random();
        int defensa = 45;
        int medio = 35;
        int delantera = 20;
        int zona = rnd.Next(0, 100);
        Jugada jugada;
        if (zona <= defensa)
        {
            jugada = new Jugada(ZonaCampo.Defensa, atacante, defensor);
        }
        else if (zona <= defensa + medio)
        {
            jugada = new Jugada(ZonaCampo.Medio, atacante, defensor);
        }
        else
        {
            jugada = new Jugada(ZonaCampo.Delantera, atacante, defensor);
        }
        return jugada;
    }

    public static bool RealizarJugada(Jugada jugada)
    {
        bool gol = false;
        if (jugada.Zona == ZonaCampo.Defensa)
        {
            gol = Defensa(jugada);
        }
        else if (jugada.Zona == ZonaCampo.Medio)
        {

        }
        else
        {

        }
        return gol;
    }

    private static bool Defensa(Jugada jugada)
    {
        bool gol = false;
        Equipo atacante = jugada.Atacante;
        Equipo defensor = jugada.Defensor;
        Random rnd = new Random();


        Jugador[] defensoresAtacantes = atacante.Alineacion.ObtenerJugadoresPorPosicion(Posicion.Defensa);
        Jugador[] delanterosDefensores = defensor.Alineacion.ObtenerJugadoresPorPosicion(Posicion.Delantero);


        int mediaDefensoresAtacantes = defensoresAtacantes.Sum(j => j.Media);
        int mediaDelanterosDefensores = delanterosDefensores.Sum(j => j.Media);


        int atributoEnfrentamiento = 10;

        // Escoger un jugador random de ambos equipos
        Jugador defensorAtacante = defensoresAtacantes[rnd.Next(defensoresAtacantes.Length)];
        Jugador delanteroDefensor = delanterosDefensores[rnd.Next(delanterosDefensores.Length)];

        // Escoger una estadística random para el enfrentamiento
        int estadisticaDefensor = rnd.Next(2) == 0 ? defensorAtacante.Pase : defensorAtacante.Regate;
        int estadisticaDelantero = delanteroDefensor.Defensa;

        // Determinar la probabilidad de continuar la jugada
        bool continuarJugada = false;
        if (mediaDefensoresAtacantes > mediaDelanterosDefensores)
        {
            int porcentajeSeguir = 50 + atributoEnfrentamiento;
            int diferencia = estadisticaDefensor - estadisticaDelantero;
            porcentajeSeguir += diferencia * 2;
            int resultado = rnd.Next(0, 100);
            if (resultado <= porcentajeSeguir)
            {
                continuarJugada = true;
            }

        }
        else
        {
            int porcentajeSeguir = 50 - atributoEnfrentamiento;
            int diferencia = estadisticaDefensor - estadisticaDelantero;
            porcentajeSeguir += diferencia * 2;
            int resultado = rnd.Next(0, 100);
            if (resultado <= porcentajeSeguir)
            {
                continuarJugada = true;
            }
        }

        if (continuarJugada)
        {
            // Crear una nueva jugada desde el medio
            Jugada nuevaJugada = new Jugada(ZonaCampo.Medio, atacante, defensor);
            gol = RealizarJugada(nuevaJugada);
        }

        return gol;
    }


}
