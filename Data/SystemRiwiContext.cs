using Microsoft.EntityFrameworkCore;
using SystemRiwi.Models;

namespace SystemRiwi.Data
{
    public class SystemRiwiContext : DbContext
    {
        public SystemRiwiContext(DbContextOptions<SystemRiwiContext> options)
            : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<History> History { get; set; }

    }

}