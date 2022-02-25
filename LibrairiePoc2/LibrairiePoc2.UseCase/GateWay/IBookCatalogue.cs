namespace LibrairiePoc2.UseCase
{
    public interface IBookCatalogue
    {
        IQueryable<Book> GetAll();
    }
}