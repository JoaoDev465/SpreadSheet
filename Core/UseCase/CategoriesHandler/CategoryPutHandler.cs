using Core.Contract;
using Core.Entities;
using Core.Interface;
using Core.Response;
using Core.ValueObjects.CategoryVO;

namespace Core.UseCase.CategoriesHandler;

public class CategoryPutHandler
{
    private readonly ICategoryRepo _repositorie;

    public CategoryPutHandler(ICategoryRepo repositorie)
    {
        _repositorie = repositorie;
    }

    public async Task<Responses<Category?>> PutCategoryAsync(CategoryContract contract)
    {
        var id = contract.Id;
        if (id == null)
        {
            return Responses<Category?>.NotFound(null);
        }

        var category = new Category(name: new Name(contract.Name),
            type: contract.Type);

        await _repositorie.Putasync(id,category);
        
        return Responses<Category?>.Success(category);
    }
}