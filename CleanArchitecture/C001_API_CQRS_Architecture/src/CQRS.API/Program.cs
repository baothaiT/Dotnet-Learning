using CQRS.Domain.Abstractions.Repository;
using CQRS.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CQRS.API;
using MediatR;
using CQRS.Application.UserCases.V1.Commands.Product;
using CQRS.Application.UserCases.V1.Queries.Product;
using CQRS.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register the AppDbContext with SQL Server or SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SeverConnectionTest")));

// Register Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();

//// Register Command Handlers
builder.Services.AddScoped<CreateProductCommandHandler>();
builder.Services.AddScoped<UpdateProductCommandHandler>();
builder.Services.AddScoped<DeleteProductCommandHandler>();

// Register Query Handlers
builder.Services.AddScoped<GetAllProductsQueryHandler>();
builder.Services.AddScoped<GetProductByIdQueryHandler>();


builder.Services.AddMediatR(typeof(CQRS.Application.UserCases.V1.Commands.ProductMediatR.CreateProductCommand).Assembly);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
