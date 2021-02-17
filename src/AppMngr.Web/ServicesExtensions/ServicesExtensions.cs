using System;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace AppMngr.Web
{
    public static class ServicesExtensions
    {
        public static void AddWebLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddScoped<IFileSavingService, FileSavingService>();

            services.AddScoped<IFileGettingService, FileGettingService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = configuration["JWT:Issuer"],
                            ValidateAudience = true,
                            ValidAudience = configuration["JWT:Audience"],
                            ValidateLifetime = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"])),
                            ValidateIssuerSigningKey = true,
                        };
                    });

            services.AddSwaggerGen(c =>
            {
                // Отображение правил валидации FluentValidation в Swagger UI
                c.AddFluentValidationRules();

                // Отображение XML-комментариев в Swagger UI
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                // Авторизация в Swagger UI
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Введите: Bearer [пробел] JWT-токен без кавычек\r\n\r\nПример: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9"  
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
        }
    }
}