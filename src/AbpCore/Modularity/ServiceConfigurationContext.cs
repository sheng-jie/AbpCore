using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace AbpCore.Modularity
{
    public class ServiceConfigurationContext
    {
        public IServiceCollection Services { get; }

        public ServiceConfigurationContext([NotNull]IServiceCollection services)
        {
            Services = Check.NotNull(services, nameof(services));
            Services = services;
        }
    }
}