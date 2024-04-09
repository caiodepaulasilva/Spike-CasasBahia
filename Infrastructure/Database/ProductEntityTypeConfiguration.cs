using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Nome).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Preço).IsRequired().HasPrecision(10, 4);
        builder.Property(p => p.Quantidade).IsRequired();
        builder.Property(p => p.DataCadastro).IsRequired().HasDefaultValue(DateTime.Now);
    }
}
