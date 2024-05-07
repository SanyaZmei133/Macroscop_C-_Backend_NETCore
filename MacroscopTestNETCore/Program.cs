using MacroscopTestNETCore;
using MacroscopTestNETCore.Interfaces;
using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IPolindromeCheck, PolindromeCheck>();
builder.Services.AddScoped<IStringSeparator, StringSeparator>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
