using Core.Contract;
using Core.Entities;
using Core.Interface;
using Core.Response;
using Core.ValueObjects.CategoryVO;

namespace Core.UseCase.CategoriesHandler;

public class CategoryGetHandler
{
    private readonly ICategoryRepo _repositorie;

    public CategoryGetHandler(ICategoryRepo repositorie)
    {
        _repositorie = repositorie;
    }

    public async Task<Responses<Category?>> GetCategoriesById(CategoryContract contract)
    {
        var id = contract.Id;
        if(id == null)
            return Responses<Category?>.NotFound(null);

        var categories = await _repositorie.GetById(id);
        
        return Responses<Category?>.Success(categories);
    }

    public async Task<Responses<List<Category?>>> GeCategories(CategoryContract contract)
    {
        var id = new Id(contract.Id);

        if (id.Value == null)
        {
            return PagedResponse<List<Category?>>.NotFound(null);
        }

        var categorie = await _repositorie.GetAll(id);

        return PagedResponse<List<Category?>>.Success(categorie.Data);
    }
}
