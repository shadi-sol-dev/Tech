using Microsoft.EntityFrameworkCore;
using PacificApi.Application.Interfaces;
using PacificApi.Domain.Entities;

namespace PacificApi.Infrastructure.DbContext;

public class ImageRepository : IImageRepository
{
    private readonly ImageDbContext _dbContext;

    public ImageRepository(ImageDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Images>> GetAllAsync()
    {
        return await _dbContext.Images.ToListAsync();
    }

    public async Task<Images> GetByIdAsync(int id)
    {
        try
        {

            return await _dbContext.Images.FirstOrDefaultAsync(e => e.id == id);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}