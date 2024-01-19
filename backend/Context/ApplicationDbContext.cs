using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { this.ChangeTracker.LazyLoadingEnabled = true; }

        public DbSet<UsuarioEntity> Usuario { get; set; }
        public DbSet<DestinoEntity> Destino { get; set; }
        public DbSet<DestinoReservadoEntity> DestinoReservado { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DestinoReservadoEntity>()
                .HasOne(d => d.Usuario)
                .WithMany(u => u.DestinoReservados)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
