namespace LibrairiePoc.UsesCase.Tests;

using FluentAssertions;
using LibrairiePoc.UsesCase.Builder;
using LibrairiePoc.UsesCase.Entities;
using Xunit;

//ref/isbn , titre , auteur, prix, categorie

public class BookFactoryShould
{
    [Fact]
    public void InvalidBook_ShouldNotBeBuild_AndThrowAnException()
    {
        var assert = Assert.Throws<BookBuildException>(() => (new BookBuilder("")).Build());
        assert.Message.Should().Contain("Book not set correctly");
    }

    [Fact]
    public void ValidBook_Should_BeBuild()
    {
        var assert = new BookBuilder("isbn")
                    .Title("title")
                    .Autor("autor")
                    .Build();
        assert.Should().BeEquivalentTo(new Book("isbn", "title", "autor"));
    }

    [Fact]
    public void BookBuilder_Should_BuildPrice()
    {
        var assert = new BookBuilder("isbn")
                    .Title("title")
                    .Autor("autor")
                    .Price(42m)
                    .Build();
        assert.Should().BeEquivalentTo(new Book("isbn", "title", "autor", 42m));
    }

    [Fact]
    public void BookBuilder_Should_BuildCategory()
    {
        var assert = new BookBuilder("isbn")
                     .Title("title")
                     .Autor("autor")
                     .Category("cat")
                     .Build();
        assert.Should().BeEquivalentTo(new Book("isbn", "title", "autor", category: "cat"));
    }
}