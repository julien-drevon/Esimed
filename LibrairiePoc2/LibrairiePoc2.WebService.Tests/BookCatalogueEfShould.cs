using FluentAssertions;
using LibrairiePoc2.UseCase;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace LibrairiePoc2.WebService.Tests
{


    public class BookCatalogueEfShould
    {
        public BookCatalogueEfShould(DbContext dbcontext, IMonconverter<BookDTO, Book> converter)
        {
            this.DbContext = dbcontext;
            this.Converter = converter;
        }

        public DbContext DbContext { get; }
        public IMonconverter<BookDTO, Book> Converter { get; }

        [Fact]
        public void DebileTest()
        {
            false.Should().BeFalse();
        }

        [Fact]
        public void TestGetAllCatalogueEF()
        {
            var assert = new BookCatalogueEF(this.DbContext, this.Converter);
            assert.GetAll().Should().BeEquivalentTo(new[]
            {
                new Book("totoIsbn","totoTitle"),
                new Book("tataIsbn","tataTitle"),
                new Book("titiIsbn","titiTitle")
            });
        }

        [Fact]
        public void AddABookInCatalogue()
        {
            var book = new Book("testToAdd", "titreToAdd");
            var bookCatalogue = new BookCatalogueEF(this.DbContext, this.Converter);
            bookCatalogue.AddBook(book);
            DbContext.Set<BookDTO>().Single(x => x.Isbn == "testToAdd").Should().BeEquivalentTo(book);
        }

    }

   
}