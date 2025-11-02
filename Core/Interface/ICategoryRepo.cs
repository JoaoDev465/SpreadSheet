using Core.Entities;
using Core.Response;
using Core.ValueObjects.CategoryVO;

namespace Core.Interface;

public interface ICategoryRepo
{
    public Task AddAsync(Category category);
    public Task Putasync(Category category);
    public Task<Category?> GetById(Id id);
    public Task<PagedResponse<List<Category?>>> GetAll(Category category);
}