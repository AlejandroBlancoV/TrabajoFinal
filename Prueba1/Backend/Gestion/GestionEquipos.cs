using Prueba1.Backend.BBDD;
using Prueba1.Backend.Equipos;
using Prueba1.Backend.Jugadores;
using Prueba1.Backend.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;

namespace Prueba1.Backend.Gestion
{
    internal class GestionEquipos
    {
        private GestionJugadores gestionJugadores;
        private MiContexto contexto;

        public GestionEquipos(MiContexto contexto)
        {
            this.contexto = contexto;
            this.gestionJugadores = new GestionJugadores(contexto);
        }

        public List<Equipo> GenerarEquiposLiga()
        {
            List<Equipo> equipos = new List<Equipo>();
            string[] nombresEquipos = new string[] {
                "Caliz CF", "CA Novesuna", "Cedilla CF", "Chirona FC", "Cholo CF",
                "Deportivo Palaves", "Frenada CF", "Gabarra FC", "Gallo Vallecano", "Merengue CF",
                "RC Cruelta", "RCD Cayorca", "RealB.E.T.I.S", "Real Suciedad CF", "Setafe CF",
                "SpotYfai Masia FC", "UD Alegria", "UD La Palmas", "VallaReal CF", "Viol-Encia CF"
            };

            foreach (var nombre in nombresEquipos)
            {
                BitmapImage imagen = new BitmapImage(new Uri($"pack://application:,,,/Images/Shields/{nombre.Replace(" ", "")}.png"));
                Equipo equipo = new Equipo
                {
                    Nombre = nombre,
                    Escudo = ImageUtils.ConvertirImagenAEscudo(imagen),
                    Presupuesto = 0,
                    ControladoPorUsuario = false,
                    Jugadores = new List<Jugador>(),
                };

                equipos.Add(equipo);
            }

            
            contexto.Equipos.AddRange(equipos);
            contexto.SaveChanges();

            
            foreach (var equipo in equipos)
            {
                var jugadores = gestionJugadores.GenerarPlantillaPorDefecto();
                gestionJugadores.OrdenarAlineacion(jugadores);
                foreach (var jugador in jugadores)
                {
                    jugador.EquipoId = equipo.Id;
                    equipo.Jugadores.Add(jugador);
                }

            }

            contexto.SaveChanges(); 

            return equipos;
        }
    }
}
