// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;
using System.Linq;

 PubContext _context = new PubContext();

//GetAuthors();
/*
void GetAuthors()
{
    var authors = context.Authors.ToList();
    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}
*/
QueryFilters();

void QueryFilters()
{
    string name = "Josie";
    List<Author> authors = _context.Authors.Where(s => s.FirstName == name).ToList();
}