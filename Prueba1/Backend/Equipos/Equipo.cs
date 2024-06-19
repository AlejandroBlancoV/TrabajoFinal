using Prueba1.Backend.Jugadores;

namespace Prueba1.Backend.Equipos
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public byte[] Escudo { get; set; }
        public ICollection<Jugador> Jugadores { get; set; }
        public Alineacion Alineacion { get; set; }
        public Plantilla Plantilla { get; set; }
        public int Presupuesto { get; set; }
        public int Puntos { get; set; }
        public int PartidosJugados { get; set; }
        public int PartidosGanados { get; set; }
        public int PartidosEmpatados { get; set; }
        public int PartidosPerdidos { get; set; }
        public int GolesAFavor { get; set; }
        public int GolesEnContra { get; set; }
        public int DiferenciaGoles { get; set; }
        public int Posicion { get; set; }
        public bool ControladoPorUsuario { get; set; }

        public Equipo()
        {
            Jugadores = new List<Jugador>();
        }

        public Equipo(string nombre, byte[] escudo, Alineacion alineacion, Plantilla plantilla, int presupuesto, bool controladoPorUsuario)
        {
            Nombre = nombre;
            Escudo = escudo;
            Alineacion = alineacion;
            Plantilla = plantilla;
            Presupuesto = presupuesto;
            ControladoPorUsuario = controladoPorUsuario;
            Jugadores = new List<Jugador>();
        }

        public void CrearPlantilla()
        {
            Jugador[] jugadores= Jugadores.ToArray();
            Plantilla = new Plantilla(jugadores);
            OrdenarAlineacion(Plantilla);

        }
        public void OrdenarAlineacion(Plantilla p)
        {
            
            var alineacion1 = new Alineacion(
                p.jugadores.Where(j => j is Portero).OrderByDescending(j => j.Media).Take(1)
                .Concat(p.jugadores.Where(j => j is Defensor).OrderByDescending(j => j.Media).Take(4))
                .Concat(p.jugadores.Where(j => j is Medio).OrderByDescending(j => j.Media).Take(3))
                .Concat(p.jugadores.Where(j => j is Delantero).OrderByDescending(j => j.Media).Take(3))
                .ToList());

            var alineacion2 = new Alineacion(
                p.jugadores.Where(j => j is Portero).OrderByDescending(j => j.Media).Take(1)
                .Concat(p.jugadores.Where(j => j is Defensor).OrderByDescending(j => j.Media).Take(4))
                .Concat(p.jugadores.Where(j => j is Medio).OrderByDescending(j => j.Media).Take(4))
                .Concat(p.jugadores.Where(j => j is Delantero).OrderByDescending(j => j.Media).Take(2))
                .ToList());

            var alineacion3 = new Alineacion(
                p.jugadores.Where(j => j is Portero).OrderByDescending(j => j.Media).Take(1)
                .Concat(p.jugadores.Where(j => j is Defensor).OrderByDescending(j => j.Media).Take(3))
                .Concat(p.jugadores.Where(j => j is Medio).OrderByDescending(j => j.Media).Take(4))
                .Concat(p.jugadores.Where(j => j is Delantero).OrderByDescending(j => j.Media).Take(3))
                .ToList());

            
            var maxMedia = new[] { alineacion1.MediaMedia(), alineacion2.MediaMedia(), alineacion3.MediaMedia() }.Max();

            
            if (maxMedia == alineacion1.MediaMedia())
            {
                this.Alineacion= alineacion1;
            }
            else if (maxMedia == alineacion2.MediaMedia())
            {
                this.Alineacion = alineacion2;
            }
            else
            {
                this.Alineacion = alineacion3;
            }
        }
        public void CambiarAlineacion(Alineacion nuevaAlineacion)
        {
            Alineacion = nuevaAlineacion;
        }

        public void AgregarJugadorAPlantilla(Jugador jugador)
        {
            Plantilla.AgregarJugador(jugador);
        }

        public void QuitarJugadorDePlantilla(Jugador jugador)
        {
            Plantilla.QuitarJugador(jugador);
        }

        public double ObtenerMediaEdadPlantilla()
        {
            return Plantilla.ObtenerMediaEdad();
        }

        public double ObtenerMediaEdadAlineacion()
        {
            return Alineacion.MediaEdad();
        }

        public int ObtenerValorTotalPlantilla()
        {
            return Plantilla.ObtenerValorTotal();
        }

        public int ObtenerValorTotalAlineacion()
        {
            return Alineacion.ValorTotal();
        }

        public int ObtenerSalarioTotalPlantilla()
        {
            return Plantilla.ObtenerSalarioTotal();
        }

        public int ObtenerSalarioTotalAlineacion()
        {
            return Alineacion.SalarioTotal();
        }
        public int ObtenerMediaMediaPlantilla()
        {
            return Plantilla.ObtenerMediaMedia();
        }

        public void CambiarJugadorEnAlineacion(Jugador jugadorFuera, Jugador jugadorDentro)
        {
            Alineacion.CambiarJugador(jugadorFuera, jugadorDentro);
        }
    }
}
