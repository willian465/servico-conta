using Conta.Mappers;
using Conta.Repositories;
using Conta.Repositories.Interfaces;
using Conta.Services;
using Conta.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Conta.Extensions.DI
{
    public static class RegistrationDependencyInjection
    {
        /// <summary>
        /// Método para realizar o registro das dependências
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void RegistrarDependencias(this IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddSingleton<IConverter, Coverter>();
            ResgistrarRepositories(services);
            ResgistrarServices(services);
        }

        public static void ResgistrarRepositories(IServiceCollection services)
        {
            services.AddSingleton<IMemoryRepository, MemoryRepository>();
        }

        public static void ResgistrarServices(IServiceCollection services)
        {
            services.AddScoped<IContaService, ContaService>();
        }
    }
}
