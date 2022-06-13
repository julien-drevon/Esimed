using LibrairiePoc.UsesCase.CleanArchitecture;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Ports.Secondary;
using LibrairiePoc.UsesCase.Request;
using LibrairiePoc.UsesCase.Tools;
using LibrairiePoc.UsesCase.UsesCase;

namespace LibrairiePoc.UsesCase.Ports.Primary
{
    public class GettingBooksMediator
    {
        private readonly IInPresenter<PaginedData<Book>> _BookPresenter;

        private readonly IBookRepository _BookRepository;

        public GettingBooksMediator(IBookRepository bookRepo, IInPresenter<PaginedData<Book>> bookPresenter)
        {
            _BookRepository = bookRepo;
            _BookPresenter = bookPresenter;
        }

        public void ClientGetBooks(GetBooksRequest getBooksRequest)
        {
            var usecase = new ClientGetBooksUseCase(_BookRepository);
            usecase.Execute(getBooksRequest, _BookPresenter);
        }
    }
}