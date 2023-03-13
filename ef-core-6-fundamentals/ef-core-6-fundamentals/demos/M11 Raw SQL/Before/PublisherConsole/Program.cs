using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

PubContext _context = new PubContext(); //existing database

SimpleRawSql();
void SimpleRawSql()
{
    List<Author> authors = _context.Authors.FromSqlRaw("select * from authors").ToList();
}
