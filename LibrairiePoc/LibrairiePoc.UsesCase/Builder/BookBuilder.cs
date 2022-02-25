namespace LibrairiePoc.UsesCase.Builder;

using LibrairiePoc.UsesCase.Entities;

public class BookBuilder
{
    private readonly BookForBookBuilder _Book;

    public BookBuilder(string isbn)
    {
        _Book = new BookForBookBuilder()
        {
            Isbn = isbn
        };
    }

    public BookBuilder Autor(string autor)
    {
        _Book.Autor = autor;
        return this;
    }

    public Book Build()
    {
        var result = new Book(_Book.Isbn, _Book.Title, _Book.Autor, _Book.Price, _Book.Category);
        if (result.IsValid() is false)
        {
            throw new BookBuildException("Book not set correctly");
        }
        return result;
    }

    public BookBuilder Category(string category)
    {
        _Book.Category = category;
        return this;
    }

    public BookBuilder Price(decimal price)
    {
        _Book.Price = price;
        return this;
    }

    public BookBuilder Title(string title)
    {
        _Book.Title = title;
        return this;
    }

    private class BookForBookBuilder
    {
        public string Autor { get; set; }

        public string Category { get; set; } = "";

        public string Isbn { get; set; }

        public decimal Price { get; set; }

        public string Title { get; set; }
    }
}