namespace LibrairiePoc.UsesCase.Tests;

using FluentAssertions;
using LibrairiePoc.UsesCase.Entities;
using Xunit;

public class BookShould
{
    [Fact]
    public void Book_ShouldHave_Reference()
    {
        var book = new Book("isbn", string.Empty, string.Empty, 0, string.Empty);
        book.Isbn.Should().Be("isbn");
    }

    [Fact]
    public void Book_ShouldHave_Title()
    {
        var book = new Book(string.Empty, "title", string.Empty, 0, string.Empty);
        book.Title.Should().Be("title");
    }

    [Fact]
    public void Book_Should_Have_Autors()
    {
        var book = new Book(string.Empty, string.Empty, "autor", 0, string.Empty);
        book.Autor.Should().Be("autor");
    }

    [Fact]
    public void Book_Can_Have_Price()
    {
        var book = new Book(string.Empty, string.Empty, string.Empty, 42m, string.Empty);
        book.Price.Should().Be(42m);
    }

    [Fact]
    public void Book_Can_Have_Category()
    {
        var book = new Book(string.Empty, string.Empty, string.Empty, 0, "category");
        book.Category.Should().Be("category");
    }

    [Fact]
    public void Bokk_IsValid_Should_Have_Isbn()
    {
        var book = new Book(string.Empty, "title", "autor");
        book.IsValid().Should().BeFalse();
    }

    [Fact]
    public void Bokk_IsValid_Should_Have_Title()
    {
        var book = new Book("Isbn", null, "autor");
        book.IsValid().Should().BeFalse();
    }

    [Fact]
    public void Bokk_IsValid_Should_Have_Autor()
    {
        var book = new Book("Isbn", "title", null);
        book.IsValid().Should().BeFalse();
    }
}