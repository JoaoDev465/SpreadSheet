using Core.Contract;
using Core.Entities;
using Core.Response;
using Core.UseCase.USerHandler;
using Microsoft.AspNetCore.Mvc;
using Spreadsheet.Commom;

namespace Spreadsheet.EndPoints.UserEndPoints;

public class AddUserEndpoint : IEndpoints
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/",HandlerAsync)
            .WithDescription("Here you can create you Profile")
            .WithName("Post : User")
            .Produces<Responses<User?>>();
    }

    public static async Task<IResult> HandlerAsync([FromBody] ProfileContract contract,
        [FromServices] AddUserHandler handler)
    {
        var responses = await handler.AddUsersHandlerAsync(contract);

        return Responses<User?>.Created(responses.Data).Code.IsSucces
            ? TypedResults.Created($"/Created/{responses.Data}",responses)
            : TypedResults.BadRequest("Bad Request");
    }
}