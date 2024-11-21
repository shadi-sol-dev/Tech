using Microsoft.EntityFrameworkCore;
using PacificApi.Domain.Entities;

namespace PacificApi.Infrastructure.DbContext;

public class ImageDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ImageDbContext(DbContextOptions<ImageDbContext> options) : base(options)
    {
    }

    public DbSet<Images> Images { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure your entity mappings
        modelBuilder.Entity<Images>().ToTable("images"); 
    }
}