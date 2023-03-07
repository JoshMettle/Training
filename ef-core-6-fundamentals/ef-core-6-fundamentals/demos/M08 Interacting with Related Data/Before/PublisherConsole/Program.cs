
using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

PubContext _context = new PubContext(); //existing database

//InsertNewAuthorWithNewBook();

//AddNewBookToExistingAuthorInMemory();

//AddNewBookToExistingAuthorInMemoryViaBook();

EagerLoadBooksWithAuthors();

void EagerLoadBooksWithAuthors()
{
   var authors = _context.Authors.Include(a => a.Books).ToList();
    authors.ForEach(a =>
    {
        Console.WriteLine($"{a.LastName} ({a.Books.Count})");
        a.Books.ForEach(b => Console.WriteLine("      " + b.Title));
    });
}

void AddNewBookToExistingAuthorInMemoryViaBook()
{
    var book = new Book
    {
        Title = "Shift",
        PublishDate = new DateTime(2012, 1, 1)
    };
    book.Author = _context.Authors.Find(5);
    _context.Books.Add(book);
    _context.SaveChanges();
}

void AddNewBookToExistingAuthorInMemory()
{
    var author = _context.Authors.FirstOrDefault(a => a.LastName == "Howey");
    if (author != null)
    {
        author.Books.Add(
            new Book { Title = "Wool", PublishDate = new DateTime(2012, 1, 1) });
        _context.SaveChanges();
    }
}

void InsertNewAuthorWithNewBook()
{
    var author = new Author { FirstName = "Lynda", LastName = "Rutledge" };
    author.Books.Add(new Book
    {
        Title = "West With Giraffes",
        PublishDate = new DateTime(2021, 2, 1)
    });
    _context.Authors.Add(author);
    _context.SaveChanges();
}

