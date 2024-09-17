using ProgramMaisClean.Services;
using ProgramMaisClean.Services.Interfaces;

namespace ProgramMaisClean.Config
{
    public static class InjectConfig
    {
        public static IServiceCollection ResolveDependencias(this IServiceCollection services)
        {

            services.AddScoped<IHelperService, HelperService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<ITelefoneService, TelefoneService>();

            return services;
        }

    }
}
