using Classes;
using Microsoft.EntityFrameworkCore;

namespace console;

class Program
{
    static void Main(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite($"Data Source={Environment.CurrentDirectory + @"\bd.db"}");
        var dbContext = new AppDbContext(optionsBuilder.Options);
        dbContext.Database.EnsureCreated();
        
        
        
    }
}