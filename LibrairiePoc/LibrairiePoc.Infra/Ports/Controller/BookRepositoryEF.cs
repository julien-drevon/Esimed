using LibrairiePoc.Infra.Dtos;
using LibrairiePoc.UsesCase.Builder;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Ports.Controller;
using LibrairiePoc.UsesCase.Request;
using LibrairiePoc.UsesCase.Tools;
using Microsoft.EntityFrameworkCore;

namespace LibrairiePoc.Infra.Ports.Controller
{
    public class BookRepositoryEF : IBookStorage
    {
        private readonly DbContext _BookContext;

        public BookRepositoryEF(DbContext bookContext)
        {
            _BookContext = bookContext;
        }

        public PaginedData<Book> GetMany(GetBooksRequest getBooksRequest)
        {
            var bookTable = _BookContext.Set<BookDto>();
            return new PaginedData<Book>()
            {
                Data = bookTable
                                .Select(book => new BookBuilder(book.Isbn)
                                                    .Title(book.Title)
                                                    .Price(book.Price)
                                                    .Autor(book.Author.Label)
                                                    .Category(book.Category.Label)
                                                    .Build())
                                .Skip((getBooksRequest.PageNumber - 1) * getBooksRequest.PageSize)
                                .Take(getBooksRequest.PageSize)
                                 .ToArray(),
                Page = getBooksRequest.PageNumber,
                PageSize = getBooksRequest.PageSize
            };
        }
    }
}