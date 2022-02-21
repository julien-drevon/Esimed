using FluentAssertions;
using LibrairiePoc.UsesCase.CleanArchitecture;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Ports.Primary;
using LibrairiePoc.UsesCase.Request;
using LibrairiePoc.UsesCase.Tests.UsesCase;
using LibrairiePoc.UsesCase.Tools;
using Xunit;

namespace LibrairiePoc.UsesCase.Tests
{
    public class GettingBooksManagerShould
    {
        [Fact]
        public void GettingBooks_Should_ClientGetBooksUseCase()
        {
            var manager = new GettingBooksManager(new BookRepositoryFact());
            IPresenter<PaginedData<Book>, PaginedData<Book>> presenter = new SimplePresenter<PaginedData<Book>>();
            GetBooksRequest request = new();
            manager.ClientGetBooks(request, presenter);
            presenter.GetData().Should().BeEquivalentTo(new PaginedData<Book>()
            {
                Data = new[] { new Book("10022544", "Clean code", "Robert C Matins", 42, "technique") },
                Page = 1,
                PageSize = 20,
            });
        }
    }
}