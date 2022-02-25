using FluentAssertions;
using Xunit;

namespace LibrairiePoc2.UseCase.Tests
{
    public class CreateUserAccouintUseCaseShould
    {
        [Fact]
        public void GivenUnknownUser_ShouldICanCreateAccount()
        {

        }
    }



    public class BookPresenter : IPresenter<PaginationData<Book>>
    {
        private PaginationData<Book> pagination;

        public PaginationData<Book> GetResult()
        {
            return this.pagination;
        }

        public void Present(PaginationData<Book> paginatioBooks)
        {
            this.pagination = paginatioBooks;
        }
    }


    public class GettingBooksUseCaseShould //: IPresenter<PaginationData<Book>>
    {

        public GettingBooksUseCaseShould()
        {
            this.bookPresenter = new BookPresenter();
        }

        public IPresenter<PaginationData<Book>> bookPresenter;

        [Fact]
        public void gettingBookShould()
        {
            var gettingBookPresneter = this.bookPresenter;
            var gettingBook = new GettingBooksUseCase(new BookCatalogue2());
            gettingBook.Execute(new GetingBookRequest() { PageNumber = 1, PageSize = 1 }, gettingBookPresneter);
            gettingBookPresneter.GetResult().Should().BeEquivalentTo(
                new PaginationData<Book>()
                {
                    Data =
                    new[] { new Book("isbn1", "title1") },
                    PageNumber = 1,
                    PageSize = 1,
                });
        }

        [Fact]
        public void gettingBookShouldReturn2elements()
        {
            var gettingBook = new GettingBooksUseCase(new BookCatalogue2());
            var gettingBookPresneter = this.bookPresenter;

            gettingBook.Execute(new GetingBookRequest() { PageNumber = 1, PageSize = 2 }, gettingBookPresneter);
            gettingBookPresneter.GetResult().Should().BeEquivalentTo(
                new PaginationData<Book>()
                {
                    Data = new[] { new Book("isbn1", "title1"), new Book("isbn2", "title2") },
                    PageNumber = 1,
                    PageSize = 2,
                });
        }

        [Fact]
        public void gettingBookShouldReturnPage2and2elements()
        {
            var gettingBook = new GettingBooksUseCase(new BookCatalogue2());
            var gettingBookPresneter = this.bookPresenter;

            gettingBook.Execute(new GetingBookRequest() { PageNumber = 2, PageSize = 2 }, gettingBookPresneter);
            gettingBookPresneter.GetResult().Should().BeEquivalentTo(
                new PaginationData<Book>()
                {
                    Data = new[] { new Book("isbn3", "title3"), new Book("isbn4", "title4") },
                    PageNumber = 2,
                    PageSize = 2,
                });
        }

        [Fact]
        public void gettingBookShouldReturnPage3and2elements()
        {
            var gettingBook = new GettingBooksUseCase(new BookCatalogue2());
            var gettingBookPresneter = this.bookPresenter;

            gettingBook.Execute(new GetingBookRequest() { PageNumber = 3, PageSize = 2 }, gettingBookPresneter);
            gettingBookPresneter.GetResult().Should().BeEquivalentTo(
                new PaginationData<Book>()
                {
                    Data = new[] { new Book("isbn5", "title5"), new Book("isbn6", "title6") },
                    PageNumber = 3,
                    PageSize = 2,
                });
        }

        [Fact]
        public void gettingBookShouldReturn2elements_2()
        {
            var gettingBook = new GettingBooksUseCase(new BookCatalogue());
            var gettingBookPresneter = this.bookPresenter;

            gettingBook.Execute(new GetingBookRequest() { PageNumber = 1, PageSize = 2 }, gettingBookPresneter);
            gettingBookPresneter.GetResult().Should().BeEquivalentTo(
                new PaginationData<Book>()
                {
                    Data = new[] { new Book("isbnToto", "titleToto"), new Book("isbnTiti", "titleTiti") },
                    PageNumber = 1,
                    PageSize = 2,
                });
        }


        PaginationData<Book> _Result;
        public void Present(PaginationData<Book> data)
        {
            this._Result = data;
        }

        public PaginationData<Book> GetResult()
        {
            return this._Result;
        }
    }

}