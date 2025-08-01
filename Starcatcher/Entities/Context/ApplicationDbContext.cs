using Microsoft.EntityFrameworkCore;

namespace Starcatcher.Entities.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        public DbSet<GrupoConsorcio> Grupos { get; set; }
        public DbSet<Cota> Cotas { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cota>()
                .HasOne(c => c.GrupoConsorcio)
                .WithMany(g => g.Cotas)
                .HasForeignKey(c => c.GrupoConsorcioId);

            modelBuilder.Entity<Cota>()
            .HasOne(c => c.User)
            .WithMany(u => u.Cotas)
            .HasForeignKey(c => c.UserId)
            .IsRequired(false);
        }
    }
}