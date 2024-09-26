using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Business.Data
{
    public class EcomerceDbContext : DbContext
    {
        public EcomerceDbContext(DbContextOptions<EcomerceDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Profile> Profile { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<AutoMapper.Profile>();

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
