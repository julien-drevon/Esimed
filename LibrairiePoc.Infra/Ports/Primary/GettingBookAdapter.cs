using LibrairiePoc.UsesCase.CleanArchitecture;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Ports.Primary;
using LibrairiePoc.UsesCase.Ports.Secondary;
using LibrairiePoc.UsesCase.Request;
using LibrairiePoc.UsesCase.Tools;

namespace LibrairiePoc.Infra.Ports.Primary
{
    public class GettingBookAdapter
    {
        private readonly IBookRepository _BookRepository;

        private readonly IPresenter<PaginedData<Book>, PaginedData<Book>> _Presenter;

        public GettingBookAdapter(IPresenter<PaginedData<Book>, PaginedData<Book>> presenter, IBookRepository bookRepository)
        {
            this._Presenter = presenter;
            this._BookRepository = bookRepository;
        }

        public PaginedData<Book> GetBooks(int page, int pageSize)
        {
            (new GettingBooksManager(_BookRepository, _Presenter)).ClientGetBooks(new GetBooksRequest()
            {
                PageNumber = page,
                PageSize = pageSize
            });

            return _Presenter.GetData();
        }
    }
}