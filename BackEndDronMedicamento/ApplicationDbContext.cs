using BackEndDronMedicamento.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BackEndDronMedicamento
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Medicamento> Medicamento { get; set; }
        public DbSet<Dron> Dron { get; set; }
        public DbSet<DronMedicamento> DronMedicamento { get; set; }
    }
}
