namespace API;

using API.Extensions;
using Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;

/// <summary>
/// Pepresents the main class of application.
/// </summary>
public class Program
{
    /// <summary>
    /// Represents the entry point to the application.
    /// </summary>
    /// <param name="args">Arguments.</param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.RegisterDbContext(builder.Configuration);
        builder.Services.RegisterDependencies();

        builder.Services.AddOpenApi();

        var app = builder.Build();

        app.UseMiddleware<ExceptionHandlerMiddleware>();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi("/swagger/v1/swagger.json");
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
