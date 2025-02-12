﻿using Prueba1.Backend.BBDD;
using Prueba1.Backend.Equipos;

namespace Prueba1.Backend.Competiciones
{
    public class Calendario
    {
        public int Id { get; set; }
        public List<Jornada> Jornadas { get; set; }

        public Calendario(List<Equipo> equipos,MiContexto contexto)
        {
            Jornadas = GenerarCalendario(equipos,contexto);
            
        }

        public Calendario()
        {
        }

        public List<Jornada> GenerarCalendario(List<Equipo> equipos,MiContexto contexto)
        {
            var calendario = new List<Jornada>();

            if (equipos.Count % 2 != 0)
            {
                equipos.Add(null); 
            }

            for (int jornada = 0; jornada < equipos.Count - 1; jornada++)
            {
                var partidosDeLaJornada = new Jornada();

                for (int equipo = 0; equipo < equipos.Count / 2; equipo++)
                {
                    int equipoLocal = (jornada + equipo) % (equipos.Count - 1);
                    int equipoVisitante = (equipos.Count - 1 - equipo + jornada) % (equipos.Count - 1);

                    
                    if (equipo == 0)
                    {
                        equipoVisitante = equipos.Count - 1;
                    }
                    Partido p = new Partido { Local = equipos[equipoLocal], Visitante = equipos[equipoVisitante] };
                    partidosDeLaJornada.Partidos.Add(p);
                   
                    
                }

                calendario.Add(partidosDeLaJornada);
               
            }
            
            return calendario;
        }
    }
}
