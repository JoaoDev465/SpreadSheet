using System.Transactions;
using Core.Contract;
using Core.Entities;
using Core.Response;
using Core.UseCase.TransactionsHandler;
using Core.ValueObjects.ResponseVO;
using Microsoft.AspNetCore.Mvc;
using Spreadsheet.Commom;
using Microsoft.AspNetCore.Mvc;
using Spreadsheet.Services;

namespace Spreadsheet.EndPoints.TransactionEndpoint;

public class GetAllTransactionsEndpoint : IEndpoints
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("",HandlerAsync)
            .WithDescription("here you can get all Categories, with pagination")
            .WithName("Transactions : Get All")
            .Produces<PagedResponse<List<Transactions?>>>();
    }

    public static async Task<IResult> HandlerAsync([FromServices]TransactionGetHandler handler)
    {
        var contract = new ProfileContract();
        var response =  await handler.GetAllTransactions(contract);

        if (response.Code.IsSucces)
        {
            return TypedResults.Ok(response.Data);
        }

        if (response.Code == Code.NotFound())
        {
            return TypedResults.NotFound();
        }

        return TypedResults.BadRequest();
    }
}