using InspectionAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace InspectionAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<InspectionType> InspectionsType { get; set; } 
        public DbSet<Status> Status { get; set; }
    }
}
