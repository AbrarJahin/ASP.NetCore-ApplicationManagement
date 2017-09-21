using ApplicationManagement.DbModel;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    //List all tables here
    public DbSet<Person> Person { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=./applicationDB.db");
    }
}