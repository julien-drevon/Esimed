namespace LibrairiePoc.Infra.Tests;

using FluentAssertions;
using LibrairiePoc.Infra.Ports.Primary;
using LibrairiePoc.UsesCase.Builder;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Tools;
using Xunit;

public class GettingBookAdapterShould
{

    GettingBookAdapter<PaginedData<Book>> GettingBookAdapter;

    public GettingBookAdapterShould(GettingBookAdapter<PaginedData<Book>> gettingBookAdapter)
    {
        this.GettingBookAdapter = gettingBookAdapter;
    }

    [Fact]
    public void GivenUser_ThenIGettingBooks_WhenShouldReturnPaginedListOfBook()
    {
        var assert = GettingBookAdapter.GetBooks(1, 20);
        assert.Should().BeEquivalentTo(
            new PaginedData<Book>()
            {
                Page = 1,
                PageSize = 20,
                Data = new[]
                {
                    new BookBuilder("CCIsbn")
                        .Title( "Clean Code")
                        .Autor( "Robert C Martin")
                        .Category( "technique")
                        .Price( 25.80m)
                        .Build()  ,
                    new BookBuilder("CDRIsbn")
                        .Title("Le cycle des robots")
                        .Autor("Isaac Asimov")
                        .Category("SF")
                        .Price(6m)
                        .Build()
                }
            });
    }

    [Fact]
    public void GivenUser_ThenIAskPage0_should_return_Page1()
    {
        var assert = GettingBookAdapter.GetBooks(0, 1);
        assert.Should().BeEquivalentTo(
            new PaginedData<Book>()
            {
                Page = 1,
                PageSize = 1,
                Data = new[]
                {
                    new BookBuilder("CCIsbn")
                        .Title( "Clean Code")
                        .Autor( "Robert C Martin")
                        .Category( "technique")
                        .Price( 25.80m)
                        .Build()
                }
            });
    }

    [Fact]
    public void GivenUser_ThenIAskPageSize0_should_return_PageSize20()
    {
        var assert = GettingBookAdapter.GetBooks(1, 0);
        assert.Should().BeEquivalentTo(
            new PaginedData<Book>()
            {
                Page = 1,
                PageSize = 20,
                Data = new[]
                {   new BookBuilder("CCIsbn")
                        .Title( "Clean Code")
                        .Autor( "Robert C Martin")
                        .Category( "technique")
                        .Price( 25.80m)
                        .Build()  ,
                    new BookBuilder("CDRIsbn")
                        .Title("Le cycle des robots")
                        .Autor("Isaac Asimov")
                        .Category("SF")
                        .Price(6m)
                        .Build()                  
                }
            });
    }
}
