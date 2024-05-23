namespace Prueba1.Backend
{
    public class Alineacion
    {
        private Jugador[] jugadores;
        private const int limite = 11;

        public Alineacion(Jugador[] jugadores)
        {
            if (jugadores.Length != limite)
            {
                throw new ArgumentException($"La alineación debe tener exactamente {limite} jugadores.");
            }

            this.jugadores = jugadores;
        }

        public Jugador[] ObtenerJugadoresPorPosicion(Posicion posicion)
        {
            return jugadores.Where(j => j.Posicion == posicion).ToArray();
        }

        public double MediaEdad()
        {
            return jugadores.Average(j => j.Edad);
        }

        public double MediaMedia()
        {
            return jugadores.Average(j => j.Media);
        }

        public int ValorTotal()
        {
            return jugadores.Sum(j => j.Valor);
        }

        public int SalarioTotal()
        {
            return jugadores.Sum(j => j.Salario);
        }
        public void CambiarJugador(Jugador jugadorFuera, Jugador jugadorDentro)
        {
            for (int i = 0; i < jugadores.Length; i++)
            {
                if (jugadores[i] == jugadorFuera)
                {
                    jugadores[i] = jugadorDentro;
                    return;
                }
            }

            throw new ArgumentException("El jugador que se intenta sacar no está en la alineación.");
        }
        public bool EstaEnAlineacion(Jugador jugador)
        {
            return jugadores.Contains(jugador);
        }
        public Jugador[] ObtenerTodosLosJugadores()
        {
            return jugadores;
        }
        public Jugador[] OrdenarPorMedia()
        {
            return jugadores.OrderByDescending(j => j.Media).ToArray();
        }
        public Jugador[] OrdenarPorMediaMenor()
        {
            return jugadores.OrderBy(j => j.Media).ToArray();
        }
        public Jugador[] OrdenarPorValor()
        {
            return jugadores.OrderByDescending(j => j.Valor).ToArray();
        }
        public Jugador[] OrdenarPorValorMenor()
        {
            return jugadores.OrderBy(j => j.Valor).ToArray();
        }
        public Jugador[] OrdenarPorSalario()
        {
            return jugadores.OrderByDescending(j => j.Salario).ToArray();
        }
        public Jugador[] OrdenarPorSalarioMenor()
        {
            return jugadores.OrderBy(j => j.Salario).ToArray();
        }
        public Jugador[] OrdenarPorEdad()
        {
            return jugadores.OrderByDescending(j => j.Edad).ToArray();
        }
        public Jugador[] OrdenarPorEdadMenor()
        {
            return jugadores.OrderBy(j => j.Edad).ToArray();
        }
        public Jugador[] OrdenarPorNombre()
        {
            return jugadores.OrderBy(j => j.Nombre).ToArray();
        }
        public Jugador[] OrdenarPorNombreMenor()
        {
            return jugadores.OrderByDescending(j => j.Nombre).ToArray();
        }
        public Jugador[] OrdenarPorPosicion()
        {
            return jugadores.OrderBy(j => j.Posicion).ToArray();
        }
        public Jugador[] OrdenarPorPosicionMenor()
        {
            return jugadores.OrderByDescending(j => j.Posicion).ToArray();
        }
        



    }
}