using FluentAssertions;
using LibrairiePoc.UsesCase.CleanArchitecture;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Ports.UseCaseInteractors;
using LibrairiePoc.UsesCase.Request;
using LibrairiePoc.UsesCase.Tests.UsesCase;
using LibrairiePoc.UsesCase.Tools;
using System;
using Xunit;

namespace LibrairiePoc.UsesCase.Tests
{
    public class GettingBooksManagerShould : IInPresenter<PaginedData<Book>>
    {
        private PaginedData<Book> _Data;

        [Fact]
        public void GivenUser_WhenIRequestBooks_ShouldReturnPaginedBooks()
        {
           // IPresenter<PaginedData<Book>, PaginedData<Book>> presenter = new SimplePresenter<PaginedData<Book>>();
            var manager = new GettingBooksInteractor(new BookRepositoryFact(), this);
            GetBooksRequest request = new();
            manager.ClientGetBooks(request);
            this.GetData().Should().BeEquivalentTo(new PaginedData<Book>()
            {
                Data = new[] { new Book("10022544", "Clean code", "Robert C Matins", 42, "technique") },
                Page = 1,
                PageSize = 20,
            });
        }

        private object GetData()
        {
            return _Data;
        }

        public void Present(PaginedData<Book> data)
        {
            _Data = data;
        }
    }
}