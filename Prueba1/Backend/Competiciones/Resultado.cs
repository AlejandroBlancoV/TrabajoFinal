
namespace Prueba1.Backend.Competiciones
{
    public class Resultado
        
    {
        public int Id { get; set; }
        public int GolesLocal { get; set; }
        public int GolesVisitante { get; set; }
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


       

    }
}
