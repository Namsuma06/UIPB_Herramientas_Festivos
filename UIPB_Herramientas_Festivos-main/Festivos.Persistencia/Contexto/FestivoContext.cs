using IUPBFestivos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Festivos.Persistencia.Contexto
{
    public class FestivosContext : DbContext
    {
        public FestivosContext(DbContextOptions<FestivosContext> options)
            : base(options)
        {
        }

        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Festivo> Festivos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Tipo>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.Property(e => e.Nombre)
                       .IsRequired()
                       .HasMaxLength(100);
            });

            builder.Entity<Festivo>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.Property(e => e.Nombre)
                       .IsRequired()
                       .HasMaxLength(100);

                entidad.HasOne(e => e.Tipo)
                       .WithMany()
                       .HasForeignKey(e => e.IdTipo)
                       .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}

