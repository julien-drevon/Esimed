using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace LibrairiePoc2.UseCase.Tests
{
    public class BookShould
    {
        [Fact]
        public void ShouldBeTitle()
        {
            var book = new Book("isbn", "title");
            book.Title.Should().Be("title");
        }

        [Fact]
        public void ShouldBeIsbn()
        {
            var book = new Book("isbn", "title");
            book.Isbn.Should().Be("isbn");
        }
    }

    public class BookCatalogue2 : IBookCatalogue
    {
        public IQueryable<Book> GetAll()
        {
            return new[] { new Book("isbn1", "title1"), new Book("isbn2", "title2"), new Book("isbn3", "title3"), new Book("isbn4", "title4"), new Book("isbn5", "title5"), new Book("isbn6", "title6") }.AsQueryable();
        }
    }

    public class BookCatalogue : IBookCatalogue
    {
        public IQueryable<Book> GetAll()
        {
            return new[] { new Book("isbnToto", "titleToto"), new Book("isbnTiti", "titleTiti") }.AsQueryable();
        }
    }

}