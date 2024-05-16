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
        public int Media { get; set; }// Atributo que se calcula según posición
        public int Valor { get; set; }// Atributo que se calcula según media y edad
        public int Salario { get; set; }// Atributo que se calcula según media y valor
        public int Defensa { get; set; }
        public int Pase { get; set; }
        public int Fisico { get; set; }
        public int Regate { get; set; }
        public int Disparo { get; set; }
        public int Paradas { get; set; }

        public Jugador(int idJugador, int idEquipo, string nombre, string apellido, int edad, Posicion posicion, int media, int defensa, int pase, int fisico, int regate, int disparo, int paradas)
        {
            IdJugador = idJugador;
            IdEquipo = idEquipo;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Posicion = posicion;
            Media = media;
            Defensa = defensa;
            Pase = pase;
            Fisico = fisico;
            Regate = regate;
            Disparo = disparo;
            Paradas = paradas;
            Valor = CalculaValor(media, edad);
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
