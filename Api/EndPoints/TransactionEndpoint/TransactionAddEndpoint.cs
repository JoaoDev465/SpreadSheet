using Core.Contract;
using Core.Entities;
using Core.Response;
using Core.UseCase.TransactionsHandler;
using Microsoft.AspNetCore.Mvc;
using Spreadsheet.Commom;

namespace Spreadsheet.EndPoints.TransactionEndpoint;

public class TransactionAddEndpoint : IEndpoints
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/",HandlerAsync)
            .WithSummary("Transaction added")
            .WithName("Transactions : Add")
            .WithSummary("Transaction added")
            .Produces<Responses<Transactions?>>();
    }

    public static async  Task<IResult> HandlerAsync([FromBody]TransactionContract contract,
        TransactionAddHandler handler)
    {
       var reponse = await  handler.AddAsync(contract);

       return Responses<Transactions?>.Success(reponse.Data).Code.IsSucces
           ? TypedResults.Created($"/created/{contract.Id}",reponse)
           : TypedResults.BadRequest("Bad Request");

    }
}