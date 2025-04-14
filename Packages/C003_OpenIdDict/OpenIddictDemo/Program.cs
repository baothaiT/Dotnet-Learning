using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpenIddictDemo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

    // Register OpenIddict with EF
    options.UseOpenIddict();
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddOpenIddict()
    .AddCore(opt => opt.UseEntityFrameworkCore()
        .UseDbContext<ApplicationDbContext>())
    .AddServer(opt =>
    {
        opt.SetTokenEndpointUris("/connect/token");

        opt.AllowPasswordFlow();
        opt.AcceptAnonymousClients();
        opt.UseAspNetCore()
            .EnableTokenEndpointPassthrough();
        opt.AddDevelopmentEncryptionCertificate()
            .AddDevelopmentSigningCertificate();
// Register the ASP.NET Core host and configure the ASP.NET Core options.
        opt.UseAspNetCore()
               .EnableTokenEndpointPassthrough();
        // opt.UseJsonWebTokens();
    });

// builder.Services.AddAuthentication("Bearer")
//     .AddJwtBearer("Bearer", options =>
//     {
//         options.Authority = "https://localhost:5001";
//         options.Audience = "resource_server";
//         options.TokenValidationParameters.ValidateAudience = false;
//         options.RequireHttpsMetadata = false;
//     });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseDeveloperExceptionPage();

app.UseForwardedHeaders();

app.UseRouting();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseEndpoints(options =>
{
    options.MapControllers();
    options.MapDefaultControllerRoute();
});


app.Run();

