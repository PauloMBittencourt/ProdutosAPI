using Produtos.API.Extensions;
using Microsoft.EntityFrameworkCore;
using Produtos.Data.Context;
using Produtos.Service.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDependenceInjection();
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(ProdutoMapper));

//Conex?o com o banco
builder.Services.AddDbContext<ApiDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Conexao")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
