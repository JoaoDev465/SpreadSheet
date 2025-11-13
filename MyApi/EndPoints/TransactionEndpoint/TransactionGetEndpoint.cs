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
        app.MapGet("/{id}",HandlerAsync)
            .WithDescription("here you can get your transaction by id")
            .WithName("Transactions : Get By Id")
            .Produces<Responses<Transactions?>>();
    }

    public static async Task<IResult> HandlerAsync([FromRoute] int id,
       [FromServices] TransactionGetHandler handler)
    {
        var contract = new TransactionContract();
        var respose = await  handler.GetTransactionsByIdAsync(contract);
        
        return Responses<Transactions?>.Success(respose.Data).Code.IsSucces
            ? TypedResults.Ok(respose.Data)
            : TypedResults.NotFound("Bad Request");
    }
}