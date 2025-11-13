using Core.Contract;
using Core.Entities;
using Core.Response;
using Core.UseCase.CategoriesHandler;
using Microsoft.AspNetCore.Mvc;
using Spreadsheet.Commom;

namespace Spreadsheet.EndPoints.CategoryEndpoints;

public class CategoryPutEndpoint : IEndpoints
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("/{id}",Handlerasync)
            .WithDescription("here you can update your category by id")
            .WithName("Put : Category")
            .Produces<Responses<Category?>>();

    }
    public static async Task<IResult> Handlerasync([FromRoute] int id,[FromBody] CategoryContract contract,[FromServices] CategoryPutHandler handler)
    {
        var response = await handler.PutCategoryAsync(contract);

        return Responses<Category?>.Success(response.Data).Code.IsSucces
            ? TypedResults.Ok("Success")
            : TypedResults.BadRequest("Bad Request");
    }
}