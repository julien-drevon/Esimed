using LibrairiePoc.UsesCase.CleanArchitecture;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Ports.Primary;
using LibrairiePoc.UsesCase.Ports.Secondary;
using LibrairiePoc.UsesCase.Request;
using LibrairiePoc.UsesCase.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrairiePoc.Infra.Ports.Primary
{
    public class GettingBookAdapter
    {
        IPresenter<PaginedData<Book>, PaginedData<Book>> _Presenter;
        IBookRepository _BookRepository;

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
