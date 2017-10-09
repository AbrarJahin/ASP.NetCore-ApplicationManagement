using ApplicationManagement.DbModel;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    //List all tables here
    
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<EducationResult> EducationResults { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<JobCircular> JobCirculars { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Reference> References { get; set; }
    public DbSet<Research> Researches { get; set; }
    public DbSet<ResearchDegree> ResearchDegrees { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Training> Trainings { get; set; }

    //Configure Database Settings
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlite("Filename=./applicationDB.db");
    }

    /*
    //Configure Composite Keys here
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
 
        modelBuilder.Entity<Teacher>()
            .Property(t => t.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Teacher>()
            .HasKey(t => new { t.NId, t.JobCircular.Id });

        modelBuilder.Entity<JobCircular>()
            .Property(j => j.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<JobCircular>()
            .HasKey(j => new { j.Name, j.StartDate, j.EndDate });
 
        modelBuilder.Entity<Address>()
            .HasOne<Teacher>()
            .WithMany()
            .HasForeignKey(e => e.TeacherId);
    }
    */
}