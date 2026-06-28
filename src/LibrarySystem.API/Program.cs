using FluentValidation;
using LibrarySystem.API.Exceptions;
using LibrarySystem.Application.Behaviors;
using LibrarySystem.Application.Common.Interfaces;
using LibrarySystem.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Server=.\\SQLEXPRESS;Database=LibrarySystem;Trusted_Connection=True;TrustServerCertificate=True"));
//mediatR Regester
builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssembly(typeof(LibrarySystem.Application.IAssemblyMarker).Assembly);
});

// Validator regester
builder.Services.AddValidatorsFromAssembly(typeof(LibrarySystem.Application.IAssemblyMarker).Assembly);

//مع كل requet بينطلب اعمل object جديد 
builder.Services.AddTransient(typeof(IPipelineBehavior<,>) , typeof(ValidationBehavior<,>));

builder.Services.AddScoped<IApplicationDbContext>(provider =>
    provider.GetRequiredService<ApplicationDbContext>());
//builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseExceptionHandler();

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
