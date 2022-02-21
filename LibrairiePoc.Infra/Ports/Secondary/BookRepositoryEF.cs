using LibrairiePoc.Infra.Dtos;
using LibrairiePoc.UsesCase.Builder;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Ports.Secondary;
using LibrairiePoc.UsesCase.Request;
using LibrairiePoc.UsesCase.Tools;
using Microsoft.EntityFrameworkCore;

namespace LibrairiePoc.Infra.Ports.Secondary
{
    public class BookRepositoryEF : IBookRepository
    {
        public DbContext _BookContext;

        public BookRepositoryEF(DbContext bookContext)
        {
            _BookContext = bookContext;
        }

        public PaginedData<Book> GetMany(GetBooksRequest getBooksRequest)
        {
            var bookTable = _BookContext.Set<BookDto>();
            return new PaginedData<Book>()
            {
                Data = bookTable.Skip((getBooksRequest.PageNumber - 1) * getBooksRequest.PageSize)
                                .Take(getBooksRequest.PageSize)
                                .Select(book => new BookBuilder(book.Isbn)
                                                    .Title(book.Title)
                                                    .Price(book.Price)
                                                    .Autor(book.Author.Label)
                                                    .Category(book.Category.Label)
                                                    .Build())
                                 .ToArray(),
                Page = getBooksRequest.PageNumber,
                PageSize = getBooksRequest.PageSize
            };
        }
    }
}