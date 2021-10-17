using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conta.Extensions.DI
{
    public static class RegistrationDependencyInjection
    {
        /// <summary>
        /// Método para realizar o registro das dependências
        /// </summary>
        /// <param name="service"></param>
        /// <param name="configuration"></param>
        public static void RegistrarDependencias(this IServiceCollection service, IConfiguration configuration = null)
        {
            ResgistrarRepositories(service);
            ResgistrarServices(service);
        }

        public static void ResgistrarRepositories(IServiceCollection services)
        {
        }

        public static void ResgistrarServices(IServiceCollection services)
        {
        }
    }
}
