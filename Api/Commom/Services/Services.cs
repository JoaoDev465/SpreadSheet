using Core.Entities;
using Core.Interface;
using Core.UseCase.TransactionsHandler;
using Data.DB;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Spreadsheet.EndPoints.TransactionEndpoint;

namespace Spreadsheet.Commom.Services;

public static class Services
{
    public static void ProgramServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<TransactionAddHandler>();
        builder.Services.AddTransient<TransactionPutHandler>();
        builder.Services.AddTransient<TransactionGetHandler>();
        
        
        builder.Services.AddDbContext<Context>(options =>
        {
            options.UseSqlite("Data Source=spreadsheet.db");
        });

        builder.Services.AddScoped<ITransactionsRepo, TransactionRepo>();
    }
}