using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class KafkaContext(DbContextOptions<KafkaContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }    
}