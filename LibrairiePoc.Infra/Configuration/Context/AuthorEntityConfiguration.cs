using LibrairiePoc.Infra.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibrairiePoc.Infra
{
    public class AuthorEntityConfiguration : IEntityTypeConfiguration<AuthorDto>
    {
        public void Configure(EntityTypeBuilder<AuthorDto> builder)
        {
            builder.ToTable("Author");
            builder.HasKey(author => author.Id);
            builder.Property(author => author.Label).HasColumnName("Name");
            builder.HasMany(author => author.Books)
                   .WithOne(book => book.Author)
                   .HasForeignKey(book => book.AuthorId);
        }
    }
}
