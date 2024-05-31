using Prueba1.Backend.Equipos;

namespace Prueba1.Backend.Competiciones
{
    public class Liga
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Equipo> Equipos { get; set; }
        public Calendario Calendario { get; set; }

        public Liga(string nombre, List<Equipo> equipos)
        {
            Nombre = nombre;
            Equipos = equipos;
            Calendario = new Calendario(equipos);
        }

        public void OrganizarClasificacion()
        {
            Equipos = Equipos.OrderByDescending(e => e.Puntos)
                             .ThenByDescending(e => e.DiferenciaGoles)
                             .ThenByDescending(e => e.GolesAFavor)
                             .ToList();

            for (int i = 0; i < Equipos.Count; i++)
            {
                Equipos[i].Posicion = i + 1;
            }
        }

    }
}
