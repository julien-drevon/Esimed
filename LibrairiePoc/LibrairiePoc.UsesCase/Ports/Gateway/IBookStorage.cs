using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Request;
using LibrairiePoc.UsesCase.Tools;

namespace LibrairiePoc.UsesCase.Ports.Gateway
{
    public interface IBookGateway
    {
         PaginedData<Book> GetMany(GetBooksRequest getBooksRequest);
    }
}