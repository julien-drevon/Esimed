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

namespace LibrairiePoc.UsesCase.Managers
{
    public class GettingBooksManager
    {
        public GettingBooksManager(IBookRepository bookRepo)
        {
            this.BookRepository = bookRepo;
        }

        private readonly IBookRepository BookRepository;
        public void ClientGetBooks(GetBooksRequest getBooksRequest, IInPresenter<PaginedData<Book>> presenter)
        {
            var usecase = new ClientGetBooksUseCase(BookRepository);
            usecase.Execute(getBooksRequest, presenter);
        }
    }

}
