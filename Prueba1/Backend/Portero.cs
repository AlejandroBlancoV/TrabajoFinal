using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba1.Backend
{
    class Portero : Jugador
    {
        public int Paradas { get; set; }

        public Portero(int idJugador, int idEquipo, string nombre, string apellido, int edad, int media, double valor, double salario)
            : base(idJugador, idEquipo, nombre, apellido, edad, Posicion.Portero, media, valor, salario)
        {
            Paradas = 0; // Se puede inicializar aquí o en el constructor.
        }
    }
}

