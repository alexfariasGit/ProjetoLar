using Data.Context;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MediatR;
using Data.Repositories;
using Business.Handlers;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();

// Adicionar MediatR ao contêiner de dependências e registrar os handlers
builder.Services.AddMediatR(Assembly.GetExecutingAssembly()); // Registra todos os handlers do assembly atual

// Ou se você quiser registrar especificamente um assembly onde estão os seus handlers:
builder.Services.AddMediatR(Assembly.GetAssembly(typeof(CreateCommandHandler)));
builder.Services.AddMediatR(Assembly.GetAssembly(typeof(GetAllPessoasQueryHandler)));
builder.Services.AddMediatR(Assembly.GetAssembly(typeof(GetPessoaByIDQueryHandler)));
builder.Services.AddMediatR(Assembly.GetAssembly(typeof(UpdateCommandHandler)));



builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();