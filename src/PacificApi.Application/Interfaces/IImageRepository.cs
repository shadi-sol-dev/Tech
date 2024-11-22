using PacificApi.Domain.Entities;

namespace PacificApi.Application.Interfaces;

public interface IImageRepository
{
    Task<List<Images>> GetAllAsync();
    Task<Images> GetByIdAsync(int id);
    Task AddAsync(Images image);    
}