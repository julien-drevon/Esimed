using LibrairiePoc.UsesCase.CleanArchitecture;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Ports.Controller;
using LibrairiePoc.UsesCase.Ports.Gateway;
using LibrairiePoc.UsesCase.Request;
using LibrairiePoc.UsesCase.Tools;
using LibrairiePoc.UsesCase.UsesCase;

namespace LibrairiePoc.Infra.Ports.Controller
{
    public class GettingBookApplicationController<Tout>

    {
        private readonly IBookGateway _BookGateway;

        private readonly IPresenter<PaginedData<Book>, Tout> _Presenter;

        public GettingBookApplicationController(IPresenter<PaginedData<Book>, Tout> presenter, IBookGateway bookRepository)
        {
            this._Presenter = presenter;
            this._BookGateway = bookRepository;
        }

        public Tout GetBooks(int page, int pageSize)
        {
            var getBooksRequest = new GetBooksRequest()
            {
                PageNumber = page < 1 ? 1 : page,
                PageSize = pageSize < 1 ? 20 : pageSize
            };

            var usecase = new ClientGetBooksUseCase(_BookGateway);
            usecase.Execute(getBooksRequest, _Presenter);

            return _Presenter.GetData();
        }
    }
}