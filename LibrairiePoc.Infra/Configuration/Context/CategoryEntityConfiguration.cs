using LibrairiePoc.Infra.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibrairiePoc.Infra
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryDto>
    {
        public void Configure(EntityTypeBuilder<CategoryDto> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(cat => cat.Id);
            builder.Property(cat => cat.Label);
            builder.HasMany(cat => cat.Books)
                   .WithOne(book => book.Category)
                   .HasForeignKey(book => book.CategoryId);
        }
    }
}