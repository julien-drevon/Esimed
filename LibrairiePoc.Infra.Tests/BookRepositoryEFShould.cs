namespace LibrairiePoc.Infra.Tests;

using FluentAssertions;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Ports.Secondary;
using LibrairiePoc.UsesCase.Request;
using LibrairiePoc.UsesCase.Tools;
using Xunit;
using System.Linq;
using LibrairiePoc.UsesCase.Builder;
using System.Diagnostics.CodeAnalysis;
using LibrairiePoc.Infra.Ports.Secondary;

public class BookRepositoryEFShould
{
    public IBookRepository bookRepository;

    public BookRepositoryEFShould(BookRepositoryEF bookEf)
    {
        this.bookRepository = bookEf;
    }

    [Fact]
    public void BookRepository_GetMany_ShouldReturn_PaginedBook()
    {
        var assert = bookRepository.GetMany(new GetBooksRequest());
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
    public void BookRepository_GetMany_WithPageSizeAt1AndPageNumberAt2_ShouldReturnCorectPagination()
    {
        var assert = bookRepository.GetMany(new GetBooksRequest() { PageSize = 1, PageNumber = 2 });
        assert.Should().BeEquivalentTo(
            new PaginedData<Book>()
            {
                Page = 2,
                PageSize = 1,
                Data = new[]
                {
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
