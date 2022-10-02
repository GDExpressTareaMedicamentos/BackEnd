using BackEndDronMedicamento.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BackEndDronMedicamento
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DronMedicamento>()
                .HasKey(c => new { c.CodigoMedicamento });
        }

        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Dron> Drones { get; set; }
        public DbSet<DronMedicamento> DronMedicamentos { get; set; }
    }
}
