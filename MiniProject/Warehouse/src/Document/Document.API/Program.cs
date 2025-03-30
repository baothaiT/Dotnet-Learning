using Document.API.Extensions;
using Document.Application.MappingProfile;
using Document.Application.UserCases.V1.Queries.Document.GetAllDocument;
using Document.Persistence.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.AddAppConfigurations();
Log.Information($"Start {builder.Environment.ApplicationName} up");
// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();



//// Register Command Handlers
builder.Services.AddService();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMediatR(typeof(GetAllDocumentQuery).Assembly);
// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MappingDocumentProfile));
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
