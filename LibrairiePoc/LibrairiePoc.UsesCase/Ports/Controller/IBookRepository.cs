using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Request;
using LibrairiePoc.UsesCase.Tools;

namespace LibrairiePoc.UsesCase.Ports.Controller
{
    public interface IBookStorage
    {
         PaginedData<Book> GetMany(GetBooksRequest getBooksRequest);
    }
}