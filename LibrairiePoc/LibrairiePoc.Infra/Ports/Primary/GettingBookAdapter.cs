using LibrairiePoc.UsesCase.CleanArchitecture;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Ports.Primary;
using LibrairiePoc.UsesCase.Ports.Secondary;
using LibrairiePoc.UsesCase.Request;
using LibrairiePoc.UsesCase.Tools;
using LibrairiePoc.UsesCase.UsesCase;

namespace LibrairiePoc.Infra.Ports.Primary
{
    public class GettingBookAdapter<Tout>

    {
        private readonly IBookRepository _BookRepository;

        private readonly IPresenter<PaginedData<Book>, Tout> _Presenter;

        public GettingBookAdapter(IPresenter<PaginedData<Book>, Tout> presenter, IBookRepository bookRepository)
        {
            this._Presenter = presenter;
            this._BookRepository = bookRepository;
        }

        //public Tout GetBooks(int page, int pageSize)
        //{
        //    (new GettingBooksManager(_BookRepository, _Presenter)).ClientGetBooks(new GetBooksRequest()
        //    {
        //        PageNumber = page < 1 ? 1 : page,
        //        PageSize = pageSize < 1 ? 20 : pageSize
        //    });

        //    return _Presenter.GetData();
        //}

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