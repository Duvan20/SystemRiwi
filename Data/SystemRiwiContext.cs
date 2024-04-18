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

        //login 
        /*   public User ValidedUser(string _Document,string _password)
          {
              return Users.Where( u => u.Document == _Document && u.Password == _password).FirstOrDefault();;
          } */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<History>()
            .HasOne(h => h.User)
            .WithMany(h => h.History)
            .HasForeignKey(h => h.Id)
            .OnDelete(DeleteBehavior.Cascade);
        }






    }

}