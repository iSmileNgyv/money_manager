using System.Text.Json;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;
using MoneyManager.Application;
using MoneyManager.Application.Exceptions;
using MoneyManager.Application.Validators;
using MoneyManager.Application.Validators.Category;
using MoneyManager.Infrastructure;
using MoneyManager.Infrastructure.Services.Storage.Local;
using MoneyManager.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
            policy.WithOrigins("http://localhost:4200", "https://localhost:4200/")
                .AllowAnyMethod()
                .AllowAnyHeader()
    ));
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
/*using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MainContext>();
    dbContext.Database.Migrate();
}*/
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseRouting();
app.UseHttpsRedirection();
//app.UseAuthentication();
//app.UseAuthorization();
app.UseStaticFiles();
app.UseEndpoints(endpoints => { endpoints.MapControllers();});
app.Run();