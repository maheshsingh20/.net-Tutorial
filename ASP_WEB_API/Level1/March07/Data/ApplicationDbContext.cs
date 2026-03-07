using Microsoft.EntityFrameworkCore;

namespace March07.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Add your DbSets here
    // Example: public DbSet<Patient> Patients { get; set; }
}
