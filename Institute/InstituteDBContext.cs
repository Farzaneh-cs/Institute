using Institute.Domain;
using Microsoft.EntityFrameworkCore;

namespace Institute;

class InstituteDBContext: DbContext
{
    public DbSet<School> Schools { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=.;Database=InstituteDB;integrated security=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<School>().Ignore(s => s.InstituteType);
    }
}
