using Core.Entities;
using Core.Response;
using Core.ValueObjects.CategoryVO;

namespace Core.Interface;

public interface ICategoryRepo
{
    public Task AddAsync(Category category);
    public Task Putasync(int id,Category category);
    public Task<Category?> GetById(int id);
    public Task<PagedResponse<List<Category?>>> GetAll(Id CategoryId);
}