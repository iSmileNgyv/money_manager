using System.Text;
using System.Text.Json;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using MoneyManager.Application;
using MoneyManager.Application.Exceptions;
using MoneyManager.Application.Validators;
using MoneyManager.Application.Validators.Category;
using MoneyManager.Infrastructure;
using MoneyManager.Infrastructure.Services.Storage.Local;
using MoneyManager.Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.WithThreadId()
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Host.UseSerilog();

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(8080);
    serverOptions.ListenAnyIP(8081);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddStorage<LocalStorage>();
builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>()).AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateCategoryCommandValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddCors(options => 
    options.AddDefaultPolicy(
        policy => 
            policy.WithOrigins("https://money.iso.com.az", "http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
    ));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin", options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true, // olusturulacak token degerinin hangi sitelerin kullanabilecegini belirtir
            ValidateIssuer = true, // kim bu tokeni olusturdu
            ValidateLifetime = true, // olusturulan tokenin ne kadar sure gecerli oldugunu belirtir
            ValidateIssuerSigningKey = true, // olusturulan tokene hangi security key ile sifrelenecegini belirtir
            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"] ?? "SecurityKey@12345")),
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null && expires > DateTime.UtcNow
        };
    });
var app = builder.Build();
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.ContentType = "application/json";

        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        if (exception is BaseException baseEx)
        {
            context.Response.StatusCode = baseEx.StatusCode;

            var errorResponse = new
            {
                ErrorMessage = baseEx.Message
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var errorResponse = new
            {
                ErrorMessage = "An unexpected error occurred."
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    });
});
// using (var scope = app.Services.CreateScope())
// {
//     var dbContext = scope.ServiceProvider.GetRequiredService<MainContext>();
//     try
//     {
//         dbContext.Database.Migrate();
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine($"Migration sırasında bir hata oluştu: {ex.Message}");
//     }
// }
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseEndpoints(endpoints => { endpoints.MapControllers();});
app.Run();