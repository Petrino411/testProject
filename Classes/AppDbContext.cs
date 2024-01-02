using Microsoft.EntityFrameworkCore;

namespace Classes;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
        
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasMany(a => a.Authors)
            .WithMany(b => b.Books);
        
    }
}