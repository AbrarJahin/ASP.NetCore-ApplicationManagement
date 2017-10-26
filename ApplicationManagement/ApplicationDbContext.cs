using ApplicationManagement.DbModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

public class ApplicationDbContext : DbContext
{
    //List all tables here
    public DbSet<Advertisement> Advertisements { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<EducationResult> EducationResults { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<JobCircular> JobCirculars { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Reference> References { get; set; }
    public DbSet<Research> Researches { get; set; }
    public DbSet<ResearchDegree> ResearchDegrees { get; set; }
    public DbSet<TeacherApplication> TeacherApplications { get; set; }
    public DbSet<Training> Trainings { get; set; }

    //Configure Database Settings
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlite("Filename=./applicationDB.db");
    }

    public override int SaveChanges()
    {
        AddTimestamps();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        AddTimestamps();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        AddTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
    {
        AddTimestamps();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void AddTimestamps()
    {
        var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

        /*
        var currentUsername = !string.IsNullOrEmpty(System.Web.HttpContext.Current?.User?.Identity?.Id)
            ? HttpContext.Current.User.Identity.Id
            : -1;   //-1 for Anonimous
        */
        long currentUserId = -1;    //-1 for Anonimous

        foreach (var entity in entities)
        {
            if (entity.State == EntityState.Added)
            {
                ((BaseEntity)entity.Entity).CreatedTime = DateTime.UtcNow;
                ((BaseEntity)entity.Entity).CreatorUserId = currentUserId;
                //((BaseEntity)entity.Entity).CreatorIPAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            }

            ((BaseEntity)entity.Entity).LastModifiedTime = DateTime.UtcNow;
            ((BaseEntity)entity.Entity).LastModifireUserId = currentUserId;
            //((BaseEntity)entity.Entity).LastModifireIPAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        }
    }

    public DbSet<ApplicationManagement.DbModel.Office> Office { get; set; }
}