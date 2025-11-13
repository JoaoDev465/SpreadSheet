using Core.Contract;
using Core.Entities;
using Core.Response;
using Core.UseCase.TransactionsHandler;
using Microsoft.AspNetCore.Mvc;
using Spreadsheet.Commom;

namespace Spreadsheet.EndPoints.TransactionEndpoint;

public class TransactionPutEndpoint: IEndpoints
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("/{id}",HandlerAsync)
            .WithDescription("here you can update your transaction by id")
            .WithName("Transactions : put")
            .Produces<Responses<Transactions?>>();
    }

    public static async Task<IResult> HandlerAsync([FromRoute] int id,[FromBody] TransactionContract contract,
        TransactionPutHandler handler)
    {
        var response = await  handler.PutTransactionsync(contract);
        
        return Responses<Transactions?> .Success(response.Data).Code.IsSucces
            ? TypedResults.Ok("Success")
            : TypedResults.BadRequest("Bad Request");
    }
}