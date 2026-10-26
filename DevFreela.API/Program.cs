using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi(options =>
{
    // O .NET 11 gera o documento em OpenAPI 3.2 por padrão, que o Swagger UI ainda não reconhece
    options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_0;
});

// criando DI
var connectionString = builder.Configuration.GetConnectionString("DevFreelaCs");
builder.Services.AddDbContext<DevFreelaDbContext>(options => 
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IProjectService, ProjectService>(); // scoped: a cada requisicao ao longo da aplicao ele volta com os valores padrao pra cada requicao;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "DevFreela API v1");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();