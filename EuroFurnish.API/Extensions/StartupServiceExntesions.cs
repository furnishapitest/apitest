using AutoMapper;
using EuroFurnish.API.Middlewares;
using EuroFurnish.ApplicationCore.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroFurnish.API.Extensions
{
    public static class StartupServiceExntesions
    {
        public static void AddSwaggerDI(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Euro Furnish API",
                    Description = "Euro Furnish Test Web API",
                    TermsOfService = new Uri("https://www.eurofurnish.com"),

                });
                var security = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer",
                            },
                            Scheme="oauth2",
                            Name="Bearer",
                            In=ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                };
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the bearer schena",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });
                c.AddSecurityRequirement(security);
            });
        
        }
        public static void UseAppSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Euro Furnish API V1");
            });

        }
        public static void AddAutoMapperDI(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AppDtoMapper));
        }

        public static void UseMiddlewareUI(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
      

    }
}
