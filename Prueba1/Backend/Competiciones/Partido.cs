using Prueba1.Backend.Equipos;

namespace Prueba1.Backend.Competiciones
{
    public class Partido
    {
        public Partido()
        {
            Local = new Equipo();
            Visitante = new Equipo();
            Resultado = new Resultado();
        }

        public Partido(Equipo local, Equipo visitante)
        {
            Local = local ?? new Equipo();
            Visitante = visitante ?? new Equipo();
            Resultado = new Resultado();
        }

        public Partido(int id, Equipo local, Equipo visitante, Resultado resultado, bool jugado)
        {
            Id = id;
            Local = local ?? new Equipo();
            Visitante = visitante ?? new Equipo();
            Resultado = resultado ?? new Resultado();
            Jugado = jugado;
        }

        public int Id { get; set; }
        public Equipo Local { get; set; }
        public int LocalId { get; set; }
        public Equipo Visitante { get; set; }
        public int VisitanteId { get; set; }
        public Resultado Resultado { get; set; }
        public bool Jugado { get; set; }
        public List<Jugada> Jugadas { get; set; }


        public static Partido SimularPartidoIA(Partido partido)
        {
            int ProbabilidadLocal = 35;
            int ProbabilidadEmpate = 30;

            Equipo Local = partido.Local;
            Equipo Visitante = partido.Visitante;
            int mediaLocal = (int)Local.Alineacion.MediaMedia();
            int mediaVisitante = (int)Visitante.Alineacion.MediaMedia();
            int diferencia = Math.Abs(mediaLocal - mediaVisitante); 

            
            if (diferencia < 5)
            {
                
                ProbabilidadEmpate += 10;
            }
            else if (diferencia < 10)
            {
                
                ProbabilidadEmpate += 5;
            }
            else
            {
                
                ProbabilidadEmpate -= 5;
            }

            
            if (mediaLocal > mediaVisitante)
            {
                ProbabilidadLocal += (diferencia * 2);
            }
            else
            {
                ProbabilidadLocal -= (diferencia * 2);
            }

            Random rnd = new Random();
            int resultado = rnd.Next(0, 100);
            if (resultado <= ProbabilidadLocal)
            {
                // Gana el local
                partido.Resultado.GolesLocal = rnd.Next(1, 5);
                partido.Resultado.GolesVisitante = rnd.Next(0, partido.Resultado.GolesLocal);
            }
            else if (resultado <= ProbabilidadLocal + ProbabilidadEmpate)
            {
                // Empate
                partido.Resultado.GolesLocal = rnd.Next(0, 5);
                partido.Resultado.GolesVisitante = partido.Resultado.GolesLocal;
            }
            else
            {
                // Gana el visitante
                partido.Resultado.GolesVisitante = rnd.Next(1, 5);
                partido.Resultado.GolesLocal = rnd.Next(0, partido.Resultado.GolesVisitante);
            }
            return partido;
        }

        public static Partido SimularPartidoUser(Partido partido)
        {


            return partido;
        }

    }

}

