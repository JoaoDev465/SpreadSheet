using Core.Contract;
using Core.Entities;
using Core.Response;
using Core.UseCase.USerHandler;
using Microsoft.AspNetCore.Mvc;
using Spreadsheet.Commom;

namespace Spreadsheet.EndPoints.UserEndPoints;

public class PutUSerEndpoint : IEndpoints
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("/{id}",HandlerAsync)
            .WithDescription("Here you can update your Profile")
            .WithName("Put : User")
            .Produces<Responses<User?>>();
    }

    public static async Task<IResult> HandlerAsync([FromRoute] int id,
        [FromServices] PutUserHAndler hAndler,
        ProfileContract contract)
    {
        var userId = contract.Id;

        if (userId == null)
        {
            return TypedResults.NotFound("Not Found");
        }

        var responses = await hAndler.PutUserHandlerAsync(contract);
        return Responses<User?>.Success(responses.Data).Code.IsSucces
            ? TypedResults.Ok(responses.Data)
            : TypedResults.BadRequest("Bad Request");
    }
}