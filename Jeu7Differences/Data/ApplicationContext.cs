using Microsoft.EntityFrameworkCore;

namespace Jeu7Differences.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Joueur> Joueurs { get; set; }
    }
}
