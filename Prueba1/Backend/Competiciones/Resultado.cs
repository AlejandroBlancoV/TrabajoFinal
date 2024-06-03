
namespace Prueba1.Backend.Competiciones
{
    public class Resultado
        
    {
        public Resultado()
        {
            GolesLocal = 0;
            GolesVisitante = 0;
        }

        public Resultado(int golesLocal, int golesVisitante)
        {
            GolesLocal = golesLocal;
            GolesVisitante = golesVisitante;
        }

        public Resultado(int id, int golesLocal, int golesVisitante) : this(id, golesLocal)
        {
            GolesVisitante = golesVisitante;
        }

        public int Id { get; set; }
        public int GolesLocal { get; set; }
        public int GolesVisitante { get; set; }

    }
}
