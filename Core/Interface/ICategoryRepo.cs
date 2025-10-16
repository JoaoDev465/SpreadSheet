using Core.Entities;
using Core.ValueObjects.CategoryVO;

namespace Core.Interface;

public interface ICategoryRepo
{
    public Task AddAsync(Category category);
    public Task Putasync(Category category);
    public Task<Category?> GetById(Id id);
    public Task<List<Category?>> GetAll();
}