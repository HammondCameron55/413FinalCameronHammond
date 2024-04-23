using Microsoft.EntityFrameworkCore;

namespace _413FinalCameronHammond.Models
{
    public class FinalProjectContext : DbContext
    {
        public FinalProjectContext(DbContextOptions<FinalProjectContext> options) : base(options)
        {
        }

        public DbSet<Entertainers> Entertainers { get; set; }
    }
}
