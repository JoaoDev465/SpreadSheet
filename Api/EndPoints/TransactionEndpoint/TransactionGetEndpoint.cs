using Core.Contract;
using Core.Entities;
using Core.Response;
using Core.UseCase.TransactionsHandler;
using Microsoft.AspNetCore.Mvc;
using Spreadsheet.Commom;

namespace Spreadsheet.EndPoints.TransactionEndpoint;

public class TransactionGetEndpoint : IEndpoints
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("",HandlerAsync)
            .WithSummary("Get transactions")
            .WithName("Transactions : Get")
            .Produces<Responses<Transactions?>>();
    }

    public static async Task<IResult> HandlerAsync([FromRoute] TransactionContract contract,
        TransactionGetHandler handler)
    {
        var respose = await  handler.GetTransactionsByIdAsync(contract);
        
        return Responses<Transactions?>.Success(respose.Data).Code.IsSucces
            ? TypedResults.Ok(respose.Data)
            : TypedResults.NotFound("Failed to get transaction");
    }
}