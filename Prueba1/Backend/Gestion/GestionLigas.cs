using Prueba1.Backend.BBDD;
using Prueba1.Backend.Competiciones;
using Prueba1.Backend.Equipos;

namespace Prueba1.Backend.Gestion
{
    internal class GestionLigas
    {
        GestionEquipos gestionEquipos;
        MiContexto contexto;
        public GestionLigas(MiContexto _contexto)
        {
            this.gestionEquipos = new GestionEquipos(_contexto);
            this.contexto = _contexto;
        }

        public Liga CrearLiga()
        {
            Liga liga = new Liga();
            liga.Nombre = "La Liga";
            List<Equipo> equipos = gestionEquipos.GenerarEquiposLiga();
          
            Calendario calendario = new Calendario();
            contexto.Calendarios.Add(calendario);
            calendario.Jornadas = calendario.GenerarCalendario(equipos, contexto);
           
            contexto.SaveChanges(); 
            liga.Calendario = calendario;
            liga.Equipos = equipos;
            contexto.Ligas.Add(liga);
            contexto.SaveChanges(); 

            return liga;
        }

    }
}
