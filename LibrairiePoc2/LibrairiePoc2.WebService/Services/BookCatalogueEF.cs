using LibrairiePoc2.UseCase;
using Microsoft.EntityFrameworkCore;

namespace LibrairiePoc2.WebService
{
    public class BookCatalogueEF : IBookCatalogue
    {
        public BookCatalogueEF(DbContext bookContextEF, IMonconverter<BookDTO, Book> monConverter)
        {
            this.BookContextEF = bookContextEF;
            this.Converter = monConverter;
        }

        public DbContext BookContextEF { get; private set; }

        public IMonconverter<BookDTO, Book> Converter { get; }

        public IQueryable<Book> GetAll()
        {
            var tableBook = BookContextEF.Set<BookDTO>();
            return tableBook.Select(bookDto => this.Converter.Convert(bookDto));
        }

        public void AddBook(Book book)
        { 
            BookContextEF.Add(new BookDTO() { Isbn = book.Isbn, Title= book.Title });
            BookContextEF.SaveChanges();
        }

        public void Update(Book book)
        {
            var bookToUpdate = BookContextEF.Set<BookDTO>().SingleOrDefault(x => x.Isbn ==book.Isbn);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;

            }
            else throw new NotFoundEntiteException();

            BookContextEF.SaveChanges();
        }
    }
}