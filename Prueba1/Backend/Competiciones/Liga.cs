using Prueba1.Backend.BBDD;
using Prueba1.Backend.Equipos;

namespace Prueba1.Backend.Competiciones
{
    public class Liga
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Equipo> Equipos { get; set; }
        public Calendario Calendario { get; set; }

        public Liga(string nombre, List<Equipo> equipos,MiContexto contexto)
        {
            Nombre = nombre;
            Equipos = equipos;
            Calendario = new Calendario(equipos, contexto);
        }

        public Liga()
        {
        }

        public void OrganizarClasificacion()
        {
            Equipos = Equipos.OrderByDescending(e => e.Puntos)
                             .ThenByDescending(e => e.DiferenciaGoles)
                             .ThenByDescending(e => e.GolesAFavor)
                             .ThenByDescending(e => e.GolesEnContra)
                             .ThenByDescending(e => e.PartidosGanados)
                             .ThenByDescending(e => e.PartidosEmpatados)
                             .ThenByDescending(e => e.Nombre)
                             .ToList();

            for (int i = 0; i < Equipos.Count; i++)
            {
                Equipos[i].Posicion = i + 1;
            }
        }
        public Equipo ObtenerEquipoUsuario()
        {
            return Equipos.FirstOrDefault(e => e.ControladoPorUsuario);
        }
        public Jornada EncontrarJornadaEquipoUsuario()
        {
            var equipoUsuario = ObtenerEquipoUsuario();
            if (equipoUsuario == null) return null;

            int partidosJugados = equipoUsuario.PartidosJugados;

            // Asumiendo que cada equipo juega exactamente un partido por jornada
            if (partidosJugados >= Calendario.Jornadas.Count) return null;

            return Calendario.Jornadas[partidosJugados];
        }
        public Partido EncontrarPartidoEquipoUsuario()
        {
            var jornada = EncontrarJornadaEquipoUsuario();
            var equipoUsuario = ObtenerEquipoUsuario();
            if (jornada == null || equipoUsuario == null) return null;

            return jornada.Partidos.FirstOrDefault(p => p.Local == equipoUsuario || p.Visitante == equipoUsuario);
        }


    }
}
