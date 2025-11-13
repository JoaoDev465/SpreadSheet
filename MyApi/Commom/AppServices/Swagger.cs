namespace WebApplication2.Commom.AppServices;

public  static class Swagger
{
    public static void Swaggerapp(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}