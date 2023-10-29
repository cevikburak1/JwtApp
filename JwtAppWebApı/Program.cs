using JwtAppWebAp�.Core.Application.Interfaces;
using JwtAppWebAp�.Persistance.Context;
using JwtAppWebAp�.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<JwtAndCQRSAppContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("local"));
});

builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
