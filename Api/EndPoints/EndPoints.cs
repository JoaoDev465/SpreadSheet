using Spreadsheet.Commom;
using Spreadsheet.EndPoints.CategoryEndpoints;
using Spreadsheet.EndPoints.TransactionEndpoint;

namespace Spreadsheet.EndPoints;

public static class MapEndpoints
{
    public static void MapEndpoint(this WebApplication app)
    {
        app.MapGet("/", () => new { message = "Ok" })
            .WithTags("Health Check");

        app.MapGroup("Create/Transactions")
            .WithTags("Transactions")
            .MapEndpoint<TransactionAddEndpoint>();

        app.MapGroup("Update/Transactions")
            .WithTags("Transactions")
            .MapEndpoint<TransactionPutEndpoint>();

        app.MapGroup("Get/Transactions")
            .WithTags("Transactions")
            .MapEndpoint<TransactionGetEndpoint>();
        
        app.MapGroup("Create/Categories")
            .WithTags("Categories")
            .MapEndpoint<CategoryAddEndpoint>();

        app.MapGroup("Update/Categories")
            .WithTags("Categories")
            .MapEndpoint<CategoryPutEndpoint>();

        app.MapGroup("Get/Categories")
            .WithTags("Categories")
            .MapEndpoint<CategoryGetEndpoint>();
        
        
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoints
    {
        TEndpoint.Map(app);
        return app;
    }
}