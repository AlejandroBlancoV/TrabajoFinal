﻿using Prueba1.Backend.Equipos;

namespace Prueba1.Backend.Jugadores
{
    public class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int EquipoId { get; set; }
        public Equipo Equipo { get; set; }
        public int Edad { get; set; }
        public Posicion Posicion { get; set; }
        public int Media { get; set; }
        public int Valor { get; set; }
        public int Salario { get; set; }
        public int Defensa { get; set; }
        public int Pase { get; set; }
        public int Fisico { get; set; }
        public int Regate { get; set; }
        public int Disparo { get; set; }
        public int Paradas { get; set; }

        public Jugador() { }

        public Jugador(int id, int equipoId, string nombre, int edad, Posicion posicion, int media, int defensa, int pase, int fisico, int regate, int disparo, int paradas)
        {
            Id = id;
            EquipoId = equipoId;
            Nombre = nombre;
            Edad = edad;
            Posicion = posicion;
            Media = media;
            Defensa = defensa;
            Pase = pase;
            Fisico = fisico;
            Regate = regate;
            Disparo = disparo;
            Paradas = paradas;
        }

        public Jugador(string nombre, int edad, Posicion posicion, int media, int defensa, int pase, int fisico, int regate, int disparo, int paradas)
        {
            Nombre = nombre;
            Edad = edad;
            Posicion = posicion;
            Media = media;
            Defensa = defensa;
            Pase = pase;
            Fisico = fisico;
            Regate = regate;
            Disparo = disparo;
            Paradas = paradas;
        }

        public static int CalculaValor(int media, int edad)
        {
            int porcentajeEdad = 100;
            int valor = 100000;

            for (int i = 0; i <= media; i++)
            {
                valor += valor * 7 / 100;
            }

            for (int i = 16; i <= edad; i++)
            {
                porcentajeEdad -= 7;
            }

            float mejoraEdad = porcentajeEdad / 100.0f;
            float valorMejoraEdad = valor * mejoraEdad;

            valor += (int)valorMejoraEdad;

            return valor;
        }

        public static int CalculaSalario(int valor, int media)
        {
            int salario = (valor * 15) / 100;
            float cuenta = 0;
            int porcentajeMedia = 100;
            for (int i = 99; i > media; i--)
            {
                porcentajeMedia -= 2;
            }
            cuenta = porcentajeMedia / 100.0f;
            cuenta += 1;
            salario = (int)(salario * cuenta);

            return salario;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Edad: {Edad}, Posición: {Posicion}, Media: {Media}, Valor: {Valor}, Salario: {Salario}, Disparo: {Disparo}, Pase: {Pase}, Regate: {Regate}, Físico: {Fisico}, Defensa: {Defensa}, Paradas: {Paradas}";
        }
    }

    public enum Posicion
    {
        Portero,
        Defensa,
        Medio,
        Delantero
    }
}
