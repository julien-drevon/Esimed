using LibrairiePoc.Infra.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibrairiePoc.Infra
{
    public class BookEntityConfiguration : IEntityTypeConfiguration<BookDto>
    {
        public void Configure(EntityTypeBuilder<BookDto> builder)
        {
            builder.ToTable("Book");
            builder.HasKey(book => book.Id);
            builder.Property(book => book.Title);
            builder.HasOne(x => x.Author)
                   .WithMany(x => x.Books)
                   .HasForeignKey(book => book.AuthorId);
            builder.HasOne(x => x.Category)
                   .WithMany(x => x.Books)
                   .HasForeignKey(book => book.CategoryId);
        }
    }
}
