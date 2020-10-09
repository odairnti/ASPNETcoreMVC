using Microsoft.EntityFrameworkCore;
using Site01.Models;

namespace Site01.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Palavra> palavras { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //EF - Garantir que o banco seja criado pelo EntityFramework
            Database.EnsureCreated();

        }
    }
}
