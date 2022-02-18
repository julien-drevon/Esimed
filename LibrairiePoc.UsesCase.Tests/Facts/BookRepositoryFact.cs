using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Ports.Secondary;
using LibrairiePoc.UsesCase.Request;
using LibrairiePoc.UsesCase.Tools;

namespace LibrairiePoc.UsesCase.Tests.UsesCase
{
    public class BookRepositoryFact : IBookRepository
    {
        public PaginedData<Book> GetMany(GetBooksRequest getBooksRequest)
        {
            return new PaginedData<Book>()
            {
                Data = new[] { new Book("10022544", "Clean code", "Robert C Matins", 42, "technique") },
                Page = 1,
                PageSize = 20,
            };
        }
    }
}