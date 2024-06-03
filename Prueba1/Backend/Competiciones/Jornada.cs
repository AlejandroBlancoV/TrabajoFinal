using System.Collections.Generic;

namespace Prueba1.Backend.Competiciones
{
    public class Jornada
    {
        public int Id { get; set; }
        public List<Partido> Partidos { get; set; }

        public Jornada()
        {
            Partidos = new List<Partido>();
        }

        public Jornada(List<Partido> partidos)
        {
            Partidos = partidos;
        }
    }
}

