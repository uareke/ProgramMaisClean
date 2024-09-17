using Asp.Versioning;

namespace ProgramMaisClean.Config
{
    public static class VersioningConfig
    {
        public static IServiceCollection ApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1); //Define a versão padrão da API. Normalmente, será v1.0
                options.ReportApiVersions = true; //Relata as versões de API suportadas no api-supported-versionscabeçalho de resposta.
                options.AssumeDefaultVersionWhenUnspecified = true; // Usa DefaultApiVersionquando o cliente não forneceu uma versão explícita.
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("X-Api-Version")); //Configura como ler a versão da API especificada pelo cliente. O valor padrão é QueryStringApiVersionReader.
            }).AddMvc() // This is needed for controllers
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}
