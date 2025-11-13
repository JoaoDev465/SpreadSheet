using Spreadsheet.EndPoints;
using WebApplication2.Commom.AppServices;
using WebApplication2.Commom.Services;
using WebApplication2.Services;

var builder = WebApplication.CreateBuilder(args);

builder.SwaggerDoc();
builder.ProgramServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.Swaggerapp();
}
app.MapEndpoint();

app.Run();