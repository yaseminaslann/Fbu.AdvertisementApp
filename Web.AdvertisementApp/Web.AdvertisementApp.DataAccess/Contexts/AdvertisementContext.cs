using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Web.AdvertisementApp.DataAccess.Configurations;
using Web.AdvertisementApp.Entities;

namespace Web.AdvertisementApp.DataAccess.Contexts
{
    public class AdvertisementContext : DbContext
    {
        public AdvertisementContext(DbContextOptions<AdvertisementContext> options) : base(options)
        {
        }

        public DbSet<Advertisement> Advertisements { get; set; }

        public DbSet<AdvertisementAppUser> AdvertisementAppUsers { get; set; }

        public DbSet<AdvertisementAppUserStatus> AdvertisementAppUserStatuses { get; set; }

        public DbSet<AppRole> AppRoles { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<AppUserRole> AppUserRoles { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<MilitaryStatus> MilitaryStatuses { get; set; }

        public DbSet<ProvidedService> ProvidedServices { get; set; }

        public class AdvertisementContextFactory : IDesignTimeDbContextFactory<AdvertisementContext>
        {
            public AdvertisementContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<AdvertisementContext>();
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=AdvertisementDb;User Id=postgres;Password=limonlukek1;");

                return new AdvertisementContext(optionsBuilder.Options);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdvertisementAppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisementAppUserStatusConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisementConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new MilitaryStatusConfiguration());
            modelBuilder.ApplyConfiguration(new ProvidedServiceConfiguration());
        }
       
    }
}
