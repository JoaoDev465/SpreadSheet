using Core.Contract;
using Core.Entities;
using Core.Response;
using Core.UseCase.CategoriesHandler;
using Core.ValueObjects.ResponseVO;
using Microsoft.AspNetCore.Mvc;
using Spreadsheet.Commom;

namespace Spreadsheet.EndPoints.CategoryEndpoints;

public class GetAllCategoriesEndPoitns : IEndpoints
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.Map("/",HandlerAsync)
            .WithDescription("here you get All Categories, with pagination")
            .WithName("Categories : Get All Categories")
            .Produces<PagedResponse<List<Category?>>>();
    }

    public static async Task<IResult> HandlerAsync([FromServices]CategoryGetHandler handler)
    {
        var contract = new CategoryContract();
        var response = await handler.GeCategories(contract);
        
        if (response.Code.IsSucces)
        {
            return TypedResults.Ok(response.Data);
        }

        if (response.Code == Code.NotFound())
        {
            return TypedResults.NotFound();
        }

        return TypedResults.BadRequest();
    }
}