namespace WebApplication2.Services;

public static class Documentation
{
    public static void SwaggerDoc(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
        builder.Services.AddEndpointsApiExplorer();
    }
}