using ApplicationManagement.DbModel;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlite("Filename=./applicationDB.db");
    }

    //List all tables here
    public DbSet<Address> Address { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<EducationalStatus> EducationalStatuses { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<JobCircular> JobCirculars { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Reference> References { get; set; }
    public DbSet<Research> Researches { get; set; }
    public DbSet<ResearchDegree> ResearchDegrees { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Training> Trainings { get; set; }

    //Configure Composite Keys here
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teacher>()
            .HasKey(t => new { t.NId, t.JobCircularId });
    }
}