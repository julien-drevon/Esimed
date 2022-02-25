namespace LibrairiePoc2.UseCase
{


    public class GettingBooksUseCase
    {
        public GettingBooksUseCase(IBookCatalogue bookCatalogue)
        {
            this.BookCatalogue = bookCatalogue;
        }

        public IBookCatalogue BookCatalogue { get; }

        public void Execute(GetingBookRequest getingBookRequest, IPresenter<PaginationData<Book>> bookPresenter)
        {
            var books = this.BookCatalogue.GetAll()
                       .Skip((getingBookRequest.PageNumber - 1) * getingBookRequest.PageSize)
                       .Take(getingBookRequest.PageSize)
                       .ToArray();

            var result = new PaginationData<Book>()
            {
                Data = books,
                PageNumber = getingBookRequest.PageNumber,
                PageSize = getingBookRequest.PageSize,
            };

            bookPresenter.Present(result);
        }
    }  

}