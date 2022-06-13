using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Request;
using LibrairiePoc.UsesCase.Tools;

namespace LibrairiePoc.UsesCase.Ports.Secondary
{
    public interface IBookRepository
    {
         PaginedData<Book> GetMany(GetBooksRequest getBooksRequest);
    }
}