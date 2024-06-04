using Prueba1.Backend.Equipos;
using Prueba1.Backend.Jugadores;
public class Jugada
{
    public enum ZonaCampo { Defensa, Medio, Delantera }
    public int Id { get; set; }
    public ZonaCampo Zona { get; set; }
    public Equipo Atacante { get; set; }
    public Equipo Defensor { get; set; }

    public Jugada()
    {
    }

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
            gol = Medio(jugada);
        }
        else
        {
            gol = Delantera(jugada);
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


        Jugador defensorAtacante = defensoresAtacantes[rnd.Next(defensoresAtacantes.Length)];
        Jugador delanteroDefensor = delanterosDefensores[rnd.Next(delanterosDefensores.Length)];


        int estadisticaDefensor = rnd.Next(2) == 0 ? defensorAtacante.Pase : defensorAtacante.Regate;
        int estadisticaDelantero = rnd.Next(2) == 0 ? delanteroDefensor.Defensa : delanteroDefensor.Fisico;



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

            Jugada nuevaJugada = new Jugada(ZonaCampo.Medio, atacante, defensor);
            gol = RealizarJugada(nuevaJugada);
        }

        return gol;
    }
    private static bool Medio(Jugada jugada)
    {
        bool gol = false;
        Equipo atacante = jugada.Atacante;
        Equipo defensor = jugada.Defensor;
        Random rnd = new Random();


        Jugador[] mediosAtacantes = atacante.Alineacion.ObtenerJugadoresPorPosicion(Posicion.Medio);
        Jugador[] mediosDefensores = defensor.Alineacion.ObtenerJugadoresPorPosicion(Posicion.Medio);


        int mediaMediosAtacantes = mediosAtacantes.Sum(j => j.Media);
        int mediaMediosDefensores = mediosDefensores.Sum(j => j.Media);


        int atributoEnfrentamiento = 10;


        Jugador medioAtacante = mediosAtacantes[rnd.Next(mediosAtacantes.Length)];
        Jugador medioDefensor = mediosDefensores[rnd.Next(mediosDefensores.Length)];


        int estadisticaAtacante = rnd.Next(2) == 0 ? medioAtacante.Pase : medioAtacante.Regate;
        int estadisticaDefensor = rnd.Next(2) == 0 ? medioDefensor.Defensa : medioDefensor.Fisico;



        bool continuarJugada = false;
        if (mediaMediosAtacantes > mediaMediosDefensores)
        {
            int porcentajeSeguir = 50 + atributoEnfrentamiento;
            int diferencia = estadisticaAtacante - estadisticaDefensor;
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
            int diferencia = estadisticaAtacante - estadisticaDefensor;
            porcentajeSeguir += diferencia * 2;
            int resultado = rnd.Next(0, 100);
            if (resultado <= porcentajeSeguir)
            {
                continuarJugada = true;
            }
        }

        if (continuarJugada)
        {

            Jugada nuevaJugada = new Jugada(ZonaCampo.Delantera, atacante, defensor);
            gol = RealizarJugada(nuevaJugada);
        }

        return gol;
    }
    private static bool Delantera(Jugada jugada)
    {
        bool gol = false;
        Equipo atacante = jugada.Atacante;
        Equipo defensor = jugada.Defensor;
        Random rnd = new Random();


        Jugador[] delanterosAtacantes = atacante.Alineacion.ObtenerJugadoresPorPosicion(Posicion.Delantero);
        Jugador[] defensoresDefensores = defensor.Alineacion.ObtenerJugadoresPorPosicion(Posicion.Defensa);
        Jugador portero = defensor.Alineacion.ObtenerJugadoresPorPosicion(Posicion.Portero)[0];


        int mediaDelanterosAtacantes = delanterosAtacantes.Sum(j => j.Media);
        int mediaDefensoresDefensores = defensoresDefensores.Sum(j => j.Media);


        int atributoEnfrentamiento = 10;


        Jugador delanteroAtacante = delanterosAtacantes[rnd.Next(delanterosAtacantes.Length)];
        Jugador defensorDefensor = defensoresDefensores[rnd.Next(defensoresDefensores.Length)];


        int estadisticaAtacante = rnd.Next(2) == 0 ? delanteroAtacante.Pase : delanteroAtacante.Regate;
        int estadisticaDefensor = rnd.Next(2) == 0 ? defensorDefensor.Defensa : defensorDefensor.Fisico;


        bool continuarJugada = false;
        if (mediaDelanterosAtacantes > mediaDefensoresDefensores)
        {
            int porcentajeSeguir = 50 + atributoEnfrentamiento;
            int diferencia = estadisticaAtacante - estadisticaDefensor;
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
            int diferencia = estadisticaAtacante - estadisticaDefensor;
            porcentajeSeguir += diferencia * 2;
            int resultado = rnd.Next(0, 100);
            if (resultado <= porcentajeSeguir)
            {
                continuarJugada = true;
            }
        }

        if (continuarJugada)
        {
            int mejoraPeora = 0;
            if (delanteroAtacante.Media > portero.Media)
            {
                mejoraPeora = 10;
            }

            int porcentajeGol = 50 + mejoraPeora;
            int diferencia = delanteroAtacante.Disparo - portero.Paradas;
            porcentajeGol += diferencia * 2;
            int resultado = rnd.Next(0, 100);
            if (resultado <= porcentajeGol)
            {
                gol = true;
            }
        }

        return gol;
    }


}
