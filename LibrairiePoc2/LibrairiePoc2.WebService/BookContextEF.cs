using Microsoft.EntityFrameworkCore;

namespace LibrairiePoc2.WebService
{
    public class BookContextEF : DbContext
    {
        public BookContextEF(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDTO>(model =>
            {
                model.ToTable("Book");
                model.HasKey(x => x.Isbn);
                model.Property(x => x.Title).IsRequired();
            });
        }
    }
}