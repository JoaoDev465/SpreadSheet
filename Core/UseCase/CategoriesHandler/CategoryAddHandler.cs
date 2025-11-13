using Core.Contract;
using Core.Entities;
using Core.Interface;
using Core.Response;
using Core.ValueObjects.CategoryVO;

namespace Core.UseCase.CategoriesHandler;

public class CategoryAddHandler
{
    private readonly ICategoryRepo _repositorie;

    public CategoryAddHandler(ICategoryRepo repositorie)
    {
        _repositorie = repositorie;
    }

    public async Task<Responses<Category?>> AddCategoryAsync(CategoryContract contract)
    {
        var category =   new Category(name: new Name(contract.Name),
            type: contract.Type);

        await _repositorie.AddAsync(category);
        
        return Responses<Category?>.Success(category);
    }
}