using Core.Contract;
using Core.Entities;
using Core.Response;
using Core.UseCase.CategoriesHandler;
using Microsoft.AspNetCore.Mvc;
using Spreadsheet.Commom;

namespace WebApplication2.EndPoints.CategoryEndpoints;

public class CategoryGetEndpoint : IEndpoints
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/{id}",HandlerAsync)
            .WithDescription("here you will get you category by id")
            .WithName("Category : Get by Id")
            .Produces<Responses<Category?>>();
    }

    public static async Task<IResult> HandlerAsync([FromRoute] int id,[FromServices] CategoryGetHandler handler)
    {
        var contrac = new CategoryContract();
        var response =  await handler.GetCategoriesById(contrac);

        return Responses<Category?>.Success(response.Data).Code.IsSucces
            ? TypedResults.Ok(response.Data)
            : TypedResults.BadRequest("Bad Request");
    }
}