using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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

        opt.AllowPasswordFlow(); // ✅ Required

        opt.AcceptAnonymousClients(); // ✅ If you don't use client_id/secret

        opt.AddDevelopmentEncryptionCertificate()
               .AddDevelopmentSigningCertificate();

        opt.UseAspNetCore()
               .EnableTokenEndpointPassthrough();

        opt.UseAspNetCore()
            .EnableTokenEndpointPassthrough();
    });

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:5001";
        options.Audience = "resource_server";
        options.TokenValidationParameters.ValidateAudience = false;
        options.RequireHttpsMetadata = false;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
var app = builder.Build();
// 👉 Seed user on startup
using (var scope = app.Services.CreateScope())
{
    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var user = await userMgr.FindByNameAsync("test");
    if (user == null)
    {
        await userMgr.CreateAsync(new IdentityUser("test"), "Pass123$");
    }
}

app.Use(async (context, next) =>
{
    Console.WriteLine($"➡ Content-Type: {context.Request.ContentType}");
    await next();
});


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


await app.RunAsync();

