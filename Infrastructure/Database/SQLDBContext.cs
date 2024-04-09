using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class SQLDBContext(DbContextOptions<SQLDBContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());

        //modelBuilder.Seed();
    }
}

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Nome = "Enfermedad" },
            new Product { Id = 2, Nome = "Diligencias" },
            new Product { Id = 3, Nome = "Otros" }
            );
    }
}