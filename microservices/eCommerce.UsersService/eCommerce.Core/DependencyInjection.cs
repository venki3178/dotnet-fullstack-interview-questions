using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core
{

    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add Core services to Dependency Injection Container.
        /// </summary>
        /// <param name="services">Services.</param>
        /// <returns>services.</returns>
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            return services;
        }
    }
}
