using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PessoasWeb.Core.Interfaces;
using PessoasWeb.Infra.Data;
using PessoasWeb.Infra.Data.Context;

namespace PessoasWeb.Infra.IoC
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencyInjection (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<DapperDbContext>();

            services.AddScoped<IPessoaRepository, PessoaRepository>();

            return services;
        }
    }
}
