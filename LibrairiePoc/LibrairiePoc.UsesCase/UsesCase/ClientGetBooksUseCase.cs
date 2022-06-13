using LibrairiePoc.UsesCase.CleanArchitecture;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Ports.Gateway;
using LibrairiePoc.UsesCase.Request;
using LibrairiePoc.UsesCase.Tools;

namespace LibrairiePoc.UsesCase.UsesCase
{
    public class ClientGetBooksUseCase
    {
        private readonly IBookGateway BookGateway;

        public ClientGetBooksUseCase(IBookGateway repository)
        {
            this.BookGateway = repository;
        }

        public void Execute(GetBooksRequest getBooksRequest, IInPresenter<PaginedData<Book>> presenter)
        {
            var books = this.BookGateway.GetMany(getBooksRequest);
            presenter.Present(books);
        }
    }
}