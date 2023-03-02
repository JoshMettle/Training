// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

using (PubContext context = new PubContext())
{
    context.Database.EnsureCreated();
}

//GetAuthors();
AddAuthors();
//GetAuthors();
AddAuthorWithBook();
GetAuthorsWithBooks();

void GetAuthors()
{
    using PubContext context = new PubContext();
    List<PublisherDomain.Author> authors = context.Authors.ToList();
    foreach(var author in authors)
    {
        Console.WriteLine(author.FirstName+ " " + author.LastName);
    }
}

void AddAuthors()
{
    Author author = new Author { FirstName = "Josie", LastName = "Newf" };
    using PubContext context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}



void AddAuthorWithBook()
{
    Author author = new Author { FirstName = "Julie", LastName = "Lerman" };
    author.Books.Add(new Book { Title = "Programming Entity Framework", PublishDate = new DateTime(2010, 8, 1) });

    author.Books.Add(new Book { Title = "Programming Entity Framework 2nd Ed", PublishDate = new DateTime(2010, 8, 1) });
    using PubContext context = new PubContext();

    context.Authors.Add(author);
    context.SaveChanges();
}
 
void GetAuthorsWithBooks()
{
    using PubContext context = new PubContext();

    List<Author> authors = context.Authors.Include(a => a.Books).ToList();
    foreach(Author author in authors)
    {
        Console.WriteLine(author.FirstName +" " + author.LastName);
        foreach(Book book in author.Books)
        {
            Console.WriteLine("*" + book.Title);
        }
    }
}