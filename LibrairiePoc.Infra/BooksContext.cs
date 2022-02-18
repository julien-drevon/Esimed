using Microsoft.EntityFrameworkCore;

namespace LibrairiePoc.Infra
{
    public class BooksContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AuthorEntityConfiguration());
            builder.ApplyConfiguration(new CategoryEntityConfiguration());
            builder.ApplyConfiguration(new BookEntityConfiguration());
        }
    }
}