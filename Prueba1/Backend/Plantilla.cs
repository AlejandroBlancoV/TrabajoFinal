﻿using System;
using System.Linq;

namespace Prueba1.Backend
{
    class Plantilla
    {
        private Jugador[] jugadores;
        private int limite;

        public Plantilla(int limite)
        {
            if (limite <= 0)
            {
                throw new ArgumentException("El límite de la plantilla debe ser mayor que cero.");
            }

            this.limite = limite;
            jugadores = new Jugador[limite];
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

        public Jugador[] BuscarJugadorPorNombre(string nombre)
        {
            return jugadores.Where(j => j != null && j.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)).ToArray();
        }

        public Jugador[] BuscarJugadorPorPosicion(Posicion posicion)
        {
            return jugadores.Where(j => j != null && j.Posicion == posicion).ToArray();
        }

        public void OrdenarJugadoresPorEdad()
        {
            Array.Sort(jugadores.Where(j => j != null).ToArray(), (j1, j2) => j1.Edad.CompareTo(j2.Edad));
        }

        public void OrdenarJugadoresPorMedia()
        {
            Array.Sort(jugadores.Where(j => j != null).ToArray(), (j1, j2) => j1.Media.CompareTo(j2.Media));
        }

        public void OrdenarJugadoresPorValor()
        {
            Array.Sort(jugadores.Where(j => j != null).ToArray(), (j1, j2) => j1.Valor.CompareTo(j2.Valor));
        }
        public void OrdenarJugadoresPorPosicion()
        {
            Array.Sort(jugadores, CompararPorPosicion);
        }

        private int CompararPorPosicion(Jugador j1, Jugador j2)
        {
            
            Dictionary<Posicion, int> posicionValor = new Dictionary<Posicion, int>
            {
                { Posicion.Portero, 0 },
                { Posicion.Defensa, 1 },
                { Posicion.Medio, 2 },
                { Posicion.Delantero, 3 }
            };

            
            return posicionValor[j1.Posicion].CompareTo(posicionValor[j2.Posicion]);
        }

        public double MediaEdad()
        {
            return jugadores.Where(j => j != null).Average(j => j.Edad);
        }

        public double MediaMedia()
        {
            return jugadores.Where(j => j != null).Average(j => j.Media);
        }

        public int ValorTotal()
        {
            return jugadores.Where(j => j != null).Sum(j => j.Valor);
        }

        private int CantidadJugadores()
        {
            return jugadores.Count(j => j != null);
        }
    }
}
