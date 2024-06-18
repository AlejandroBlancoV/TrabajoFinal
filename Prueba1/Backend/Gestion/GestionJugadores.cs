using Prueba1.Backend.BBDD;
using Prueba1.Backend.Equipos;
using Prueba1.Backend.Jugadores;
namespace Prueba1.Backend.Gestion
{
    internal class GestionJugadores
    {
        GestionNombres gestionNombres;
        MiContexto contexto;

        public GestionJugadores(MiContexto contexto)
        {
            this.contexto = contexto;
            this.gestionNombres = new GestionNombres();
        }

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

        public Jugador GeneraJugadorAleatorio()
        {
            int tipo = new Random().Next(1, 5);
            switch (tipo)
            {
                case 1:
                    return GeneraPortero();
                case 2:
                    return GeneraDefensa();
                case 3:
                    return GeneraMedio();
                case 4:
                    return GeneraDelantero();
                default:
                    return GeneraPortero();
            }
        }
        public Plantilla GenerarPlantillaAleatoria(int limite)
        {
            Jugador[] jugadores = new Jugador[limite];
            for (int i = 0; i < limite; i++)
            {
                jugadores[i] = GeneraJugadorAleatorio();
            }
            return new Plantilla(jugadores);
        }
        public Plantilla GenerarPlantillaPorDefecto()
        {
            Jugador[] jugadores = new Jugador[19];
            for (int i = 0; i < 2; i++)
            {
                jugadores[i] = GeneraPortero();
            }
            for (int i = 2; i < 8; i++)
            {
                jugadores[i] = GeneraDefensa();
            }
            for (int i = 8; i < 14; i++)
            {
                jugadores[i] = GeneraMedio();
            }
            for (int i = 14; i < 19; i++)
            {
                jugadores[i] = GeneraDelantero();
            }
            return new Plantilla(jugadores);
        }
        public Alineacion OrdenarAlineacion(Plantilla p)
        {
            // Crear diferentes tipos de alineaciones
            var alineacion1 = new Alineacion(
                p.jugadores.Where(j => j is Portero).OrderByDescending(j => j.Media).Take(1)
                .Concat(p.jugadores.Where(j => j is Defensor).OrderByDescending(j => j.Media).Take(4))
                .Concat(p.jugadores.Where(j => j is Medio).OrderByDescending(j => j.Media).Take(3))
                .Concat(p.jugadores.Where(j => j is Delantero).OrderByDescending(j => j.Media).Take(3))
                .ToList());

            var alineacion2 = new Alineacion(
                p.jugadores.Where(j => j is Portero).OrderByDescending(j => j.Media).Take(1)
                .Concat(p.jugadores.Where(j => j is Defensor).OrderByDescending(j => j.Media).Take(4))
                .Concat(p.jugadores.Where(j => j is Medio).OrderByDescending(j => j.Media).Take(4))
                .Concat(p.jugadores.Where(j => j is Delantero).OrderByDescending(j => j.Media).Take(2))
                .ToList());

            var alineacion3 = new Alineacion(
                p.jugadores.Where(j => j is Portero).OrderByDescending(j => j.Media).Take(1)
                .Concat(p.jugadores.Where(j => j is Defensor).OrderByDescending(j => j.Media).Take(3))
                .Concat(p.jugadores.Where(j => j is Medio).OrderByDescending(j => j.Media).Take(4))
                .Concat(p.jugadores.Where(j => j is Delantero).OrderByDescending(j => j.Media).Take(3))
                .ToList());

            // Comparar las medias globales de las alineaciones
            var maxMedia = new[] { alineacion1.MediaMedia(), alineacion2.MediaMedia(), alineacion3.MediaMedia() }.Max();

            // Devolver la alineación con la mayor media global
            if (maxMedia == alineacion1.MediaMedia())
            {
                return alineacion1;
            }
            else if (maxMedia == alineacion2.MediaMedia())
            {
                return alineacion2;
            }
            else
            {
                return alineacion3;
            }
        }


    }
}
