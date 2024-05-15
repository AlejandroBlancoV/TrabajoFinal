using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba1.Backend
{
    class Jugador
    {
        public int IdJugador { get; set; }
        public int IdEquipo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public Posicion Posicion { get; set; }
        public int Media { get; set; }
        public double Valor { get; set; }
        public double Salario { get; set; }

        public Jugador(int idJugador, int idEquipo, string nombre, string apellido, int edad, Posicion posicion, int media, double valor, double salario)
        {
            IdJugador = idJugador;
            IdEquipo = idEquipo;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Posicion = posicion;
            Media = media;
            Valor = valor;
            Salario = salario;
        }
       
    }
    enum Posicion
    {
        Portero,
        Defensa,
        Medio,
        Delantero
    }
}
