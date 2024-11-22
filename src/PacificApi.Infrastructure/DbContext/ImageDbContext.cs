using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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

partial class ImageDbContextDesignTime : IDesignTimeDbContextFactory<ImageDbContext>
{
    public ImageDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ImageDbContext>();
        optionsBuilder.UseSqlite("Data Source=data.db");

        return new ImageDbContext(optionsBuilder.Options);
    }
}