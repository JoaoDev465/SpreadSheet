using Core.Contract;
using Core.Entities;
using Core.Response;
using Core.UseCase.CategoriesHandler;
using Microsoft.AspNetCore.Mvc;
using Spreadsheet.Commom;

namespace Spreadsheet.EndPoints.CategoryEndpoints;

public class CategoryAddEndpoint : IEndpoints
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/", Handlerasync)
            .WithDescription("you can create your Personalized Category")
            .WithName("Post : Categorys")
            .Produces<Responses<Category?>>();
    }

    public static async Task<IResult> Handlerasync([FromBody] CategoryContract contract,[FromServices] CategoryAddHandler handler)
    {
        var response = await handler.AddCategoryAsync(contract);
        
        return Responses<Category?>.Success(response.Data).Code.IsSucces
            ? TypedResults.Created($"Created/{response.Data.Id}",response)
            : TypedResults.BadRequest("Bad Requests");
    }
}