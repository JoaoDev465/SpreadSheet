using Core.Contract;
using Core.Entities;
using Core.Response;
using Core.UseCase.CategoriesHandler;
using Spreadsheet.Commom;

namespace Spreadsheet.EndPoints.CategoryEndpoints;

public class CategoryAddEndpoint : IEndpoints
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/", Handlerasync)
            .WithDescription("Post Categorys")
            .WithName("Post : Categorys")
            .Produces<Responses<Category?>>();
    }

    public static async Task<IResult> Handlerasync(CategoryContract contract, CategoryAddHandler handler)
    {
        var response = await handler.AddCategoryAsync(contract);

        return Responses<Category?>.Success(response.Data).Code.IsSucces
            ? TypedResults.Ok("Success")
            : TypedResults.BadRequest("Bad Requests");
    }
}