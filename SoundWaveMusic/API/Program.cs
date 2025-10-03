using Microsoft.EntityFrameworkCore;
using SoundWaveMusic.DataAccess;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using SoundWaveMusic.Interfaces;
using API.Extensions;
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

builder.Services.AddControllers()
     .AddJsonOptions(options =>
      {
          options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
      });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
