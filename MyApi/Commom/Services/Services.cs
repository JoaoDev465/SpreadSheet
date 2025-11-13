using Core.Interface;
using Core.UseCase.CategoriesHandler;
using Core.UseCase.TransactionsHandler;
using Core.UseCase.USerHandler;
using Data.DB;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;
using Spreadsheet.Services;
using PdfGenerator = Spreadsheet.Services.PdfGenerator;

namespace WebApplication2.Commom.Services;

public static class Services
{
    public static void ProgramServices(this WebApplicationBuilder builder)
    {
        QuestPDF.Settings.License = LicenseType.Community;
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddTransient<TransactionAddHandler>();
        builder.Services.AddTransient<TransactionPutHandler>();
        builder.Services.AddTransient<TransactionGetHandler>();
        builder.Services.AddTransient<CategoryAddHandler>();
        builder.Services.AddTransient<CategoryGetHandler>();
        builder.Services.AddTransient<CategoryPutHandler>();
        builder.Services.AddTransient<AddUserHandler>();
        builder.Services.AddTransient<PutUserHAndler>();
        
        
        
        builder.Services.AddDbContext<Context>(options =>
        {
          var connection =  builder.Configuration.GetConnectionString("Data");
            options.UseSqlite(connection);
        });

        builder.Services.AddScoped<ITransactionsRepo, TransactionRepo>();
        builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
        builder.Services.AddScoped<IPdfServices ,PdfGenerator>();
        builder.Services.AddScoped<IUserRepo, UserRepo>();
        builder.Services.AddScoped<Smtp>();

    }
}