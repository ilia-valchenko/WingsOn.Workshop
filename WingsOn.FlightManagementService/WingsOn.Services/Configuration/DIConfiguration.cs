using Microsoft.Extensions.DependencyInjection;
using WingsOn.Services.Infrastructure;
using WingsOn.Services.Infrastructure.Interfaces;
using WingsOn.Services.Interfaces;
using WingsOn.Services.Services;

namespace WingsOn.Services.Configuration
{
    /// <summary>
    /// Dependency configurator.
    /// </summary>
    public static class DIConfiguration
    {
        /// <summary>
        /// Registers dependencies.
        /// </summary>
        /// <param name="collection">The service collection.</param>
        /// <returns>
        /// Returns the service collection that contains registered dependencies.
        /// </returns>
        public static void RegisterDependencies(IServiceCollection collection)
        {
            Dal.Configuration.DIConfiguration.RegisterDependencies(collection);

            collection.AddTransient<IPersonService, PersonService>();
            collection.AddTransient<IFlightService, FlightService>();
            collection.AddSingleton<IResourceIdGenerator, ResourceIdGenerator>();
        }
    }
}