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

public class BookRepositoryEFShould
{
    public BookRepositoryEFShould(BookRepositoryEF bookEf)
    {
        this.bookRepository = bookEf;
    }

    public IBookRepository bookRepository; //= new BooksContextFact();

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
}
