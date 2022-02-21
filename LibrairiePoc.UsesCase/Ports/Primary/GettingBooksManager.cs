using LibrairiePoc.UsesCase.CleanArchitecture;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Ports.Secondary;
using LibrairiePoc.UsesCase.Request;
using LibrairiePoc.UsesCase.Tools;
using LibrairiePoc.UsesCase.UsesCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrairiePoc.UsesCase.Ports.Primary
{
    public class GettingBooksManager
    {
        public GettingBooksManager(IBookRepository bookRepo, IInPresenter<PaginedData<Book>> bookPresenter)
        {
            BookRepository = bookRepo;
            _BookPresenter = bookPresenter;

        }
        private IInPresenter<PaginedData<Book>> _BookPresenter;

        private readonly IBookRepository BookRepository;
        public void ClientGetBooks(GetBooksRequest getBooksRequest)
        {
            var usecase = new ClientGetBooksUseCase(BookRepository);
            usecase.Execute(getBooksRequest, _BookPresenter);
        }
    }

}
