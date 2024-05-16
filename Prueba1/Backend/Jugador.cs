using System;

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
        public int Valor { get; set; }
        public int Salario { get; set; }

        public Jugador(int idJugador, int idEquipo, string nombre, string apellido, int edad, Posicion posicion, int media)
        {
            IdJugador = idJugador;
            IdEquipo = idEquipo;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Posicion = posicion;
            Media = media;
            
        }

        public static int CalculaValor(int media, int edad)
        {
            int porcentajeEdad = 100;
            int valor = 100000;

            // Incrementa el valor basado en la media
            for (int i = 0; i <= media; i++)
            {
                valor += (valor * 7) / 100;
            }

            // Ajusta el porcentaje de edad
            for (int i = 16; i <= edad; i++)
            {
                porcentajeEdad -= 7;
            }

            // Calcula el ajuste por edad como float
            float mejoraEdad = porcentajeEdad / 100.0f;
            float valorMejoraEdad = valor * mejoraEdad;

            valor += (int)valorMejoraEdad;

            return valor;
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
