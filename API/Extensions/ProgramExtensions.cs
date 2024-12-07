namespace API.Extensions;

using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using API.Validators;
using Application.DTOs.Requests;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using FluentValidation;
using Persistence.Interfaces;
using Persistence.Repositories;
using Application.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

/// <summary>
/// Provides extension methods for registering dependencies into the <see cref="IServiceCollection"/>.
/// This method simplifies the process of loading application-specific dependencies.
/// </summary>
public static class ProgramExtensions
{
    /// <summary>
    /// Registers application dependencies.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to register dependencies with.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> to get access to config.</param>
    public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterDbContext(services, configuration);
        RegisterServices(services);
        RegisterRepositories(services);
        RegisterValidators(services);
        RegisterOptions(services, configuration);
        RegisterAuthentication(services, configuration);
        RegisterSwaggerConfiguration(services);
    }

    private static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("Default"), b =>
            {
                b.MigrationsAssembly(typeof(AppDbContext).Assembly);
            });
        });
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IPostsService, PostsService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddSingleton<IPasswordHandlerService, PasswordHandlerService>();
        services.AddSingleton<IJwtService, JwtService>();
        services.AddScoped<IAuthService, AuthService>();
    }

    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddScoped<IPostsRepository, PostsRepository>();
        services.AddScoped<IVehiclesRepository, VehiclesRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();
    }

    private static void RegisterValidators(IServiceCollection services)
    {
        services.AddScoped<IValidator<LoginDto>, LoginDtoValidator>();
        services.AddScoped<IValidator<RegisterDto>, RegisterDtoValidator>();
    }

    private static void RegisterOptions(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
    }

    private static void RegisterAuthentication(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = true;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"] !)),
            };
        });
    }

    private static void RegisterSwaggerConfiguration(IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer",
                        },
                    },
                    Array.Empty<string>()
                },
            });
        });
    }
}
