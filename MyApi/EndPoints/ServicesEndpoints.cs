using Core.Contract;
using Core.Entities;
using Core.Interface;
using Core.Response;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Spreadsheet.Commom;
using Spreadsheet.Services;

namespace Spreadsheet.EndPoints;

public class ServicesEndpoints : IEndpoints
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/",HandlerAsync)
            .WithDescription("here you can send one Email for somebody with your transaction pdf")
            .WithName("Email : generate Pdf")
            .Produces<Responses<Smtp?>>();
    }

    public static async Task<IResult> HandlerAsync([FromServices] Smtp generateSmtp,
       [FromServices]  IPdfServices pdfGenerator,
        [FromServices] ITransactionsRepo repo,
        [FromBody] ProfileContract contract)
    {
        var pdf = await pdfGenerator.Pdf();
        generateSmtp.SendEmail("Envio de Email",
            pdf,
            "joaodesouza1234t@gmail.com",
            contract.Email);

        return Results.Ok("Pdf Enviado com Sucesso");
    }
    
}