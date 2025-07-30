using Microsoft.EntityFrameworkCore;

namespace Starcatcher.Entities.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        public DbSet<GrupoConsorcio> Grupos { get; set; }
        public DbSet<Cota> Cotas { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cota>()
                .HasOne(c => c.GrupoConsorcio)
                .WithMany(g => g.Cotas)
                .HasForeignKey(c => c.GrupoConsorcioId);
        }
    }
}