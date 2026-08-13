using Assignment1.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment1.DbContexts;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer
            ("Server=.; Database=ReadMoreBooks; Trusted_Connection=True; TrustServerCertificate=True;");
        
    }
    
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
}