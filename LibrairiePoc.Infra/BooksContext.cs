using Microsoft.EntityFrameworkCore;

namespace LibrairiePoc.Infra
{
    public class BooksContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            CreateModelTools.CreateBookcontext(builder);
        }
    }

    public class CreateModelTools
    {
        public static ModelBuilder CreateBookcontext(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AuthorEntityConfiguration());
            builder.ApplyConfiguration(new CategoryEntityConfiguration());
            builder.ApplyConfiguration(new BookEntityConfiguration());

            return builder;
        }
    }
}