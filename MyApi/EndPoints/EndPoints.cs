using Spreadsheet.Commom;
using Spreadsheet.EndPoints.CategoryEndpoints;
using Spreadsheet.EndPoints.TransactionEndpoint;
using Spreadsheet.EndPoints.UserEndPoints;
using WebApplication2.EndPoints.CategoryEndpoints;

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

        app.MapGroup("Get/All/Transactions")
            .WithTags("Transaction")
            .MapEndpoint<GetAllTransactionsEndpoint>();
        
        app.MapGroup("Create/Categories")
            .WithTags("Categories")
            .MapEndpoint<CategoryAddEndpoint>();

        app.MapGroup("Update/Categories")
            .WithTags("Categories")
            .MapEndpoint<CategoryPutEndpoint>();

        app.MapGroup("Get/All/Categories")
            .WithTags("Categories")
            .MapEndpoint<GetAllCategoriesEndPoitns>();
        
        app.MapGroup("Get/Categories")
            .WithTags("Categories")
            .MapEndpoint<CategoryGetEndpoint>();

        app.MapGroup("Post/Services")
            .WithTags("Services")
            .MapEndpoint<ServicesEndpoints>();

        app.MapGroup("Create/Profile")
            .AllowAnonymous()
            .WithTags("Profile")
            .MapEndpoint<AddUserEndpoint>();

        app.MapGroup("Put/Profile")
            .WithTags("Profile")
            .MapEndpoint<PutUSerEndpoint>();

    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoints
    {
        TEndpoint.Map(app);
        return app;
    }
}