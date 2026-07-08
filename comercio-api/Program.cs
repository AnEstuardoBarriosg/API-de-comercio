using Microsoft.OpenApi;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// AGREGAMOS LA DOCUMENTACION
// Esto nos permite generar la documentación de la API, que se puede consultar en el navegador, y también nos permite probar los endpoints directamente desde la documentación.
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Comercio API - Mi primera API con ASP.NET Core APIREST",
        Description = "API para gestionar productos, clientes y pedidos de un comercio.",
        Contact = new OpenApiContact
        {
            Name = "Soy Angel",
            Email = "angelb@example.com"
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        // Configuramos la ruta para acceder a la documentación de Swagger UI
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Comercio API V1");
        options.RoutePrefix = "swagger";
    });
}
//middleware para redirecionar para https:
//localhost:500x
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
