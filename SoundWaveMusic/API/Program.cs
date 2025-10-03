using Microsoft.EntityFrameworkCore;
using SoundWaveMusic.DataAccess;
using SoundWaveMusic.DataAccess.Data;
using SoundWaveMusic.API.Extensions;
using SoundWaveMusic.DataAccess.Repositories;
using SoundWaveMusic.BusinessLayer.Interfaces;
using SoundWaveMusic.BusinessLayer.Services;
using SoundWaveMusic.DataAccess.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// DbContext Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.RegisterDbContext(connectionString);
builder.Services.RegisterRepositories();
builder.Services.RegisterServices();

// Register UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Controllers

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
