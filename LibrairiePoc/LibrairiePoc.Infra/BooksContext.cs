using LibrairiePoc.Infra.Dtos;
using Microsoft.EntityFrameworkCore;

namespace LibrairiePoc.Infra
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions options)
               : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            CreateModelTools.CreateBookcontext(builder);
            SeedDataBase(builder);
        }

        private static void SeedDataBase(ModelBuilder builder)
        {
            builder.Entity<AuthorDto>().HasData(
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

            builder.Entity<CategoryDto>().HasData(
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

            builder.Entity<BookDto>().HasData(
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
}