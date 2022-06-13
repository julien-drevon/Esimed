using LibrairiePoc.UsesCase.CleanArchitecture;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Ports.Gateway;
using LibrairiePoc.UsesCase.Ports.Controller;
using LibrairiePoc.UsesCase.Request;
using LibrairiePoc.UsesCase.Tools;
using LibrairiePoc.UsesCase.UsesCase;

namespace LibrairiePoc.Infra.Ports.Gateway
{
    public class GettingBookGateway<Tout>

    {
        private readonly IBookStorage _BookRepository;

        private readonly IPresenter<PaginedData<Book>, Tout> _Presenter;

        public GettingBookGateway(IPresenter<PaginedData<Book>, Tout> presenter, IBookStorage bookRepository)
        {
            this._Presenter = presenter;
            this._BookRepository = bookRepository;
        }

        public Tout GetBooks(int page, int pageSize)
        {
            var getBooksRequest = new GetBooksRequest()
            {
                PageNumber = page < 1 ? 1 : page,
                PageSize = pageSize < 1 ? 20 : pageSize
            };

            var usecase = new ClientGetBooksUseCase(_BookRepository);
            usecase.Execute(getBooksRequest, _Presenter);

            return _Presenter.GetData();
        }
    }
}