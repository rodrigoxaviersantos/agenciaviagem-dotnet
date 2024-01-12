/*using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Context
{
    public class ApplicationDbContext : DbContext 
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UsuarioEntity> Usuario { get; set; }

        public DbSet<DestinoEntity> Destino { get; set; }
        public DbSet<DestinoReservado> DestinoReservado { get; set; }
    }
}
*/

using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UsuarioEntity> Usuario { get; set; }
        public DbSet<DestinoEntity> Destino { get; set; }
        public DbSet<DestinoReservado> DestinoReservado { get; set; }
    }
}
