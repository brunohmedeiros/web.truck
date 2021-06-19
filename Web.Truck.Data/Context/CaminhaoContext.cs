using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Web.Truck.Domain.Entities;

namespace Web.Truck.Data.Context
{
    public class CaminhaoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=../WebTruck.db");

        public DbSet<Caminhao> Caminhao { get; set; }
        public DbSet<Modelo> Modelo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
