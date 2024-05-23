using System.Windows.Controls;

namespace Prueba1.Backend
{
    public class Equipo
    {
        public int IdEquipo { get; set; }
        public string Nombre { get; set; }
        public Image Escudo { get; set; }
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

        public void CambiarJugadorEnAlineacion(Jugador jugadorFuera, Jugador jugadorDentro)
        {
            Alineacion.CambiarJugador(jugadorFuera, jugadorDentro);
        }
    }
}
