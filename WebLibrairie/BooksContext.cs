namespace WebLibrairie;

using LibrairiePoc.Infra;
using LibrairiePoc.Infra.Dtos;
using Microsoft.EntityFrameworkCore;

public class BooksContext : DbContext  //BooksContext
{
    public BooksContext(DbContextOptions options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        CreateModelTools.CreateBookcontext(modelBuilder);

        modelBuilder.Entity<AuthorDto>().HasData(
            new AuthorDto()
            {
                Id = 1,
                Label = "Robert C Martin"
            },
            new AuthorDto()
            {
                Id = 2,
                Label = "Isaac Asimov",
            });

        modelBuilder.Entity<CategoryDto>().HasData(
            new CategoryDto()
            {
                Id = 1,
                Label = "technique"
            },
            new CategoryDto()
            {
                Id = 2,
                Label = "SF"
            });

        modelBuilder.Entity<BookDto>().HasData(
            new BookDto()
            {
                Id = 1,
                Title = "Clean Code",
                AuthorId = 1,
                CategoryId = 1,
                Price = 25.80m,
                Isbn = "CCIsbn"
            },
            new BookDto()
            {
                Id = 2,
                Title = "Le cycle des robots",
                AuthorId = 2,
                CategoryId = 2,
                Price = 6m,
                Isbn = "CDRIsbn"
            });
    }
}