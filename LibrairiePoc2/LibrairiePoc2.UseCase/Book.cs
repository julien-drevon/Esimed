namespace LibrairiePoc2.UseCase
{
    public class Book
    {
        public Book(string isnb, string title)
        {
            Isbn = isnb;
            Title = title;
        }

        public string Isbn { get; set; }
        public string Title { get; set; }
    }
}