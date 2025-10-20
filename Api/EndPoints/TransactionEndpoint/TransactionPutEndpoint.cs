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
        app.MapPut("/",HandlerAsync)
            .WithSummary("update transactions")
            .WithName("Transactions : put")
            .Produces<Responses<Transactions?>>();
    }

    public static async Task<IResult> HandlerAsync([FromBody] TransactionContract contract,
        TransactionPutHandler handler)
    {
        var response = await  handler.PutTransactionsync(contract);
        
        return Responses<Transactions?> .Success(response.Data).Code.IsSucces
            ? TypedResults.Ok("Transactions updated")
            : TypedResults.BadRequest("Transactions update failed");
    }
}