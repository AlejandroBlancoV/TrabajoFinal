using Microsoft.EntityFrameworkCore;
using Prueba1.Backend.Equipos;
using Prueba1.Backend.Jugadores;
using Prueba1.Backend.Competiciones;

namespace Prueba1.Backend.BBDD
{
    public class MiContexto : DbContext
    {
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Plantilla> Plantillas { get; set; }
        public DbSet<Alineacion> Alineaciones { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Resultado> Resultados { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<Jornada> Jornadas { get; set; }
        public DbSet<Calendario> Calendarios { get; set; }
        public DbSet<Liga> Ligas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MiBaseDeDatos;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jugador>()
                .HasDiscriminator<string>("TipoJugador")
                .HasValue<Defensor>("Defensor")
                .HasValue<Delantero>("Delantero")
                .HasValue<Medio>("Medio")
                .HasValue<Portero>("Portero");

            modelBuilder.Entity<Jugador>()
                .HasOne(j => j.Equipo)
                .WithMany(e => e.Jugadores)
                .HasForeignKey(j => j.EquipoId);

            modelBuilder.Entity<Partido>()
    .HasOne(p => p.Local)
    .WithMany()
    .HasForeignKey(p => p.LocalId)
    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Partido>()
                .HasOne(p => p.Visitante)
                .WithMany()
                .HasForeignKey(p => p.VisitanteId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
