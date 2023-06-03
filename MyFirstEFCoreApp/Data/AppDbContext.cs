using Microsoft.EntityFrameworkCore;

namespace MyFirstEFCoreApp.Data;

public class AppDbContext : DbContext 
{
    private const string _connectionString =
            "Server=DESKTOP-31B0IPP;Database=MyFirstEFCoreApp;Trusted_Connection=True;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }

    public DbSet<Book> Books { get; set; }
}


