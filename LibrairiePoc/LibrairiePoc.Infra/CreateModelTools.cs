using Microsoft.EntityFrameworkCore;

namespace LibrairiePoc.Infra
{
    public static class CreateModelTools
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