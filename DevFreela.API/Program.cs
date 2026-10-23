using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// criando DI
builder.Services.AddSingleton<DevFreelaDbContext>(); // singleton: ele mantem o valor dele ao longo da aplicacao com varias reqs chamando;

builder.Services.AddScoped<IProjectService, ProjectService>(); // scoped: a cada requisicao ao longo da aplicao ele volta com os valores padrao pra cada requicao;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();