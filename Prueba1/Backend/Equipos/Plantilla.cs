using Prueba1.Backend.Jugadores;

namespace Prueba1.Backend.Equipos
{
    public class Plantilla
    {
        private Jugador[] jugadores;
        private int limite;

        public Plantilla(int limite, Jugador[] jugadores)
        {
            if (limite <= 0)
            {
                throw new ArgumentException("El límite de la plantilla debe ser mayor que cero.");
            }

            this.limite = limite;
            this.jugadores = jugadores;
        }

        public void AgregarJugador(Jugador jugador)
        {
            if (jugadores.Contains(jugador))
            {
                throw new InvalidOperationException("El jugador ya está en la plantilla.");
            }

            if (CantidadJugadores() >= limite)
            {
                throw new InvalidOperationException("La plantilla está llena, no se puede agregar más jugadores.");
            }

            jugadores[CantidadJugadores()] = jugador;
        }

        public void QuitarJugador(Jugador jugador)
        {
            if (!jugadores.Contains(jugador))
            {
                throw new InvalidOperationException("El jugador no está en la plantilla.");
            }

            jugadores = jugadores.Where(j => j != jugador).ToArray();
        }

        public double ObtenerMediaEdad()
        {
            return jugadores.Where(j => j != null).Average(j => j.Edad);
        }

        public int ObtenerValorTotal()
        {
            return jugadores.Where(j => j != null).Sum(j => j.Valor);
        }

        public int ObtenerSalarioTotal()
        {
            return jugadores.Where(j => j != null).Sum(j => j.Salario);
        }

        private int CantidadJugadores()
        {
            return jugadores.Count(j => j != null);
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
