using FluentAssertions;
using LibrairiePoc.UsesCase.CleanArchitecture;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Request;
using LibrairiePoc.UsesCase.Tools;
using LibrairiePoc.UsesCase.UsesCase;
using Xunit;

namespace LibrairiePoc.UsesCase.Tests.UsesCase
{
    public class ArticlesHomePrintUseCaseShould
    {
        private IPresenter<PaginedData<Book>, PaginedData<Book>> _Presenter;

        public ArticlesHomePrintUseCaseShould()
        {
            _Presenter = new SimplePresenter<PaginedData<Book>>();
        }

        [Fact]
        public void GivenClient_WhenIGetBokks_ShouldReturn20ByDEfault()
        {
            var assert = new ClientGetBooksUseCase(new BookRepositoryFact());
            assert.Execute(new GetBooksRequest(), _Presenter);
            _Presenter.GetData().Should().BeEquivalentTo(new PaginedData<Book>()
            {
                Data = new[] { new Book("10022544", "Clean code", "Robert C Matins", 42, "technique") },
                Page = 1,
                PageSize = 20,
            });
        }
    }
}