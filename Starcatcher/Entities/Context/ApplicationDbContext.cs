using Microsoft.EntityFrameworkCore;

namespace Starcatcher.Entities.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<Cota> Cotas { get; set; }
    }

    
}