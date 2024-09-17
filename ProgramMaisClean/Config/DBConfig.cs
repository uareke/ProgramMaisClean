using Microsoft.EntityFrameworkCore;
using ProgramMaisClean.Context;

namespace ProgramMaisClean.Config
{
    public static class DBConfig
    {

        public static IServiceCollection AddDbConfiguration(this IServiceCollection services, IConfiguration _config)
        {
            //conexão mysql
            var connectionString = _config.GetConnectionString("mysql");
            services.AddDbContext<AddDbContext>(options =>
                options.UseMySql(connectionString,
                    new MySqlServerVersion(new Version(8, 0, 26))));

            return services;
        }
    }
}
