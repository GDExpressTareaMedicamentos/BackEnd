using BackEndDronMedicamento.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BackEndDronMedicamento
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Dron> Drones { get; set; }
        public DbSet<DronMedicamento> DronMedicamentos { get; set; }
    }
}
