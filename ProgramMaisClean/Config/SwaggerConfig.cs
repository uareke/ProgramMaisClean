using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ProgramMaisClean.Config
{
    public static class SwaggerConfig
    {
        private static readonly string[] _value = [];
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "spt-mobile-admin.api",
                    Version = "v1",
                    Description = "Esta é a API para administração do spt mobile.",
                });

                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "spt-mobile-admin.api",
                    Version = "v1",
                    Description = "Esta é a API para administração do spt mobile.",

                });


                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Insira o token JWT desta maneira: Bearer {seu token}",
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
                            },
                    _value },
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
            return services;
        }
    }
}
