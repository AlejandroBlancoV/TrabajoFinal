using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prueba1.Backend.Jugadores;
namespace Prueba1.Backend.Gestion
{
    internal class GestionJugadores
    {
        GestionNombres gestionNombres = new GestionNombres();

        public Portero GeneraPortero() {             
            string nombre = gestionNombres.GenerarNombreAleatorio();
            int edad = new Random().Next(16, 36);
            int defensa = new Random().Next(1, 30);
            int pase = new Random().Next(1, 30);
            int fisico = new Random().Next(1, 30);
            int regate = new Random().Next(1, 30);
            int disparo = new Random().Next(1, 30);
            int paradas = new Random().Next(50, 99);
            
            return new Portero(nombre,edad,defensa,pase,fisico,regate,disparo,paradas);
        }
        public Defensor GeneraDefensa()
        {
            string nombre = gestionNombres.GenerarNombreAleatorio();
            int edad = new Random().Next(16, 36);
            int defensa = new Random().Next(50, 99);
            int pase = new Random().Next(20, 75);
            int fisico = new Random().Next(50, 99);
            int regate = new Random().Next(15, 70);
            int disparo = new Random().Next(15, 70);
            int paradas = new Random().Next(1, 1);

            return new Defensor(nombre, edad, defensa, pase, fisico, regate, disparo, paradas);
        }
        public Medio GeneraMedio()
        {
            string nombre = gestionNombres.GenerarNombreAleatorio();
            int edad = new Random().Next(16, 36);
            int defensa = new Random().Next(30, 90);
            int pase = new Random().Next(50, 99);
            int fisico = new Random().Next(30, 90);
            int regate = new Random().Next(30, 90);
            int disparo = new Random().Next(30, 90);
            int paradas = new Random().Next(1, 1);

            return new Medio(nombre, edad, defensa, pase, fisico, regate, disparo, paradas);
        }
        public Delantero GeneraDelantero()
        {
            string nombre = gestionNombres.GenerarNombreAleatorio();
            int edad = new Random().Next(16, 36);
            int defensa = new Random().Next(15, 60);
            int pase = new Random().Next(30, 80);
            int fisico = new Random().Next(30, 90);
            int regate = new Random().Next(40, 99);
            int disparo = new Random().Next(50, 99);
            int paradas = new Random().Next(1, 1);

            return new Delantero(nombre, edad, defensa, pase, fisico, regate, disparo, paradas);
        }
    }
}
