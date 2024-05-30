using Prueba1.Backend.Jugadores;

namespace Prueba1.Backend.Equipos
{
    public class Alineacion
    {
        public int Id { get; set; }
        public int EquipoId { get; set; }
        public List<Jugador> Jugadores { get; set; }
        private const int limite = 11;
        private Alineacion() { }
        public Alineacion(List<Jugador> jugadores)
        {
            if (jugadores.Count != limite)
            {
                throw new ArgumentException($"La alineación debe tener exactamente {limite} jugadores.");
            }

            this.Jugadores = jugadores;
        }

        public Jugador[] ObtenerJugadoresPorPosicion(Posicion posicion)
        {
            return Jugadores.Where(j => j.Posicion == posicion).ToArray();
        }

        public double MediaEdad()
        {
            return Jugadores.Average(j => j.Edad);
        }

        public double MediaMedia()
        {
            return Jugadores.Average(j => j.Media);
        }

        public int ValorTotal()
        {
            return Jugadores.Sum(j => j.Valor);
        }

        public int SalarioTotal()
        {
            return Jugadores.Sum(j => j.Salario);
        }

        public void CambiarJugador(Jugador jugadorFuera, Jugador jugadorDentro)
        {
            for (int i = 0; i < Jugadores.Count; i++)
            {
                if (Jugadores[i] == jugadorFuera)
                {
                    Jugadores[i] = jugadorDentro;
                    return;
                }
            }

            throw new ArgumentException("El jugador que se intenta sacar no está en la alineación.");
        }

        public bool EstaEnAlineacion(Jugador jugador)
        {
            return Jugadores.Contains(jugador);
        }

        public Jugador[] ObtenerTodosLosJugadores()
        {
            return Jugadores.ToArray();
        }

        public Jugador[] OrdenarPorMedia()
        {
            return Jugadores.OrderByDescending(j => j.Media).ToArray();
        }

        public Jugador[] OrdenarPorMediaMenor()
        {
            return Jugadores.OrderBy(j => j.Media).ToArray();
        }

        public Jugador[] OrdenarPorValor()
        {
            return Jugadores.OrderByDescending(j => j.Valor).ToArray();
        }

        public Jugador[] OrdenarPorValorMenor()
        {
            return Jugadores.OrderBy(j => j.Valor).ToArray();
        }

        public Jugador[] OrdenarPorSalario()
        {
            return Jugadores.OrderByDescending(j => j.Salario).ToArray();
        }

        public Jugador[] OrdenarPorSalarioMenor()
        {
            return Jugadores.OrderBy(j => j.Salario).ToArray();
        }

        public Jugador[] OrdenarPorEdad()
        {
            return Jugadores.OrderByDescending(j => j.Edad).ToArray();
        }

        public Jugador[] OrdenarPorEdadMenor()
        {
            return Jugadores.OrderBy(j => j.Edad).ToArray();
        }

        public Jugador[] OrdenarPorNombre()
        {
            return Jugadores.OrderBy(j => j.Nombre).ToArray();
        }

        public Jugador[] OrdenarPorNombreMenor()
        {
            return Jugadores.OrderByDescending(j => j.Nombre).ToArray();
        }

        public Jugador[] OrdenarPorPosicion()
        {
            return Jugadores.OrderBy(j => j.Posicion).ToArray();
        }

        public Jugador[] OrdenarPorPosicionMenor()
        {
            return Jugadores.OrderByDescending(j => j.Posicion).ToArray();
        }
    }
}
