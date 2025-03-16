using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowGateway",
        policy =>
        {
            policy.WithOrigins("http://localhost:5000") // Only allow API Gateway
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials(); // ✅ Can be used with WithOrigins()
        });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// ✅ Add Swagger to API Gateway
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowGateway"); // Apply CORS policy
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
