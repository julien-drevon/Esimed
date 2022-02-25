using LibrairiePoc2.UseCase;

namespace LibrairiePoc2.WebService
{
    public class MonBookConverter : IMonconverter<BookDTO, Book>
    {
        public Book Convert(BookDTO book) => new Book(book.Isbn, book.Title);
    }
}