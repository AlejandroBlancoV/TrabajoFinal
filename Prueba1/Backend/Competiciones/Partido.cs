using Prueba1.Backend.Equipos;

namespace Prueba1.Backend.Competiciones
{
    public class Partido
    {
        public Partido()
        {
        }

        public Partido(Equipo local, Equipo visitante)
        {
            Local = local;
            Visitante = visitante;
        }

        public Partido(int id, Equipo local, Equipo visitante, Resultado resultado, bool jugado)
        {
            Id = id;
            Local = local;
            Visitante = visitante;
            Resultado = resultado;
            Jugado = jugado;
        }

        public int Id { get; set; }
        public Equipo Local { get; set; }
        public Equipo Visitante { get; set; }
        public Resultado Resultado { get; set; }
        public bool Jugado { get; set; }
    }

}
