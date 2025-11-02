using Core.Contract;
using Core.Entities;
using Core.Response;
using Core.UseCase.CategoriesHandler;
using Spreadsheet.Commom;

namespace Spreadsheet.EndPoints.CategoryEndpoints;

public class CategoryPutEndpoint : IEndpoints
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("/",Handlerasync)
            .WithDescription("put categories")
            .WithName("Put : Category")
            .Produces<Responses<Category?>>();

    }
    public static async Task<IResult> Handlerasync(CategoryContract contract, CategoryPutHandler handler)
    {
        var response = await handler.PutCategoryAsync(contract);

        return Responses<Category?>.Success(response.Data).Code.IsSucces
            ? TypedResults.Ok("Success")
            : TypedResults.BadRequest("Bad Request");
    }
}