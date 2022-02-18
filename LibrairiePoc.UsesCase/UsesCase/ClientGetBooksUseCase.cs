using LibrairiePoc.UsesCase.CleanArchitecture;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Ports.Secondary;
using LibrairiePoc.UsesCase.Request;
using LibrairiePoc.UsesCase.Tools;

namespace LibrairiePoc.UsesCase.UsesCase
{
    public class ClientGetBooksUseCase
    {
        private readonly IBookRepository BooksRepository;

        public ClientGetBooksUseCase(IBookRepository repository)
        {
            this.BooksRepository = repository;
        }
        public void Execute(GetBooksRequest getBooksRequest, IInPresenter<PaginedData<Book>> presenter)
        {
            var books = this.BooksRepository.GetMany(getBooksRequest);
            presenter.Present(books);
        }
    }
}