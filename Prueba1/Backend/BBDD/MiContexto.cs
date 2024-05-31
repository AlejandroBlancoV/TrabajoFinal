using Microsoft.EntityFrameworkCore;
using Prueba1.Backend.Equipos;
using Prueba1.Backend.Jugadores;

namespace Prueba1.Backend.BBDD
{
    public class MiContexto : DbContext
    {
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Plantilla> Plantillas { get; set; }
        public DbSet<Alineacion> Alineaciones { get; set; }
        public DbSet<Equipo> Equipos { get; set; }

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

        }
    }
}
