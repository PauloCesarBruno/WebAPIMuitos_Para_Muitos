using Microsoft.EntityFrameworkCore;
using WebAPIMuitos_Para_MuitosDomain.Models;

namespace WebAPIMuitos_Para_MuitosDomain.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-EJP79KA;Database=Grupo;User ID=sa;Password=Paradoxo22");
        }
    }
}
