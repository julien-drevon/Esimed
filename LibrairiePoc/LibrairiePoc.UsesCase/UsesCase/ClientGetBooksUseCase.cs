using LibrairiePoc.UsesCase.CleanArchitecture;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Ports.Controller;
using LibrairiePoc.UsesCase.Request;
using LibrairiePoc.UsesCase.Tools;

namespace LibrairiePoc.UsesCase.UsesCase
{
    public class ClientGetBooksUseCase
    {
        private readonly IBookStorage BookController;

        public ClientGetBooksUseCase(IBookStorage repository)
        {
            this.BookController = repository;
        }

        public void Execute(GetBooksRequest getBooksRequest, IInPresenter<PaginedData<Book>> presenter)
        {
            var books = this.BookController.GetMany(getBooksRequest);
            presenter.Present(books);
        }
    }
}