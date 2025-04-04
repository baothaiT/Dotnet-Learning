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
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()  // Allow all origins (including Swagger UI)
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
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
app.UseCors(MyAllowSpecificOrigins);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", context =>
    {
        // await context.Response.WriteAsync($"Hello TEDU members! This is {builder.Environment.ApplicationName}");
        context.Response.Redirect("swagger/index.html");
        return Task.CompletedTask;
    });
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
