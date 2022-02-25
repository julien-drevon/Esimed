using Microsoft.EntityFrameworkCore;

namespace LibrairiePoc2.WebService.Tests
{
    public class BookContextInMemoryEF : BookContextEF
    {

        public BookContextInMemoryEF(DbContextOptions options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BookDTO>(bookDTO =>
            {
                bookDTO.HasData(
                    new BookDTO() { Isbn = "totoIsbn", Title = "totoTitle" },
                    new BookDTO() { Isbn = "tataIsbn", Title = "tataTitle" },
                    new BookDTO() { Isbn = "titiIsbn", Title = "titiTitle" }
                    );
            });
        }
    }

   
}