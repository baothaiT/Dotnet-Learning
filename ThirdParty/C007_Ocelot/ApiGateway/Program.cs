using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Add Ocelot configuration
// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMicroservices", policy =>
    {
        policy.WithOrigins("http://localhost:5001", "http://localhost:5002") // Allow product & order services
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
 //✅ Add Swagger to API Gateway
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Gateway", Version = "v1" });
    c.SwaggerDoc("productService", new OpenApiInfo { Title = "Product Service", Version = "v1" });
    c.SwaggerDoc("orderService", new OpenApiInfo { Title = "Order Service", Version = "v1" });
});
builder.Services.AddOcelot();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    //app.UseSwaggerUI();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Gateway");
    c.SwaggerEndpoint("http://localhost:5001/swagger/v1/swagger.json", "Product Service");
    c.SwaggerEndpoint("http://localhost:5002/swagger/v1/swagger.json", "Order Service");
});
//}

app.UseCors("AllowMicroservices");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.UseOcelot(); // Ensure this is the last middleware

await app.RunAsync(); // Change Run() to RunAsync()
