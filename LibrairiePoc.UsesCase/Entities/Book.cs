using LibrairiePoc.UsesCase.Tools;

namespace LibrairiePoc.UsesCase.Entities;

public class Book
{
    public Book(string isbn, string title, string autor, decimal price = 0m, string category = "")
    {
        Isbn = isbn;
        Title = title;
        Autor = autor;
        Price = price;
        Category = category;
    }

    public decimal Price { get; set; }

    public string Isbn { get; private set; }

    public string Title { get; private set; }

    public string Autor { get; private set; }

    public string Category { get; set; }

    public bool IsValid()
    {
        return Isbn.IsNullOrEmpty() is false
                && Title.IsNullOrEmpty() is false
                && Autor.IsNullOrEmpty() is false;
    }
}