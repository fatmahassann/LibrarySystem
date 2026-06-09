using FluentValidation;
using LibrarySystem.Application.Behaviors;
using LibrarySystem.Application.Common.Interfaces;
using LibrarySystem.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(builder => builder.UseSqlServer("@\"Server=.\\SQLEXPRESS;Database=Products;Trusted_Connection=True;TrustServerCertificate=True\""));

//mediatR Regester
builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssembly(typeof(LibrarySystem.Application.IAssemblyMarker).Assembly);
});

// Validator regester
builder.Services.AddValidatorsFromAssembly(typeof(LibrarySystem.Application.IAssemblyMarker).Assembly);

//مع كل requet بينطلب اعمل object جديد 
builder.Services.AddTransient(typeof(IPipelineBehavior<,>) , typeof(ValidationBehavior<,>));

builder.Services.AddScoped<IApplicationDbContecxt, ApplicationDbContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
