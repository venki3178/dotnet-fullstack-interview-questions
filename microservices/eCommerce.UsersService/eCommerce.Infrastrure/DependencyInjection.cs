using eCommerce.Core.UserRepositoryContracts;
using eCommerce.Infrastrure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastrure
{

    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add Infrastructure services to Dependency Injection Container.
        /// </summary>
        /// <param name="services">Services.</param>
        /// <returns>services.</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
            return services;
        }
    }
}
