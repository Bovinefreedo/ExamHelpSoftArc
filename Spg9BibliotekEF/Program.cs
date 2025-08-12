using Microsoft.EntityFrameworkCore;
using Spg9BibliotekEF.Model;
using System.Reflection.Emit;


using (var db = new BookContext()) {
    Author a0 =new Author
    {
        name = "Terry Pratchet",
        age = 67
    };
    Author a1 = new Author
    {
        name = "Andy Weir",
        age = 53
    };
    Author a2 = new Author
    {
        name = "Alison Wier",
        age = 74
    };

    Book b1 = new Book
    {
        Title = "The Martian",
        Year = 2003,
        Author = a2
    };

    Book b2 = new Book { 
        Title = "The Hail Mary Project",
        Year = 2022,
        Author = a2
    };

    Book b0 = new Book { 
        Title = "Small gods",
        Year = 2003,
        Author = a0
    };

    Book b3 = new Book { 
        Title = "Guards, Guards",
        Year = 2003,
        Author = a0
    };


    db.Authors.RemoveRange(db.Authors);
    db.Books.RemoveRange(db.Books);

    db.Authors.Add(a0);
    db.Authors.Add(a1);
    db.Authors.Add(a2);

    db.Books.Add(b0);
    db.Books.Add(b1);
    db.Books.Add(b3);
    db.Books.Add(b2);

    db.SaveChanges();

    List<Book> b = db.Books.Where(x => x.Year!=2003).Include("Author").ToList();

    foreach (var book in b) {
        Console.WriteLine($"{book.Title} : by {book.Author.name}");
    }
}