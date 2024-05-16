﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba1.Backend
{
    class Defensor : Jugador
    {
       public int Defensa { get; set; }
       public int Pase { get; set; }
       public int Fisico { get; set; }
       public int Regate { get; set; }
       public int Disparo { get; set; }
      

       

        public Defensor(int idJugador, int idEquipo, string nombre, string apellido, int edad, int media,int defensa, int pase, int fisico, int regate, int disparo)
        : base(idJugador, idEquipo, nombre, apellido, edad, Posicion.Portero, media)
        {
            Defensa = defensa;
            Pase = pase;
            Fisico = fisico;
            Regate = regate;
            Disparo = disparo;
        }
    }
}
