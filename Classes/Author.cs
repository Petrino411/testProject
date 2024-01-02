using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Classes;

public class Author
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Book> Books { get; set; } = new();

    public Author()
    {
        
    }

    public override string ToString()
    {
        return Name;
    }

    public static List<Author> GenerateAuthors(int count)
    {
        List<Author> authors = new();
        for (int i = 0; i < count; i++)
        {
            authors.Add(new Author()
            {
                Name = $"TestAuthorName{i}",
            });
        }

        return authors;
    }
}