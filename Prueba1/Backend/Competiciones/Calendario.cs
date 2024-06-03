using Prueba1.Backend.Equipos;

namespace Prueba1.Backend.Competiciones
{
    public class Calendario
    {
        public int Id { get; set; }
        public List<Jornada> Jornadas { get; set; }

        public Calendario(List<Equipo> equipos)
        {
            Jornadas = GenerarCalendario(equipos);
        }

        public Calendario()
        {
        }

        private List<Jornada> GenerarCalendario(List<Equipo> equipos)
        {
            var calendario = new List<Jornada>();

            if (equipos.Count % 2 != 0)
            {
                equipos.Add(null); // Si el número de equipos es impar, añade un "equipo fantasma"
            }

            for (int jornada = 0; jornada < equipos.Count - 1; jornada++)
            {
                var partidosDeLaJornada = new Jornada();

                for (int equipo = 0; equipo < equipos.Count / 2; equipo++)
                {
                    int equipoLocal = (jornada + equipo) % (equipos.Count - 1);
                    int equipoVisitante = (equipos.Count - 1 - equipo + jornada) % (equipos.Count - 1);

                    // El último equipo se queda en su lugar mientras los otros rotan
                    if (equipo == 0)
                    {
                        equipoVisitante = equipos.Count - 1;
                    }

                    partidosDeLaJornada.Partidos.Add(new Partido { Local = equipos[equipoLocal], Visitante = equipos[equipoVisitante] });
                }

                calendario.Add(partidosDeLaJornada);
            }

            return calendario;
        }
    }
}
