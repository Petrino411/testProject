using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Classes;

public class Book
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Amount { get; set; }
    public List<Author> Authors { get; set; } = new();

    public Book()
    {
        
    }
    
    public Book(string name, double price, int amount) 
        => (Name, Price, Amount) = (name, price, amount);

}