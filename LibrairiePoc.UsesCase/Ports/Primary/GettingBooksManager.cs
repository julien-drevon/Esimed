using LibrairiePoc.UsesCase.CleanArchitecture;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Ports.Secondary;
using LibrairiePoc.UsesCase.Request;
using LibrairiePoc.UsesCase.Tools;
using LibrairiePoc.UsesCase.UsesCase;

namespace LibrairiePoc.UsesCase.Ports.Primary
{
    public class GettingBooksManager
    {
        private readonly IBookRepository BookRepository;

        private IInPresenter<PaginedData<Book>> _BookPresenter;

        public GettingBooksManager(IBookRepository bookRepo, IInPresenter<PaginedData<Book>> bookPresenter)
        {
            BookRepository = bookRepo;
            _BookPresenter = bookPresenter;
        }

        public void ClientGetBooks(GetBooksRequest getBooksRequest)
        {
            var usecase = new ClientGetBooksUseCase(BookRepository);
            usecase.Execute(getBooksRequest, _BookPresenter);
        }
    }
}